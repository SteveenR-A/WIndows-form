using System;
using System.Linq;
using System.Windows.Forms;

namespace Practica6App
{
    public partial class FormFacturas : Form
    {
        // Assumes DatosVentas.dbml generated a DatosVentasDataContext class in the project
        DatosVentasDataContext db = new DatosVentasDataContext();

        public FormFacturas()
        {
            InitializeComponent();
        }

        private void FormFacturas_Load(object sender, EventArgs e)
        {
            var codigos = from f in db.Factura select f.Codigo;
            comboCodigos.DataSource = codigos.ToList();
        }

        private void comboCodigos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo = (int)comboCodigos.SelectedItem;
            var factura = db.Factura.FirstOrDefault(f => f.Codigo == codigo);
            if (factura != null)
            {
                txtCliente.Text = factura.Cliente;
                txtFecha.Text = factura.Fecha;

                var productos = from p in db.Producto
                                where p.Fk_Codigo == codigo
                                select new { p.Nombre, p.Cantidad, p.Precio };

                dgvProductos.DataSource = productos.ToList();
                txtTotal.Text = productos.Sum(p => p.Cantidad * p.Precio).ToString();
            }
        }
    }
}
