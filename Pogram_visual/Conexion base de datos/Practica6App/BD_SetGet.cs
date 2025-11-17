using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;

namespace Practica6App
{
    public static class BD_SetGet
    {
        private static MySqlConnection? conn;
        private static MySqlCommand? comm;
        private static MySqlDataAdapter? adapt;

        /// <summary>
        /// Establece la conexión con una cadena completa.
        /// </summary>
        public static bool EstablecerConexion(string cx)
        {
            try
            {
                conn = new MySqlConnection(cx);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Lee la cadena de conexión desde app.config por nombre y la establece.
        /// </summary>
        public static bool EstablecerConexionDesdeConfig(string connectionName = "MySqlLoginConnection")
        {
            try
            {
                var cs = ConfigurationManager.ConnectionStrings[connectionName]?.ConnectionString;
                if (string.IsNullOrEmpty(cs))
                    throw new InvalidOperationException($"Connection string '{connectionName}' no encontrada en app.config.");

                conn = new MySqlConnection(cs);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static DataTable EjecutarOrdenSelect(string orden)
        {
            DataTable table = new DataTable();
            try
            {
                if (conn == null)
                    throw new InvalidOperationException("La conexión no ha sido establecida. Llama a EstablecerConexion(cx) antes.");

                conn.Open();
                comm = new MySqlCommand(orden, conn);
                adapt = new MySqlDataAdapter(comm);
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapt.Fill(table);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return table;
        }

        // Overload that accepts parameters (dictionary of parameter name -> value)
        public static DataTable EjecutarOrdenSelect(string orden, Dictionary<string, object> parameters)
        {
            DataTable table = new DataTable();
            try
            {
                if (conn == null)
                    throw new InvalidOperationException("La conexión no ha sido establecida. Llama a EstablecerConexion(cx) antes.");

                conn.Open();
                using (var cmd = new MySqlCommand(orden, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var kv in parameters)
                        {
                            cmd.Parameters.AddWithValue(kv.Key, kv.Value ?? DBNull.Value);
                        }
                    }

                    using (var adapterLocal = new MySqlDataAdapter(cmd))
                    {
                        table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                        adapterLocal.Fill(table);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return table;
        }

        public static int EjecutarOrden(string orden)
        {
            int n = 0;
            try
            {
                if (conn == null)
                    throw new InvalidOperationException("La conexión no ha sido establecida. Llama a EstablecerConexion(cx) antes.");

                conn.Open();
                using (var cmd = new MySqlCommand(orden, conn))
                {
                    n = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return n;
        }

        // Overload with parameters
        public static int EjecutarOrden(string orden, Dictionary<string, object> parameters)
        {
            int n = 0;
            try
            {
                if (conn == null)
                    throw new InvalidOperationException("La conexión no ha sido establecida. Llama a EstablecerConexion(cx) antes.");

                conn.Open();
                using (var cmd = new MySqlCommand(orden, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var kv in parameters)
                        {
                            cmd.Parameters.AddWithValue(kv.Key, kv.Value ?? DBNull.Value);
                        }
                    }

                    n = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return n;
        }
    }
}
