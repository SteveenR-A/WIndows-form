using System;
using System.Windows.Forms;

namespace MDIEstudiantes
{
    public partial class Form3 : Form
    {
    private DataGridView? dgvDatos;
    private TextBox? txtBuscar;
    private Button? btnBuscar;

        public Form3()
        {
            InicializarControles();
        }

        private void InicializarControles()
        {
            this.Text = "Lista de Estudiantes";
            this.Size = new System.Drawing.Size(600, 400);

            txtBuscar = new TextBox
            {
                Name = "txtBuscar",
                Location = new System.Drawing.Point(20, 350),
                Width = 300
            };
            btnBuscar = new Button
            {
                Name = "btnBuscar",
                Text = "Buscar",
                Location = new System.Drawing.Point(340, 350),
                Width = 80
            };
            btnBuscar.Click += BtnBuscar_Click;

            dgvDatos = new DataGridView
            {
                Name = "dgvDatos",
                Location = new System.Drawing.Point(20, 20),
                Width = 540,
                Height = 320,
                AllowUserToAddRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnCount = 4
            };
            dgvDatos.Columns[0].Name = "Nombre";
            dgvDatos.Columns[1].Name = "Carnet";
            dgvDatos.Columns[2].Name = "Materia";
            dgvDatos.Columns[3].Name = "Nota";

            this.Controls.Add(dgvDatos);
            this.Controls.Add(txtBuscar);
            this.Controls.Add(btnBuscar);
            this.Load += Form3_Load;
        }

        private void Form3_Load(object? sender, EventArgs e)
        {
            MostrarEstudiantes(DatosCompartidos.Estudiantes);
        }

        private void BtnBuscar_Click(object? sender, EventArgs e)
        {
            string filtro = txtBuscar?.Text.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(filtro))
            {
                MostrarEstudiantes(DatosCompartidos.Estudiantes);
                return;
            }
            var filtrados = DatosCompartidos.Estudiantes
                .Where(est => (est.Nombre != null && est.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase))
                          || (est.Carnet != null && est.Carnet.Contains(filtro, StringComparison.OrdinalIgnoreCase)))
                .ToList();
            MostrarEstudiantes(filtrados);
        }

        private void MostrarEstudiantes(System.Collections.Generic.List<Estudiante> lista)
        {
            dgvDatos!.Rows.Clear();
            if (lista.Count > 0)
            {
                foreach (var est in lista)
                {
                    foreach (var asig in est.Asignaturas)
                    {
                        dgvDatos.Rows.Add(
                            est.Nombre ?? string.Empty,
                            est.Carnet ?? string.Empty,
                            asig.Nombre ?? string.Empty,
                            asig.Nota
                        );
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay estudiantes registrados o no hay coincidencias.");
            }
        }
    }
}
