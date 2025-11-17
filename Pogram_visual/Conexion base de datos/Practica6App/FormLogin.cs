using System;
using System.Data;
using System.Windows.Forms;

namespace Practica6App
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Usar la cadena desde app.config y métodos parametrizados
            if (!BD_SetGet.EstablecerConexionDesdeConfig("MySqlLoginConnection"))
                return;

            string usuario = txtUsuario.Text?.Trim() ?? string.Empty;
            string clave = txtClave.Text ?? string.Empty;

            string sql = "SELECT * FROM tb_login WHERE usuario = @u AND clave = @p";
            var pars = new System.Collections.Generic.Dictionary<string, object>
            {
                { "@u", usuario },
                { "@p", clave }
            };

            DataTable dt = BD_SetGet.EjecutarOrdenSelect(sql, pars);

            if (dt != null && dt.Rows.Count > 0)
            {
                FormPrincipal frm = new FormPrincipal(usuario);
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o clave incorrectos", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
