using System.Drawing;
using System.Windows.Forms;

namespace Practica6App;

partial class FormPrincipal
{
    private System.ComponentModel.IContainer components = null;
    private Label lblUsuario;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem facturasToolStripMenuItem;
    private ToolStripMenuItem catálogoToolStripMenuItem;
    private ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
    private ToolStripMenuItem salirToolStripMenuItem;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.lblUsuario = new Label();
        this.menuStrip1 = new MenuStrip();
        this.facturasToolStripMenuItem = new ToolStripMenuItem();
        this.catálogoToolStripMenuItem = new ToolStripMenuItem();
        this.cambiarContraseñaToolStripMenuItem = new ToolStripMenuItem();
        this.salirToolStripMenuItem = new ToolStripMenuItem();

        // lblUsuario
        this.lblUsuario.Location = new Point(10, 30);
        this.lblUsuario.Name = "lblUsuario";
        this.lblUsuario.Size = new Size(300, 23);
        this.lblUsuario.Text = "Usuario:";

        // menuStrip1
        this.menuStrip1.Items.AddRange(new ToolStripItem[] {
            this.facturasToolStripMenuItem,
            this.catálogoToolStripMenuItem,
            this.cambiarContraseñaToolStripMenuItem,
            this.salirToolStripMenuItem
        });
        this.menuStrip1.Location = new Point(0, 0);
        this.menuStrip1.Name = "menuStrip1";
        this.menuStrip1.Size = new Size(800, 24);

        // facturasToolStripMenuItem
        this.facturasToolStripMenuItem.Name = "facturasToolStripMenuItem";
        this.facturasToolStripMenuItem.Text = "Facturas";
        this.facturasToolStripMenuItem.Click += new EventHandler(this.facturasToolStripMenuItem_Click);

        // catálogoToolStripMenuItem
        this.catálogoToolStripMenuItem.Name = "catálogoToolStripMenuItem";
        this.catálogoToolStripMenuItem.Text = "Catálogo";
        this.catálogoToolStripMenuItem.Click += new EventHandler(this.catálogoToolStripMenuItem_Click);

        // cambiarContraseñaToolStripMenuItem
        this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
        this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar contraseña";
        this.cambiarContraseñaToolStripMenuItem.Click += new EventHandler(this.cambiarContraseñaToolStripMenuItem_Click);

        // salirToolStripMenuItem
        this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
        this.salirToolStripMenuItem.Text = "Salir";
        this.salirToolStripMenuItem.Click += new EventHandler(this.salirToolStripMenuItem_Click);

        // FormPrincipal
        this.ClientSize = new Size(800, 450);
        this.Controls.Add(this.lblUsuario);
        this.Controls.Add(this.menuStrip1);
        this.MainMenuStrip = this.menuStrip1;
        this.Text = "FormPrincipal";
        this.Load += new EventHandler(this.FormPrincipal_Load);
    }
}
