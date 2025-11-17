using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Practica6App
{
    public static class BD_SetGet
    {
        private static MySqlConnection? conn;
        private static MySqlCommand? comm;
        private static MySqlDataAdapter? adapt;

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

        public static int EjecutarOrden(string orden)
        {
            int n = 0;
            try
            {
                if (conn == null)
                    throw new InvalidOperationException("La conexión no ha sido establecida. Llama a EstablecerConexion(cx) antes.");

                conn.Open();
                comm = new MySqlCommand(orden, conn);
                n = comm.ExecuteNonQuery();
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
