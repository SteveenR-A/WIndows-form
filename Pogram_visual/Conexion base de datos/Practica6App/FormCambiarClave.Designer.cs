using System.Drawing;
using System.Windows.Forms;

namespace Practica6App;

partial class FormCambiarClave
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtActual;
    private TextBox txtNueva;
    private TextBox txtRepetir;
    private Button btnCambiar;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.txtActual = new TextBox();
        this.txtNueva = new TextBox();
        this.txtRepetir = new TextBox();
        this.btnCambiar = new Button();

        // txtActual
        this.txtActual.Location = new Point(20, 20);
        this.txtActual.Name = "txtActual";
        this.txtActual.Size = new Size(200, 23);

        // txtNueva
        this.txtNueva.Location = new Point(20, 60);
        this.txtNueva.Name = "txtNueva";
        this.txtNueva.Size = new Size(200, 23);

        // txtRepetir
        this.txtRepetir.Location = new Point(20, 100);
        this.txtRepetir.Name = "txtRepetir";
        this.txtRepetir.Size = new Size(200, 23);

        // btnCambiar
        this.btnCambiar.Location = new Point(20, 140);
        this.btnCambiar.Name = "btnCambiar";
        this.btnCambiar.Size = new Size(100, 30);
        this.btnCambiar.Text = "Cambiar";
        this.btnCambiar.Click += new EventHandler(this.btnCambiar_Click);

        // FormCambiarClave
        this.ClientSize = new Size(260, 200);
        this.Controls.Add(this.txtActual);
        this.Controls.Add(this.txtNueva);
        this.Controls.Add(this.txtRepetir);
        this.Controls.Add(this.btnCambiar);
        this.Text = "Cambiar contraseña";
    }
}
