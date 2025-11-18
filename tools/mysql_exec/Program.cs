using System;
using System.IO;
using MySql.Data.MySqlClient;

if (args.Length < 2)
{
    Console.WriteLine("Uso: dotnet run -- <connectionString> <script.sql>");
    return;
}

string connStr = args[0];
string scriptPath = args[1];

if (!File.Exists(scriptPath))
{
    Console.WriteLine($"Archivo no encontrado: {scriptPath}");
    return;
}

string sql = File.ReadAllText(scriptPath);

try
{
    using var conn = new MySqlConnection(connStr);
    conn.Open();

    var script = new MySqlScript(conn, sql);
    var count = script.Execute();

    Console.WriteLine($"Script ejecutado correctamente. Sentencias ejecutadas: {count}");
}
catch (Exception ex)
{
    Console.WriteLine("Error al ejecutar script MySQL:");
    Console.WriteLine(ex.ToString());
}
