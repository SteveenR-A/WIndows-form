using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Peso1_TextChanged(object sender, EventArgs e)
        {

        }

        private void altura_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        // logica y validacion para IMC
        private void boton_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Peso.Text, out double peso) && double.TryParse(altura.Text, out double alturaVal))
            {
                if (peso > 0 && alturaVal > 0)
                {
                    double imc = peso / (alturaVal * alturaVal);
                    string nivel = "";
                    if (imc < 18.5)
                        nivel = "Bajo peso";
                    else if (imc < 25)
                        nivel = "Normal";
                    else if (imc < 30)
                        nivel = "Sobrepeso";
                    else
                        nivel = "Obesidad";
                    MessageBox.Show($"Su IMC es {imc:F2}\nNivel: {nivel}", "Resultado IMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ingrese valores válidos y positivos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese valores numéricos para peso y altura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Lógica y validación para conversión de temperatura
        private void boton_grados_Click(object sender, EventArgs e)
        {
            bool celsiusOk = double.TryParse(c_Celsius.Text, out double celsius);
            bool fahrenheitOk = double.TryParse(c_Fahrenheit.Text, out double fahrenheit);

            if (celsiusOk && !fahrenheitOk)
            {
                // Convertir de Celsius a Fahrenheit
                double resultado = celsius * 9 / 5 + 32;
                c_Fahrenheit.Text = resultado.ToString("F2");
            }
            else if (!celsiusOk && fahrenheitOk)
            {
                // Convertir de Fahrenheit a Celsius
                double resultado = (fahrenheit - 32) * 5 / 9;
                c_Celsius.Text = resultado.ToString("F2");
            }
            else if (celsiusOk && fahrenheitOk)
            {
                // Si ambos tienen valor, priorizar Celsius
                double resultado = celsius * 9 / 5 + 32;
                c_Fahrenheit.Text = resultado.ToString("F2");
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico en Celsius o Fahrenheit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Lógica para contador
        private int contador = 0;
        private void b_count_Click(object sender, EventArgs e)
        {
            contador++;
            l_count.Text = contador.ToString();
        }
    }
}
