namespace MDIEstudiantes;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        // Acceder a los botones del MenuStrip
        var menuStrip = this.Controls["menuStrip"] as MenuStrip;
        if (menuStrip != null)
        {
            var btnForm2 = menuStrip.Items["btnForm2"] as ToolStripMenuItem;
            var btnForm3 = menuStrip.Items["btnForm3"] as ToolStripMenuItem;
            // ...existing code...
            if (btnForm2 != null)
                btnForm2.Click += BtnForm2_Click;
            if (btnForm3 != null)
                btnForm3.Click += BtnForm3_Click;
            // ...existing code...
        }
    }
    // ...existing code...

    private void BtnForm2_Click(object? sender, EventArgs e)
    {
        // Evitar abrir múltiples instancias de Form2
        foreach (Form frm in this.MdiChildren)
        {
            if (frm is Form2)
            {
                frm.Activate();
                return;
            }
        }
        var form2 = new Form2();
        form2.MdiParent = this;
        form2.Show();
    }

    private void BtnForm3_Click(object? sender, EventArgs e)
    {
        // Evitar abrir múltiples instancias de Form3
        foreach (Form frm in this.MdiChildren)
        {
            if (frm is Form3)
            {
                frm.Activate();
                return;
            }
        }
        var form3 = new Form3();
        form3.MdiParent = this;
        form3.Show();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        // Puedes agregar aquí lógica de inicialización si lo necesitas
    }
}
