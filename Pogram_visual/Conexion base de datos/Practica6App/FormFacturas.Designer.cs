using System.Drawing;
using System.Windows.Forms;

namespace Practica6App;

partial class FormFacturas
{
    private System.ComponentModel.IContainer components = null;
    private ComboBox comboCodigos;
    private TextBox txtCliente;
    private TextBox txtFecha;
    private DataGridView dgvProductos;
    private TextBox txtTotal;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.comboCodigos = new ComboBox();
        this.txtCliente = new TextBox();
        this.txtFecha = new TextBox();
        this.dgvProductos = new DataGridView();
        this.txtTotal = new TextBox();

        // comboCodigos
        this.comboCodigos.Location = new Point(10, 10);
        this.comboCodigos.Name = "comboCodigos";
        this.comboCodigos.Size = new Size(200, 23);
        this.comboCodigos.SelectedIndexChanged += new EventHandler(this.comboCodigos_SelectedIndexChanged);

        // txtCliente
        this.txtCliente.Location = new Point(10, 50);
        this.txtCliente.Name = "txtCliente";
        this.txtCliente.Size = new Size(300, 23);

        // txtFecha
        this.txtFecha.Location = new Point(10, 90);
        this.txtFecha.Name = "txtFecha";
        this.txtFecha.Size = new Size(200, 23);

        // dgvProductos
        this.dgvProductos.Location = new Point(10, 130);
        this.dgvProductos.Name = "dgvProductos";
        this.dgvProductos.Size = new Size(600, 200);

        // txtTotal
        this.txtTotal.Location = new Point(520, 340);
        this.txtTotal.Name = "txtTotal";
        this.txtTotal.Size = new Size(90, 23);

        // FormFacturas
        this.ClientSize = new Size(800, 450);
        this.Controls.Add(this.comboCodigos);
        this.Controls.Add(this.txtCliente);
        this.Controls.Add(this.txtFecha);
        this.Controls.Add(this.dgvProductos);
        this.Controls.Add(this.txtTotal);
        this.Text = "Facturas";
        this.Load += new EventHandler(this.FormFacturas_Load);
    }
}
