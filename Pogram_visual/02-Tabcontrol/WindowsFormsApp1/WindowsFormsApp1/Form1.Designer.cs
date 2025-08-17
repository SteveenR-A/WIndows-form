namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.boton = new System.Windows.Forms.Button();
            this.Altura1 = new System.Windows.Forms.Label();
            this.Peso2 = new System.Windows.Forms.Label();
            this.altura = new System.Windows.Forms.TextBox();
            this.Peso = new System.Windows.Forms.TextBox();
            this.IMC = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.c_Fahrenheit = new System.Windows.Forms.TextBox();
            this.c_Celsius = new System.Windows.Forms.TextBox();
            this.l_Fahrenheit = new System.Windows.Forms.Label();
            this.l_Celsius = new System.Windows.Forms.Label();
            this.l_grados = new System.Windows.Forms.Label();
            this.boton_grados = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.l_count = new System.Windows.Forms.Label();
            this.b_count = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(278, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage1.Controls.Add(this.boton);
            this.tabPage1.Controls.Add(this.Altura1);
            this.tabPage1.Controls.Add(this.Peso2);
            this.tabPage1.Controls.Add(this.altura);
            this.tabPage1.Controls.Add(this.Peso);
            this.tabPage1.Controls.Add(this.IMC);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(270, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // boton
            // 
            this.boton.BackColor = System.Drawing.Color.RoyalBlue;
            this.boton.Location = new System.Drawing.Point(95, 257);
            this.boton.Name = "boton";
            this.boton.Size = new System.Drawing.Size(81, 27);
            this.boton.TabIndex = 5;
            this.boton.Text = "Calcular";
            this.boton.UseVisualStyleBackColor = false;
            this.boton.Click += new System.EventHandler(this.boton_Click);
            // 
            // Altura1
            // 
            this.Altura1.AutoSize = true;
            this.Altura1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Altura1.Location = new System.Drawing.Point(30, 136);
            this.Altura1.Name = "Altura1";
            this.Altura1.Size = new System.Drawing.Size(34, 13);
            this.Altura1.TabIndex = 4;
            this.Altura1.Text = "Altura";
            // 
            // Peso2
            // 
            this.Peso2.AutoSize = true;
            this.Peso2.BackColor = System.Drawing.Color.SteelBlue;
            this.Peso2.Location = new System.Drawing.Point(33, 84);
            this.Peso2.Name = "Peso2";
            this.Peso2.Size = new System.Drawing.Size(31, 13);
            this.Peso2.TabIndex = 3;
            this.Peso2.Text = "Peso";
            // 
            // altura
            // 
            this.altura.BackColor = System.Drawing.SystemColors.Window;
            this.altura.Location = new System.Drawing.Point(95, 133);
            this.altura.Name = "altura";
            this.altura.Size = new System.Drawing.Size(81, 20);
            this.altura.TabIndex = 2;
            // 
            // Peso
            // 
            this.Peso.BackColor = System.Drawing.SystemColors.Window;
            this.Peso.Location = new System.Drawing.Point(95, 84);
            this.Peso.Name = "Peso";
            this.Peso.Size = new System.Drawing.Size(80, 20);
            this.Peso.TabIndex = 1;
            // 
            // IMC
            // 
            this.IMC.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.IMC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.IMC.Location = new System.Drawing.Point(110, 35);
            this.IMC.Name = "IMC";
            this.IMC.Size = new System.Drawing.Size(37, 26);
            this.IMC.TabIndex = 0;
            this.IMC.Text = "IMC";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage2.Controls.Add(this.c_Fahrenheit);
            this.tabPage2.Controls.Add(this.c_Celsius);
            this.tabPage2.Controls.Add(this.l_Fahrenheit);
            this.tabPage2.Controls.Add(this.l_Celsius);
            this.tabPage2.Controls.Add(this.l_grados);
            this.tabPage2.Controls.Add(this.boton_grados);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(270, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // c_Fahrenheit
            // 
            this.c_Fahrenheit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.c_Fahrenheit.Location = new System.Drawing.Point(138, 137);
            this.c_Fahrenheit.Name = "c_Fahrenheit";
            this.c_Fahrenheit.Size = new System.Drawing.Size(56, 20);
            this.c_Fahrenheit.TabIndex = 5;
            // 
            // c_Celsius
            // 
            this.c_Celsius.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.c_Celsius.Location = new System.Drawing.Point(31, 137);
            this.c_Celsius.Name = "c_Celsius";
            this.c_Celsius.Size = new System.Drawing.Size(56, 20);
            this.c_Celsius.TabIndex = 4;
            // 
            // l_Fahrenheit
            // 
            this.l_Fahrenheit.BackColor = System.Drawing.Color.LightBlue;
            this.l_Fahrenheit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.l_Fahrenheit.Location = new System.Drawing.Point(123, 87);
            this.l_Fahrenheit.Name = "l_Fahrenheit";
            this.l_Fahrenheit.Size = new System.Drawing.Size(107, 19);
            this.l_Fahrenheit.TabIndex = 3;
            this.l_Fahrenheit.Text = "Fahrenheit ";
            // 
            // l_Celsius
            // 
            this.l_Celsius.BackColor = System.Drawing.Color.LightBlue;
            this.l_Celsius.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.l_Celsius.Location = new System.Drawing.Point(31, 87);
            this.l_Celsius.Name = "l_Celsius";
            this.l_Celsius.Size = new System.Drawing.Size(67, 19);
            this.l_Celsius.TabIndex = 2;
            this.l_Celsius.Text = "Celsius";
            // 
            // l_grados
            // 
            this.l_grados.BackColor = System.Drawing.Color.PowderBlue;
            this.l_grados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.l_grados.Location = new System.Drawing.Point(15, 26);
            this.l_grados.Name = "l_grados";
            this.l_grados.Size = new System.Drawing.Size(247, 21);
            this.l_grados.TabIndex = 1;
            this.l_grados.Text = "Conversor de temperatura";
            // 
            // boton_grados
            // 
            this.boton_grados.BackColor = System.Drawing.Color.LightSteelBlue;
            this.boton_grados.Location = new System.Drawing.Point(87, 260);
            this.boton_grados.Name = "boton_grados";
            this.boton_grados.Size = new System.Drawing.Size(74, 31);
            this.boton_grados.TabIndex = 0;
            this.boton_grados.Text = "Convertir";
            this.boton_grados.UseVisualStyleBackColor = false;
            this.boton_grados.Click += new System.EventHandler(this.boton_grados_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage3.Controls.Add(this.l_count);
            this.tabPage3.Controls.Add(this.b_count);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(270, 424);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // l_count
            // 
            this.l_count.BackColor = System.Drawing.Color.PowderBlue;
            this.l_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.l_count.Location = new System.Drawing.Point(108, 86);
            this.l_count.Name = "l_count";
            this.l_count.Size = new System.Drawing.Size(48, 26);
            this.l_count.TabIndex = 1;
            // 
            // b_count
            // 
            this.b_count.BackColor = System.Drawing.Color.PowderBlue;
            this.b_count.Location = new System.Drawing.Point(92, 182);
            this.b_count.Name = "b_count";
            this.b_count.Size = new System.Drawing.Size(79, 26);
            this.b_count.TabIndex = 0;
            this.b_count.Text = "Precionar";
            this.b_count.UseVisualStyleBackColor = false;
            this.b_count.Click += new System.EventHandler(this.b_count_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button boton;
        private System.Windows.Forms.Label Altura1;
        private System.Windows.Forms.Label Peso2;
        private System.Windows.Forms.TextBox altura;
        private System.Windows.Forms.TextBox Peso;
        private System.Windows.Forms.TextBox IMC;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox c_Fahrenheit;
        private System.Windows.Forms.TextBox c_Celsius;
        private System.Windows.Forms.Label l_Fahrenheit;
        private System.Windows.Forms.Label l_Celsius;
        private System.Windows.Forms.Label l_grados;
        private System.Windows.Forms.Button boton_grados;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label l_count;
        private System.Windows.Forms.Button b_count;
    }
}
