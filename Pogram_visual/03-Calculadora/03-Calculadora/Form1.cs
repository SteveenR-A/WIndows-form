namespace _03_Calculadora;


using System.Data; // Para DataTable.Compute

public partial class Form1 : Form
{
    private string expresion = ""; // Guarda la expresión completa
    private bool nuevoNumero = true;

    // Variables para memoria
    private double memoria = 0;
    private double potenciaBase = 0;
    private bool esperandoPotencia = false;

    public Form1()
    {
        InitializeComponent();
        // Conectar todos los botones con prefijo b_ a su lógica
        b_num1.Click += (s, ev) => AgregarNumero("1");
        b_num2.Click += (s, ev) => AgregarNumero("2");
        b_num3.Click += (s, ev) => AgregarNumero("3");
        b_num4.Click += (s, ev) => AgregarNumero("4");
        b_num5.Click += (s, ev) => AgregarNumero("5");
        b_num6.Click += (s, ev) => AgregarNumero("6");
        b_num7.Click += (s, ev) => AgregarNumero("7");
        b_num8.Click += (s, ev) => AgregarNumero("8");
        b_num9.Click += (s, ev) => AgregarNumero("9");
        b_num0.Click += (s, ev) => AgregarNumero("0");
        b_punto.Click += (s, ev) => AgregarPunto();
        b_sumar.Click += (s, ev) => Operar("+");
        b_restar.Click += (s, ev) => Operar("-");
        b_multiplicar.Click += (s, ev) => Operar("*");
        b_dividir.Click += (s, ev) => Operar("/");
        b_igual.Click += b_igual_Click;
        b_limpiar.Click += (s, ev) => Limpiar();
        b_borrar.Click += (s, ev) => Borrar();
        b_hw.Click += (s, ev) => MostrarHelloWorld();
        b_log.Click += (s, ev) => Logaritmo();
        b_pi.Click += (s, ev) => InsertarPi();
        b_raiz.Click += (s, ev) => RaizCuadrada();
        b_potencia.Click += (s, ev) => IniciarPotencia();
        b_parentesis_izq.Click += (s, ev) => InsertarParentesis("(");
        b_parentesis_der.Click += (s, ev) => InsertarParentesis(")");
        b_off.Click += (s, ev) => this.Close();
        b_mem_mas.Click += (s, ev) => MemoriaMas();
        b_mem_menos.Click += (s, ev) => MemoriaMenos();
        b_mem_clear.Click += (s, ev) => MemoriaClear();
        b_mem_recall.Click += (s, ev) => MemoriaRecall();
    }


    private void MostrarHelloWorld()
    {
        label1.Text = "Hello World";
    }


    private void AgregarNumero(string num)
    {
        if (nuevoNumero || label1.Text == "0")
        {
            label1.Text = num;
            expresion = num;
            nuevoNumero = false;
        }
        else
        {
            label1.Text += num;
            expresion += num;
        }
    }


    private void AgregarPunto()
    {
        if (!label1.Text.Contains("."))
        {
            label1.Text += ".";
            expresion += ".";
            nuevoNumero = false;
        }
    }


    private void Operar(string op)
    {
        label1.Text += op;
        expresion += op;
        nuevoNumero = false;
    }


    private void Calcular()
    {
        try
        {
            // Evaluar la expresión usando DataTable
            var dt = new DataTable();
            var valor = dt.Compute(expresion, "");
            label1.Text = valor.ToString();
            expresion = label1.Text;
        }
        catch
        {
            label1.Text = "Error";
            expresion = "";
        }
        nuevoNumero = true;
    }


    private void Limpiar()
    {
        label1.Text = "0";
        expresion = "";
        nuevoNumero = true;
    }

    private void Borrar()
    {
        if (label1.Text.Length > 1)
            label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
        else
            label1.Text = "0";
    }

    private void Logaritmo()
    {
        if (double.TryParse(label1.Text, out var v) && v > 0)
            label1.Text = Math.Log10(v).ToString();
        else
            label1.Text = "Error";
    }

    private void InsertarPi()
    {
        label1.Text = Math.PI.ToString();
        nuevoNumero = true;
    }

    private void RaizCuadrada()
    {
        if (double.TryParse(label1.Text, out var v) && v >= 0)
            label1.Text = Math.Sqrt(v).ToString();
        else
            label1.Text = "Error";
        nuevoNumero = true;
    }

    private void IniciarPotencia()
    {
        potenciaBase = double.TryParse(label1.Text, out var v) ? v : 0;
        esperandoPotencia = true;
        label1.Text = "0";
    }

    private void CalcularPotencia()
    {
        if (esperandoPotencia && double.TryParse(label1.Text, out var exponente))
        {
            label1.Text = Math.Pow(potenciaBase, exponente).ToString();
            esperandoPotencia = false;
            nuevoNumero = true;
        }
    }


    private void InsertarParentesis(string parentesis)
    {
        label1.Text += parentesis;
        expresion += parentesis;
    }

    private void MemoriaMas()
    {
        if (double.TryParse(label1.Text, out var v))
            memoria += v;
    }

    private void MemoriaMenos()
    {
        if (double.TryParse(label1.Text, out var v))
            memoria -= v;
    }

    private void MemoriaClear()
    {
        memoria = 0;
    }

    private void MemoriaRecall()
    {
        label1.Text = memoria.ToString();
        nuevoNumero = true;
    }

    // Modificar el botón igual para calcular potencia si corresponde

    private void b_igual_Click(object sender, EventArgs e)
    {
        if (esperandoPotencia)
            CalcularPotencia();
        else
            Calcular();
    }

    private void button27_Click(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }
    
   
}