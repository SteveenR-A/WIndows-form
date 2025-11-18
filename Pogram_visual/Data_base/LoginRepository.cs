using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Data_base
{
    public class LoginRepository
    {
        private readonly string _connectionString;

        public LoginRepository()
        {
            var cs = ConfigurationManager.ConnectionStrings["MySqlLoginConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(cs))
                throw new InvalidOperationException("La cadena de conexión 'MySqlLoginConnection' no está configurada en App.config.");
            _connectionString = cs;
        }

        public string? GetNombreIfValid(string usuario, string contrasena)
        {
            // Primero intentamos obtener la columna 'nombre'. Si la columna no existe en la tabla
            // (base de datos creada con el esquema antiguo), hacemos fallback a devolver el
            // valor de 'usuario' para mantener compatibilidad.
            const string queryNombre = "SELECT nombre FROM tb_login WHERE usuario = @usuario AND clave = @contrasena LIMIT 1";
            const string queryUsuario = "SELECT usuario FROM tb_login WHERE usuario = @usuario AND clave = @contrasena LIMIT 1";

            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            try
            {
                using var cmd = new MySqlCommand(queryNombre, conn);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                var resultado = cmd.ExecuteScalar();
                return resultado != null ? resultado.ToString() : null;
            }
            catch (MySqlException mex)
            {
                // Si falla por columna desconocida, intentamos con la columna 'usuario'
                if (mex.Message != null && mex.Message.Contains("Unknown column") && mex.Message.Contains("nombre"))
                {
                    using var cmd2 = new MySqlCommand(queryUsuario, conn);
                    cmd2.Parameters.AddWithValue("@usuario", usuario);
                    cmd2.Parameters.AddWithValue("@contrasena", contrasena);
                    var resultado2 = cmd2.ExecuteScalar();
                    return resultado2 != null ? resultado2.ToString() : null;
                }

                // Re-lanzar otras excepciones
                throw;
            }
        }
    }
}
