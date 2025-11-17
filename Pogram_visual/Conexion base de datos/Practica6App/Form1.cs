using System;
using System.Windows.Forms;

namespace Practica6App;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void btnProbarConexion_Click(object sender, EventArgs e)
    {
        // Ajusta la cadena de conexión según tu entorno
        string cs = "Server=localhost;Database=bd_login;Uid=root;Pwd=tu_clave;";
        var da = new DataAccess(cs);
        try
        {
            var dt = da.LeerLogins();
            MessageBox.Show($"Filas en tb_login: {dt.Rows.Count}", "Conexión OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
