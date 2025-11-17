using System;
using System.Windows.Forms;

namespace Practica6App
{
    public partial class FormCambiarClave : Form
    {
        private string usuario;

        public FormCambiarClave(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            string cx = "server=localhost;database=bd_login;uid=root;pwd=1234;";
            if (BD_SetGet.EstablecerConexion(cx))
            {
                string actual = txtActual.Text;
                string nueva = txtNueva.Text;
                string repetir = txtRepetir.Text;

                if (nueva != repetir)
                {
                    MessageBox.Show("Las contraseñas no coinciden.");
                    return;
                }

                string sql = $"UPDATE tb_login SET clave='{nueva}' WHERE usuario='{usuario}' AND clave='{actual}'";
                int filas = BD_SetGet.EjecutarOrden(sql);

                if (filas > 0)
                    MessageBox.Show("Contraseña actualizada.");
                else
                    MessageBox.Show("Error al actualizar. Verifique su contraseña actual.");
            }
        }
    }
}
