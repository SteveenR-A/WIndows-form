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
            if (!BD_SetGet.EstablecerConexionDesdeConfig("MySqlLoginConnection"))
                return;

            string actual = txtActual.Text ?? string.Empty;
            string nueva = txtNueva.Text ?? string.Empty;
            string repetir = txtRepetir.Text ?? string.Empty;

            if (nueva != repetir)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            string sql = "UPDATE tb_login SET clave = @nueva WHERE usuario = @usuario AND clave = @actual";
            var pars = new System.Collections.Generic.Dictionary<string, object>
            {
                { "@nueva", nueva },
                { "@usuario", usuario },
                { "@actual", actual }
            };

            int filas = BD_SetGet.EjecutarOrden(sql, pars);

            if (filas > 0)
                MessageBox.Show("Contraseña actualizada.");
            else
                MessageBox.Show("Error al actualizar. Verifique su contraseña actual.");
        }
    }
}
