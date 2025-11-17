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
            // Optionally populate with sample data for testing
            _facturas.Add(new Factura { Codigo = 1, Cliente = "Cliente A", Fecha = "2025-11-16" });
            _products.Add(new Producto { Fk_Codigo = 1, Nombre = "Producto X", Cantidad = 2, Precio = 10.5m });
            _products.Add(new Producto { Fk_Codigo = 1, Nombre = "Producto Y", Cantidad = 1, Precio = 5m });
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
