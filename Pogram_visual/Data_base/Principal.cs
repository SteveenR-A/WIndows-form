using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Data_base
{
    public partial class Principal : Form
    {
      
        public Principal(string usuario,string nombre)
        {
            InitializeComponent();
          
         
        }


        private void Principal_Load_1(object sender, EventArgs e)
        {
            CargarCodigosCatalogo();
            CargarProductosCatalogo();
        }

        private void CargarCodigosCatalogo()
        {
            string connectionString = "Server=DESKTOP-ANMUUFA\\SQLEXPRESS03;Database=bd_ventas;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
            string query = "SELECT Codigo FROM Catalogo ORDER BY Codigo";

            cbxCodigo.Items.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbxCodigo.Items.Add(reader["Codigo"].ToString());
                        }
                    }
                }

                if (cbxCodigo.Items.Count > 0)
                    cbxCodigo.SelectedIndex = 0;
                else
                    MessageBox.Show("Tabla Catalogo vacía o sin resultados.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Conexión Fallida");
            }
        }

        private void cbxCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCodigo.SelectedItem != null)
            {
                int codigoSeleccionado = int.Parse(cbxCodigo.SelectedItem.ToString());
                CargarProductosPorCodigo(codigoSeleccionado);
                CalcularTotal(codigoSeleccionado);
            }
        }

        private void CargarProductosPorCodigo(int codigo)
        {
            string connectionString = "Server=DESKTOP-ANMUUFA\\SQLEXPRESS03;Database=bd_ventas;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
            string query = "SELECT * FROM Producto WHERE Codigo = @Codigo";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codigo", codigo);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    dataGridView1.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error");
            }
        }

        private void CalcularTotal(int codigo)
        {
            string connectionString = "Server=DESKTOP-ANMUUFA\\SQLEXPRESS03;Database=bd_ventas;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
            string query = "SELECT SUM(Precio * Cantidad) FROM Producto WHERE Codigo = @Codigo";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codigo", codigo);
                    connection.Open();

                    object resultado = command.ExecuteScalar();

                    if (resultado != DBNull.Value && resultado != null)
                    {
                        decimal total = Convert.ToDecimal(resultado);
                        LbTotal.Text = total.ToString("N2");

                    }
                    else
                    {
                        LbTotal.Text = "0.00";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular total: " + ex.Message);
            }
        }


        private void LbTotal_Click(object sender, EventArgs e)
        {

        }

        
       

        
        // -------------------- NUEVA SECCIÓN: FACTURA Y PRODUCTOS --------------------

        private void CargarProductosCatalogo()
        {
            string connectionString = "Server=DESKTOP-ANMUUFA\\SQLEXPRESS03;Database=bd_ventas;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
            string query = "SELECT Codigo, Nombre, Precio FROM Catalogo";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    // Agregar columna editable de cantidad
                    tabla.Columns.Add("Cantidad", typeof(int));

                    dataGridView2.DataSource = tabla;

                    foreach (DataGridViewColumn columna in dataGridView2.Columns)
                    {
                        columna.ReadOnly = columna.Name != "Cantidad";
                    }

                    dataGridView2.Columns["Cantidad"].HeaderText = "Cantidad a comprar";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos del catálogo: " + ex.Message);
            }
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxCodigoFac.Text) || string.IsNullOrWhiteSpace(tbxNombreC.Text))
            {
                MessageBox.Show("Debe llenar los campos de factura (Código y Cliente).");
                return;
            }

            int codigoFactura = int.Parse(tbxCodigoFac.Text);
            string cliente = tbxNombreC.Text.Trim();
            string fecha = dateTimePicker1.Value.ToString("dd-MM-yyyy");

            string connectionString = "Server=DESKTOP-ANMUUFA\\SQLEXPRESS03;Database=bd_ventas;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insertar factura
                    string queryFactura = "INSERT INTO Factura (Codigo, Cliente, Fecha) VALUES (@Codigo, @Cliente, @Fecha)";
                    using (SqlCommand cmdFactura = new SqlCommand(queryFactura, connection))
                    {
                        cmdFactura.Parameters.AddWithValue("@Codigo", codigoFactura);
                        cmdFactura.Parameters.AddWithValue("@Cliente", cliente);
                        cmdFactura.Parameters.AddWithValue("@Fecha", fecha);
                        cmdFactura.ExecuteNonQuery();
                    }

                    // Insertar productos seleccionados
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (row.Cells["Cantidad"].Value != null &&
                            int.TryParse(row.Cells["Cantidad"].Value.ToString(), out int cantidad) &&
                            cantidad > 0)
                        {
                            int codigo = Convert.ToInt32(row.Cells["Codigo"].Value);
                            string nombre = row.Cells["Nombre"].Value.ToString();
                            double precio = Convert.ToDouble(row.Cells["Precio"].Value);

                            string queryProducto = "INSERT INTO Producto (Codigo, Nombre, Precio, Cantidad, Fk_Codigo) VALUES (@Codigo, @Nombre, @Precio, @Cantidad, @Fk)";
                            using (SqlCommand cmdProducto = new SqlCommand(queryProducto, connection))
                            {
                                cmdProducto.Parameters.AddWithValue("@Codigo", codigo);
                                cmdProducto.Parameters.AddWithValue("@Nombre", nombre);
                                cmdProducto.Parameters.AddWithValue("@Precio", precio);
                                cmdProducto.Parameters.AddWithValue("@Cantidad", cantidad);
                                cmdProducto.Parameters.AddWithValue("@Fk", codigoFactura);
                                cmdProducto.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Factura y productos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.DataSource = null;
                    CargarProductosCatalogo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la factura: " + ex.Message);
            }
        }
    }

}

