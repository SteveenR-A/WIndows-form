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
            // Ajusta la cadena de conexión según tu entorno
            string cx = "server=localhost;database=bd_login;uid=root;pwd=1234;";
            if (BD_SetGet.EstablecerConexion(cx))
            {
                string usuario = txtUsuario.Text;
                string clave = txtClave.Text;

                // NOTA: Este ejemplo usa la misma construcción que compartiste.
                // En un paso posterior podemos parametrizar la consulta para mayor seguridad.
                string sql = $"SELECT * FROM tb_login WHERE usuario='{usuario}' AND clave='{clave}'";
                DataTable dt = BD_SetGet.EjecutarOrdenSelect(sql);

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
}
