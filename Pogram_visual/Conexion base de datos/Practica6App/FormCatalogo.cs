using System;
using System.Drawing;
using System.Windows.Forms;

namespace Practica6App
{
    public partial class FormCatalogo : Form
    {
        public FormCatalogo()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Catálogo";
            this.ClientSize = new Size(600, 400);
        }
    }
}
