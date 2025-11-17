using System.Drawing;
using System.Windows.Forms;

namespace Practica6App;

partial class FormLogin
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtUsuario;
    private TextBox txtClave;
    private Button btnAceptar;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.txtUsuario = new TextBox();
        this.txtClave = new TextBox();
        this.btnAceptar = new Button();

        // txtUsuario
        this.txtUsuario.Location = new Point(20, 20);
        this.txtUsuario.Name = "txtUsuario";
        this.txtUsuario.Size = new Size(200, 23);

        // txtClave
        this.txtClave.Location = new Point(20, 60);
        this.txtClave.Name = "txtClave";
        this.txtClave.Size = new Size(200, 23);
        this.txtClave.UseSystemPasswordChar = true;

        // btnAceptar
        this.btnAceptar.Location = new Point(20, 100);
        this.btnAceptar.Name = "btnAceptar";
        this.btnAceptar.Size = new Size(100, 30);
        this.btnAceptar.Text = "Aceptar";
        this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);

        // FormLogin
        this.ClientSize = new Size(260, 160);
        this.Controls.Add(this.txtUsuario);
        this.Controls.Add(this.txtClave);
        this.Controls.Add(this.btnAceptar);
        this.Text = "Login";
    }
}
