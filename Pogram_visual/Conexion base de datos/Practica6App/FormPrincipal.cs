using System;
using System.Windows.Forms;

namespace Practica6App
{
    public partial class FormPrincipal : Form
    {
        private string usuario;

        public FormPrincipal(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            lblUsuario.Text = "Usuario: " + usuario;
            IsMdiContainer = true;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.MdiParent = this;
            login.Show();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFacturas f = new FormFacturas();
            f.MdiParent = this;
            f.Show();
        }

        private void catálogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCatalogo f = new FormCatalogo();
            f.MdiParent = this;
            f.Show();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCambiarClave f = new FormCambiarClave(usuario);
            f.MdiParent = this;
            f.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
