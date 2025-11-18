using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_base
{
    public partial class Gestion_de_facturas : Form
    {
        private string _usuarioActual;
        private string _nombreUsuario;
        public Gestion_de_facturas(string usuario, string nombre)
        {
            InitializeComponent();
            this._usuarioActual = usuario; 
            this._nombreUsuario = nombre;
        }


        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
   
        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
            Principal principal = new Principal(this._usuarioActual, this._nombreUsuario);
            principal.MdiParent = this;
            principal.Show();
        }
      
        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
           
            C_a c_A = new C_a(this._usuarioActual,this._nombreUsuario);
            c_A.MdiParent = this;
            c_A.Show();
        }

        private void catalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            catalogo catalogo = new catalogo();
            catalogo.MdiParent= this;
            catalogo.Show();
        }

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acerca_de acerca_De = new Acerca_de();
         
        acerca_De.MdiParent = this;
            acerca_De.Show();

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lblUsuarioActual_Click(object sender, EventArgs e)
        {

        }

        private void Gestion_de_facturas_Load(object sender, EventArgs e)
        {
            lblUsuarioActual.Text = "Usuario: " + this._nombreUsuario;
        }
    }
}
