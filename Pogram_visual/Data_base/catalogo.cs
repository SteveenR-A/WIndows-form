using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Data_base
{
    public partial class catalogo : Form
    {
        private SqlDataAdapter dataAdapterCatalogo;
        private DataTable dataTableCatalogo;
        private string GetVentasConnectionString()
        {
            var cs = ConfigurationManager.ConnectionStrings["SqlServerVentasConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(cs))
            {
                // Fallback a una cadena por defecto si no está en App.config
                return "Data Source=localhost\\SQLEXPRESS;Initial Catalog=bd_ventas;Integrated Security=True;";
            }
            return cs;
        }

        public catalogo()
        {
            InitializeComponent();
        }

        private void catalogo_Load_1(object sender, EventArgs e)
        {
            CargarCatalogoEditable();
        }

        private void CargarCatalogoEditable()
        {
            string selectQuery = "SELECT Codigo, Nombre, Precio FROM Catalogo";

            try
            {
                var ventasCs = GetVentasConnectionString();
                dataAdapterCatalogo = new SqlDataAdapter(selectQuery, ventasCs);
                dataTableCatalogo = new DataTable();

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapterCatalogo);

                dataAdapterCatalogo.Fill(dataTableCatalogo);

                dataGridView1.DataSource = dataTableCatalogo;

                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.Columns["Codigo"].ReadOnly = false;
            }
            catch (SqlException sx)
            {
                MessageBox.Show($"Error SQL al cargar el Catálogo (Number={sx.Number}): {sx.Message}", "Error CRUD");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el Catálogo para edición: " + ex.Message, "Error CRUD");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.EndEdit();

                int filasActualizadas = dataAdapterCatalogo.Update(dataTableCatalogo);

                MessageBox.Show($"Cambios guardados exitosamente. Filas afectadas: {filasActualizadas}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los cambios: Asegúrese de que el Código sea único y que no haya campos vacíos. Detalles: " + ex.Message, "Error al Actualizar");
            }
        }

      
    }
}