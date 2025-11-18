using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_base
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txbUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txbUsuario.Text.Trim();
            string contrasena = txbContraseña.Text.Trim();

            try
            {
                var repo = new LoginRepository();
                var nombre = repo.GetNombreIfValid(usuario, contrasena);

                if (!string.IsNullOrEmpty(nombre))
                {
                    MessageBox.Show($"¡Bienvenido al sistema, {nombre}!", "Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Gestion_de_facturas gestion_De_Facturas = new Gestion_de_facturas(usuario, nombre);
                    gestion_De_Facturas.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar iniciar sesión: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txbContraseña_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

