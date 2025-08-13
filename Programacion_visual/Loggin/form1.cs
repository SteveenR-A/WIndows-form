using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int intentos = 0;

        public Form1()
        {
            InitializeComponent();
            iniciarsesion.Click += iniciarsesion_Click;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void iniciarsesion_Click(object sender, EventArgs e)
        {
            string usuario = Ususario.Text;
            string clave = contrasena.Text;
            if (usuario == "admin" && clave == "admin123")
            {
                MessageBox.Show("Acceso concedido");
                intentos = 0; // Reinicia los intentos si el acceso es correcto
            }
            else
            {
                intentos++;
                if (intentos >= 3)
                {
                    iniciarsesion.Enabled = false;
                    MessageBox.Show("Límite de intentos alcanzado. El acceso ha sido bloqueado.");
                    Close();
                }
                else 
                {
                    MessageBox.Show($"Usuario o clave incorrectos. Intento {intentos} de 3.");

                }
               
                
                   
              
            }
        }

        private void Ususario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
