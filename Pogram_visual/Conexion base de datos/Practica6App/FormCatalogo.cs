using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Practica6App
{
    public class FormCatalogo : Form
    {
        private DataGridView dgv;
        private Button btnCargar;
        private Button btnGuardar;
        private Button btnAgregar;
        private Button btnEliminar;
        private BindingSource bs;
        private DataSet ds;
        private SqlDataAdapter adapter;
        private string connectionString;

        public FormCatalogo()
        {
            this.Text = "Catálogo";
            this.ClientSize = new System.Drawing.Size(800, 450);

            dgv = new DataGridView() { Dock = DockStyle.Top, Height = 340, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            btnCargar = new Button() { Text = "Cargar", Left = 10, Top = 360, Width = 100 };
            btnGuardar = new Button() { Text = "Guardar", Left = 120, Top = 360, Width = 100 };
            btnAgregar = new Button() { Text = "Agregar fila", Left = 230, Top = 360, Width = 100 };
            btnEliminar = new Button() { Text = "Eliminar fila", Left = 340, Top = 360, Width = 100 };

            btnCargar.Click += BtnCargar_Click;
            btnGuardar.Click += BtnGuardar_Click;
            btnAgregar.Click += BtnAgregar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            this.Controls.Add(dgv);
            this.Controls.Add(btnCargar);
            this.Controls.Add(btnGuardar);
            this.Controls.Add(btnAgregar);
            this.Controls.Add(btnEliminar);

            bs = new BindingSource();
            ds = new DataSet();

            // Leer connection string desde app.config
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["SqlServerVentasConnection"]?.ConnectionString ?? string.Empty;
            }
            catch
            {
                connectionString = string.Empty;
            }
        }

        private void BtnCargar_Click(object? sender, EventArgs e)
        {
            LoadCatalogo();
        }

        private void LoadCatalogo()
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Connection string 'SqlServerVentasConnection' no encontrada en app.config.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ds.Clear();
                adapter = new SqlDataAdapter("SELECT * FROM Catalogo", connectionString);
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                var builder = new SqlCommandBuilder(adapter);
                adapter.Fill(ds, "Catalogo");

                bs.DataSource = ds.Tables["Catalogo"];
                dgv.DataSource = bs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar catálogo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            SaveChanges();
        }

        private void SaveChanges()
        {
            if (adapter == null)
            {
                MessageBox.Show("No hay datos para guardar. Cargue el catálogo primero.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // End any current edits
                this.BindingContext[bs].EndCurrentEdit();
                adapter.Update(ds, "Catalogo");
                MessageBox.Show("Cambios guardados.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Refresh
                LoadCatalogo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            if (ds.Tables.Contains("Catalogo"))
            {
                var table = ds.Tables["Catalogo"];
                var row = table.NewRow();
                // Leave fields empty/default, user can edit in grid
                table.Rows.Add(row);
                bs.MoveLast();
            }
            else
            {
                MessageBox.Show("Cargue el catálogo antes de agregar filas.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (bs.Current is DataRowView drv)
            {
                drv.Row.Delete();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

