using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Practica6App
{
    public class DataAccess
    {
        private readonly string _connectionString;

        public DataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Lee toda la tabla tb_login en un DataTable
        public DataTable LeerLogins()
        {
            using (var conn = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand("SELECT id, username, password FROM tb_login", conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                var ds = new DataSet();
                adapter.Fill(ds, "tb_login");
                return ds.Tables["tb_login"];
            }
        }

        // Verifica si existe un usuario con username y password
        public bool ValidarLogin(string username, string password)
        {
            using (var conn = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand("SELECT COUNT(1) FROM tb_login WHERE username = @u AND password = @p", conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);
                conn.Open();
                var result = Convert.ToInt32(cmd.ExecuteScalar());
                return result > 0;
            }
        }

        // Inserta un nuevo usuario (retorna true si se insertó)
        public bool InsertarLogin(string username, string password)
        {
            using (var conn = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand("INSERT INTO tb_login (username, password) VALUES (@u, @p)", conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
