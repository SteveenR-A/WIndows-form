using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica6App
{
    // Lightweight stubs to allow compilation when the DBML-generated types are not present.
    // Replace these with your generated DatosVentasDataContext and entity classes.
    public class DatosVentasDataContext
    {
        // Return empty queryables by default so the form compiles and runs without data.
        public IQueryable<Factura> Factura => _facturas.AsQueryable();
        public IQueryable<Producto> Producto => _productos.AsQueryable();

        private List<Factura> _facturas = new List<Factura>();
        private List<Producto> _products = new List<Producto>();

        // Provide a backing list with matching names used by FormFacturas.
        private List<Producto> _productos => _products;

        public DatosVentasDataContext()
        {
            // Populate with sample data for testing (multiple invoices and products)
            _facturas.Add(new Factura { Codigo = 1001, Cliente = "Acme S.A.", Fecha = "2025-11-10" });
            _facturas.Add(new Factura { Codigo = 1002, Cliente = "Distribuciones SRL", Fecha = "2025-11-11" });
            _facturas.Add(new Factura { Codigo = 1003, Cliente = "Comercial Lopez", Fecha = "2025-11-12" });

            // Products for factura 1001
            _products.Add(new Producto { Fk_Codigo = 1001, Nombre = "Tornillos M6", Cantidad = 50, Precio = 0.12m });
            _products.Add(new Producto { Fk_Codigo = 1001, Nombre = "Tuercas M6", Cantidad = 50, Precio = 0.08m });

            // Products for factura 1002
            _products.Add(new Producto { Fk_Codigo = 1002, Nombre = "Motor 12V", Cantidad = 2, Precio = 45.00m });
            _products.Add(new Producto { Fk_Codigo = 1002, Nombre = "Correa de transmisión", Cantidad = 2, Precio = 12.50m });

            // Products for factura 1003
            _products.Add(new Producto { Fk_Codigo = 1003, Nombre = "Monitor 24\"", Cantidad = 3, Precio = 120.00m });
            _products.Add(new Producto { Fk_Codigo = 1003, Nombre = "Teclado USB", Cantidad = 3, Precio = 15.00m });
            _products.Add(new Producto { Fk_Codigo = 1003, Nombre = "Mouse óptico", Cantidad = 3, Precio = 8.50m });
        }
    }

    public class Factura
    {
        public int Codigo { get; set; }
        public string? Cliente { get; set; }
        public string? Fecha { get; set; }
    }

    public class Producto
    {
        public int Fk_Codigo { get; set; }
        public string? Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
