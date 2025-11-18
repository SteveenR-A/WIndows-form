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
    public partial class C_a : Form
    {
        string usuarioActual;
        string nombreUsuario;
        public C_a(string usuario, string nombre)
        {
            InitializeComponent();

            this.usuarioActual = usuario;
            this.nombreUsuario = nombre;
        }

        

        private void C_a_Load(object sender, EventArgs e)
        {

        }


        private void btnGuard_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-ANMUUFA\\SQLEXPRESS03;Database=bd_login;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

            string antigua = txbContra.Text.Trim();
            string nueva = txbContraN.Text.Trim();
            string confirmar = txbContraNN.Text.Trim();

            // Validaciones básicas
            if (string.IsNullOrEmpty(antigua) || string.IsNullOrEmpty(nueva) || string.IsNullOrEmpty(confirmar))
            {
                MessageBox.Show("Debe completar todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nueva != confirmar)
            {
                MessageBox.Show("La nueva contraseña y su confirmación no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    string verificarQuery = "SELECT COUNT(*) FROM tb_login WHERE usuario = @usuario AND clave = @antigua";
                    using (SqlCommand cmdVerificar = new SqlCommand(verificarQuery, connection))
                    {
                        cmdVerificar.Parameters.AddWithValue("@usuario", usuarioActual);
                        cmdVerificar.Parameters.AddWithValue("@antigua", antigua);

                        int existe = (int)cmdVerificar.ExecuteScalar();

                        if (existe == 0)
                        {
                            MessageBox.Show("La contraseña actual no es correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }


                    string actualizarQuery = "UPDATE tb_login SET clave = @nueva WHERE usuario = @usuario";
                    using (SqlCommand cmdActualizar = new SqlCommand(actualizarQuery, connection))
                    {
                        cmdActualizar.Parameters.AddWithValue("@nueva", nueva);
                        cmdActualizar.Parameters.AddWithValue("@usuario", usuarioActual);

                        int filas = cmdActualizar.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            MessageBox.Show("Contraseña actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txbContra.Clear();
                            txbContraN.Clear();
                            txbContraNN.Clear();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar la contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar la contraseña: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    }

