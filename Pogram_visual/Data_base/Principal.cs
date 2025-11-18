using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
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

        private string GetVentasConnectionString()
        {
            var cs = ConfigurationManager.ConnectionStrings["SqlServerVentasConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(cs))
            {
                return "Data Source=localhost\\SQLEXPRESS;Initial Catalog=bd_ventas;Integrated Security=True;";
            }
            return cs;
        }

        private void CargarCodigosCatalogo()
        {
            string connectionString = GetVentasConnectionString();
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
            catch (SqlException sx)
            {
                MessageBox.Show($"Error SQL al cargar códigos (Number={sx.Number}): {sx.Message}", "Conexión Fallida");
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
                string codigoSeleccionado = cbxCodigo.SelectedItem.ToString();
                CargarProductosPorCodigo(codigoSeleccionado);
                CalcularTotal(codigoSeleccionado);
            }
        }

        private void CargarProductosPorCodigo(string codigo)
        {
            string connectionString = GetVentasConnectionString();
            string query = "SELECT p.Id, c.Codigo, c.Nombre, p.PrecioUnitario AS Precio, p.Cantidad "
                         + "FROM Producto p INNER JOIN Catalogo c ON p.CatalogoId = c.Id "
                         + "WHERE c.Codigo = @Codigo";

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
            catch (SqlException sx)
            {
                MessageBox.Show($"Error SQL al cargar productos (Number={sx.Number}): {sx.Message}", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error");
            }
        }

        private void CalcularTotal(string codigo)
        {
            string connectionString = GetVentasConnectionString();
            string query = "SELECT SUM(p.PrecioUnitario * p.Cantidad) "
                         + "FROM Producto p INNER JOIN Catalogo c ON p.CatalogoId = c.Id "
                         + "WHERE c.Codigo = @Codigo";

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
            catch (SqlException sx)
            {
                MessageBox.Show($"Error SQL al calcular total (Number={sx.Number}): {sx.Message}", "Error");
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
            string connectionString = GetVentasConnectionString();
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
            catch (SqlException sx)
            {
                MessageBox.Show($"Error SQL al cargar productos del catálogo (Number={sx.Number}): {sx.Message}", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos del catálogo: " + ex.Message);
            }
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            // Requerir al menos el nombre del cliente
            if (string.IsNullOrWhiteSpace(tbxNombreC.Text))
            {
                MessageBox.Show("Debe llenar el campo Cliente.");
                return;
            }

            string cliente = tbxNombreC.Text.Trim();
            string fecha = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");

            string connectionString = GetVentasConnectionString();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Usar transacción para insertar factura y productos de forma atómica
                    using (SqlTransaction tx = connection.BeginTransaction())
                    {
                        try
                        {
                            // Insertar factura y obtener su Id (IDENTITY)
                            string queryFactura = "INSERT INTO Factura (Fecha, Cliente, Total) VALUES (@Fecha, @Cliente, @Total); SELECT SCOPE_IDENTITY();";
                            int facturaId;
                            using (SqlCommand cmdFactura = new SqlCommand(queryFactura, connection, tx))
                            {
                                cmdFactura.Parameters.AddWithValue("@Fecha", fecha);
                                cmdFactura.Parameters.AddWithValue("@Cliente", cliente);
                                cmdFactura.Parameters.AddWithValue("@Total", 0);
                                object res = cmdFactura.ExecuteScalar();
                                facturaId = Convert.ToInt32(res);
                            }

                            // Insertar productos seleccionados. Se asume que dataGridView2 tiene columnas: Codigo, Nombre, Precio, Cantidad
                            decimal totalFactura = 0m;

                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                if (row.Cells["Cantidad"].Value != null &&
                                    int.TryParse(row.Cells["Cantidad"].Value.ToString(), out int cantidad) &&
                                    cantidad > 0)
                                {
                                    string codigoCatalogo = row.Cells["Codigo"].Value?.ToString();
                                    if (string.IsNullOrWhiteSpace(codigoCatalogo))
                                        continue;

                                    // Obtener Catalogo.Id y precio unitario desde la tabla Catalogo (usar la misma conexión y transacción)
                                    int catalogoId = -1;
                                    decimal precioUnitario = 0m;
                                    string selCatalogo = "SELECT Id, Precio FROM Catalogo WHERE Codigo = @Codigo";
                                    using (SqlCommand cmdSel = new SqlCommand(selCatalogo, connection, tx))
                                    {
                                        cmdSel.Parameters.AddWithValue("@Codigo", codigoCatalogo);
                                        using (SqlDataReader rdr = cmdSel.ExecuteReader())
                                        {
                                            if (rdr.Read())
                                            {
                                                catalogoId = rdr.GetInt32(rdr.GetOrdinal("Id"));
                                                precioUnitario = rdr.GetDecimal(rdr.GetOrdinal("Precio"));
                                            }
                                        }
                                    }

                                    if (catalogoId == -1)
                                    {
                                        // Si no existe el catalogo para ese codigo, saltarlo
                                        continue;
                                    }

                                    // Insertar producto con referencias normalizadas
                                    string insertProducto = "INSERT INTO Producto (FacturaId, CatalogoId, Cantidad, PrecioUnitario) VALUES (@FacturaId, @CatalogoId, @Cantidad, @PrecioUnitario)";
                                    using (SqlCommand cmdIns = new SqlCommand(insertProducto, connection, tx))
                                    {
                                        cmdIns.Parameters.AddWithValue("@FacturaId", facturaId);
                                        cmdIns.Parameters.AddWithValue("@CatalogoId", catalogoId);
                                        cmdIns.Parameters.AddWithValue("@Cantidad", cantidad);
                                        cmdIns.Parameters.AddWithValue("@PrecioUnitario", precioUnitario);
                                        cmdIns.ExecuteNonQuery();
                                    }

                                    totalFactura += precioUnitario * cantidad;
                                }
                            }

                            // Actualizar total de la factura
                            string updFactura = "UPDATE Factura SET Total = @Total WHERE Id = @Id";
                            using (SqlCommand cmdUpd = new SqlCommand(updFactura, connection, tx))
                            {
                                cmdUpd.Parameters.AddWithValue("@Total", totalFactura);
                                cmdUpd.Parameters.AddWithValue("@Id", facturaId);
                                cmdUpd.ExecuteNonQuery();
                            }

                            // Commit si todo salió bien
                            tx.Commit();

                            MessageBox.Show("Factura y productos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridView2.DataSource = null;
                            CargarProductosCatalogo();
                        }
                        catch (Exception)
                        {
                            try { tx.Rollback(); } catch { }
                            throw;
                        }
                    }
                }
            }
            catch (SqlException sx)
            {
                MessageBox.Show($"Error SQL al guardar la factura (Number={sx.Number}): {sx.Message}", "Error al Guardar");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la factura: " + ex.Message);
            }
        }
    }

}

