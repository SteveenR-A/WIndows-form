using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Practica6App
{
    public partial class FormLogin : Form
    {
        private TextBox txtUsuario;
        private TextBox txtClave;
        private Button btnAceptar;

        public FormLogin()
        {
            this.Text = "Ingreso";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 320;
            this.Height = 220;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var lblUsuario = new Label() { Text = "Usuario:", Top = 16, Left = 16, AutoSize = true };
            txtUsuario = new TextBox() { Top = 36, Left = 16, Width = 260 };

            var lblClave = new Label() { Text = "Contraseña:", Top = 72, Left = 16, AutoSize = true };
            txtClave = new TextBox() { Top = 92, Left = 16, Width = 260, UseSystemPasswordChar = true };

            btnAceptar = new Button() { Text = "Aceptar", Top = 132, Left = 16, Width = 100 };
            btnAceptar.Click += BtnAceptar_Click;

            var btnSalir = new Button() { Text = "Salir", Top = 132, Left = 176, Width = 100 };
            btnSalir.Click += (s, e) => Application.Exit();

            this.Controls.Add(lblUsuario);
            this.Controls.Add(txtUsuario);
            this.Controls.Add(lblClave);
            this.Controls.Add(txtClave);
            this.Controls.Add(btnAceptar);
            this.Controls.Add(btnSalir);
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            btnAceptar.Enabled = false;
            try
            {
                var usuario = txtUsuario.Text?.Trim() ?? string.Empty;
                var clave = txtClave.Text ?? string.Empty;

                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
                {
                    MessageBox.Show("Ingrese usuario y contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Establecer conexión desde app.config
                if (!BD_SetGet.EstablecerConexionDesdeConfig("MySqlLoginConnection"))
                    return;

                string sql = "SELECT id, usuario FROM tb_login WHERE usuario = @u AND clave = @p LIMIT 1";
                var pars = new Dictionary<string, object>
                {
                    { "@u", usuario },
                    { "@p", clave }
                };

                DataTable dt = BD_SetGet.EjecutarOrdenSelect(sql, pars);

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Login OK
                    var frm = new FormPrincipal(usuario);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                btnAceptar.Enabled = true;
            }
        }
    }
}
