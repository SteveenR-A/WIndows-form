using System;
using System.Windows.Forms;

namespace MDIEstudiantes
{
    public partial class Form3 : Form
    {
    private TextBox? txtCarnet;
    private TextBox? txtNombre;
    private DataGridView? dgvDatos;

        public Form3()
        {
            InicializarControles();
        }

        private void InicializarControles()
        {
            this.Text = "Visualización de Estudiante";
            this.Size = new System.Drawing.Size(400, 400);

            var lblCarnet = new Label { Text = "Carnet:", Location = new System.Drawing.Point(20, 20) };
            txtCarnet = new TextBox { Name = "txtCarnet", Location = new System.Drawing.Point(120, 20), Width = 200, ReadOnly = true };
            var lblNombre = new Label { Text = "Nombre:", Location = new System.Drawing.Point(20, 60) };
            txtNombre = new TextBox { Name = "txtNombre", Location = new System.Drawing.Point(120, 60), Width = 200, ReadOnly = true };

            dgvDatos = new DataGridView
            {
                Name = "dgvDatos",
                Location = new System.Drawing.Point(20, 100),
                Width = 340,
                Height = 180,
                AllowUserToAddRows = false,
                ColumnCount = 2
            };
            dgvDatos.Columns[0].Name = "Asignatura";
            dgvDatos.Columns[1].Name = "Nota Final";

            this.Controls.Add(lblCarnet);
            this.Controls.Add(txtCarnet);
            this.Controls.Add(lblNombre);
            this.Controls.Add(txtNombre);
            this.Controls.Add(dgvDatos);

            this.Load += Form3_Load;
        }

        private void Form3_Load(object? sender, EventArgs e)
        {
            if (DatosCompartidos.EstudianteActual != null)
            {
                txtCarnet!.Text = DatosCompartidos.EstudianteActual.Carnet ?? string.Empty;
                txtNombre!.Text = DatosCompartidos.EstudianteActual.Nombre ?? string.Empty;

                dgvDatos!.Rows.Clear();
                foreach (var asig in DatosCompartidos.EstudianteActual.Asignaturas)
                {
                    dgvDatos.Rows.Add(asig.Nombre ?? string.Empty, asig.Nota);
                }
            }
            else
            {
                MessageBox.Show("No hay datos de estudiante cargados.");
            }
        }
    }
}
