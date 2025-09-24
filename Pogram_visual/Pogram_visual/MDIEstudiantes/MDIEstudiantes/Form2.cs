using System;
using System.Windows.Forms;

namespace MDIEstudiantes
{
    public partial class Form2 : Form
    {
    private TextBox? txtCarnet;
    private TextBox? txtNombre;
    private DataGridView? dgvAsignaturas;
    private Button? btnGuardar;

        public Form2()
        {
            InicializarControles();
        }

        private void InicializarControles()
        {
            this.Text = "Ingreso de Estudiante";
            this.Size = new System.Drawing.Size(400, 400);
            
            var lblCarnet = new Label { Text = "Carnet:", Location = new System.Drawing.Point(20, 20) };
            txtCarnet = new TextBox { Name = "txtCarnet", Location = new System.Drawing.Point(120, 20), Width = 200 };
            var lblNombre = new Label { Text = "Nombre:", Location = new System.Drawing.Point(20, 60) };
            txtNombre = new TextBox { Name = "txtNombre", Location = new System.Drawing.Point(120, 60), Width = 200 };

            dgvAsignaturas = new DataGridView
            {
                Name = "dgvAsignaturas",
                Location = new System.Drawing.Point(20, 100),
                Width = 340,
                Height = 180,
                AllowUserToAddRows = true,
                ColumnCount = 2
            };
            dgvAsignaturas.Columns[0].Name = "Asignatura";
            dgvAsignaturas.Columns[1].Name = "Nota Final";

            btnGuardar = new Button
            {
                Name = "btnGuardar",
                Text = "Guardar",
                Location = new System.Drawing.Point(140, 300),
                Width = 100
            };
            btnGuardar.Click += btnGuardar_Click;

            this.Controls.Add(lblCarnet);
            this.Controls.Add(txtCarnet);
            this.Controls.Add(lblNombre);
            this.Controls.Add(txtNombre);
            this.Controls.Add(dgvAsignaturas);
            this.Controls.Add(btnGuardar);
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            var estudiante = new Estudiante
            {
                Carnet = txtCarnet?.Text ?? string.Empty,
                Nombre = txtNombre?.Text ?? string.Empty
            };

            if (dgvAsignaturas != null)
            {
                foreach (DataGridViewRow fila in dgvAsignaturas.Rows)
                {
                    if (fila.Cells[0].Value is string asig && fila.Cells[1].Value is not null)
                    {
                        double nota;
                        var notaStr = fila.Cells[1].Value?.ToString() ?? string.Empty;
                        if (double.TryParse(notaStr, out nota))
                        {
                            estudiante.Asignaturas.Add(new Asignatura
                            {
                                Nombre = asig,
                                Nota = nota
                            });
                        }
                    }
                }
            }

            DatosCompartidos.EstudianteActual = estudiante;
            DatosCompartidos.Estudiantes.Add(estudiante);
            MessageBox.Show("Datos guardados correctamente");
            this.Close();
        }
    }
}
