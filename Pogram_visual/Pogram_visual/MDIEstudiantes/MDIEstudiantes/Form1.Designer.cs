namespace MDIEstudiantes;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
    menuStrip = new System.Windows.Forms.MenuStrip();
    btnForm2 = new System.Windows.Forms.ToolStripMenuItem();
    btnForm3 = new System.Windows.Forms.ToolStripMenuItem();
    btnFormGrafico = new System.Windows.Forms.ToolStripMenuItem();
        menuStrip.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip
        // 
    menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnForm2, btnForm3, btnFormGrafico });
        menuStrip.Location = new System.Drawing.Point(0, 0);
    menuStrip.Name = "menuStrip";
        menuStrip.Size = new System.Drawing.Size(800, 24);
        menuStrip.TabIndex = 0;
        menuStrip.Text = "menuStrip";
        // 
    // btnForm2
    // 
    btnForm2.Name = "btnForm2";
    btnForm2.Size = new System.Drawing.Size(119, 20);
    btnForm2.Text = "Ingresar Estudiante";
    // 
    // btnForm3
    // 
    btnForm3.Name = "btnForm3";
    btnForm3.Size = new System.Drawing.Size(93, 20);
    btnForm3.Text = "Ver Estudiante";
    // 
    // btnFormGrafico
    // 
    btnFormGrafico.Name = "btnFormGrafico";
    btnFormGrafico.Size = new System.Drawing.Size(90, 20);
    btnFormGrafico.Text = "Ver Gráfico";
        // 
        // Form1
        // 
    AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    ClientSize = new System.Drawing.Size(800, 450);
    IsMdiContainer = true;
    MainMenuStrip = menuStrip;
    Controls.Add(menuStrip);
    Text = "MDI Estudiantes";
    StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
    WindowState = System.Windows.Forms.FormWindowState.Maximized;
    Load += Form1_Load;
    menuStrip.ResumeLayout(false);
    menuStrip.PerformLayout();
    ResumeLayout(false);
    PerformLayout();
    }

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem btnForm2;
        private System.Windows.Forms.ToolStripMenuItem btnForm3;
    private System.Windows.Forms.ToolStripMenuItem btnFormGrafico;
    #endregion
}