using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

class Program
{
    static int Main(string[] args)
    {
        // Por seguridad: el test de inserción solo se ejecuta si se pasa el flag --run-test
        if (args == null || args.Length == 0 || Array.IndexOf(args, "--run-test") < 0)
        {
            // Lanzar la aplicación principal (Data_base) para mostrar el login cuando no se solicita el test
            try
            {
                string projectDir = System.IO.Path.GetFullPath(System.IO.Path.Combine("..", ".."));
                Console.WriteLine($"Lanzando aplicación principal desde carpeta '{projectDir}'...");

                var psi = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = "run",
                    UseShellExecute = false,
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    CreateNoWindow = false,
                    WorkingDirectory = projectDir
                };

                Process.Start(psi);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo lanzar la aplicación principal: " + ex.Message);
                Console.WriteLine("Modo seguro: no se ejecuta el test automático. Ejecute con '--run-test' para insertar datos de prueba.");
                return 0;
            }
        }
        string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=bd_ventas;Integrated Security=True;";

        try
        {
            using (var conn = new SqlConnection(cs))
            {
                conn.Open();
                Console.WriteLine("Conectado a bd_ventas.");

                // Crear factura
                string insertFactura = "INSERT INTO Factura (Fecha, Cliente, Total) VALUES (@Fecha, @Cliente, @Total); SELECT SCOPE_IDENTITY();";
                int facturaId;
                using (var cmd = new SqlCommand(insertFactura, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Cliente", "TEST_CLIENT");
                    cmd.Parameters.AddWithValue("@Total", 0);
                    object idObj = cmd.ExecuteScalar();
                    facturaId = Convert.ToInt32(idObj);
                }
                Console.WriteLine($"Factura creada Id={facturaId}");

                string[] codes = new[] { "P001", "P002" };
                decimal total = 0m;

                foreach (var code in codes)
                {
                    // Obtener catalogo id y precio
                    string sel = "SELECT Id, Precio FROM Catalogo WHERE Codigo = @Codigo";
                    int catalogoId = -1;
                    decimal precio = 0m;
                    using (var cmd = new SqlCommand(sel, conn))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", code);
                        using (var rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                catalogoId = rdr.GetInt32(rdr.GetOrdinal("Id"));
                                precio = rdr.GetDecimal(rdr.GetOrdinal("Precio"));
                            }
                        }
                    }

                    if (catalogoId == -1)
                    {
                        Console.WriteLine($"Catalogo no encontrado para Codigo={code}, se salta.");
                        continue;
                    }

                    int cantidad = code == "P001" ? 2 : 1;

                    string insertProd = "INSERT INTO Producto (FacturaId, CatalogoId, Cantidad, PrecioUnitario) VALUES (@FacturaId, @CatalogoId, @Cantidad, @PrecioUnitario)";
                    using (var cmd = new SqlCommand(insertProd, conn))
                    {
                        cmd.Parameters.AddWithValue("@FacturaId", facturaId);
                        cmd.Parameters.AddWithValue("@CatalogoId", catalogoId);
                        cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@PrecioUnitario", precio);
                        cmd.ExecuteNonQuery();
                    }

                    total += precio * cantidad;
                    Console.WriteLine($"Insertado Producto Codigo={code} CatalogoId={catalogoId} Cant={cantidad} Precio={precio}");
                }

                // Actualizar total
                string upd = "UPDATE Factura SET Total = @Total WHERE Id = @Id";
                using (var cmd = new SqlCommand(upd, conn))
                {
                    cmd.Parameters.AddWithValue("@Total", total);
                    cmd.Parameters.AddWithValue("@Id", facturaId);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine($"Factura {facturaId} actualizada con total {total:C}.");

                // Mostrar conteo productos para la factura
                string cnt = "SELECT COUNT(*) FROM Producto WHERE FacturaId = @Id";
                using (var cmd = new SqlCommand(cnt, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", facturaId);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    Console.WriteLine($"Productos insertados: {count}");
                }
            }

            return 0;
        }
        catch (SqlException sx)
        {
            Console.WriteLine($"SqlException Number={sx.Number} Message={sx.Message}");
            return 2;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return 1;
        }
    }
}
