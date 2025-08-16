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
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Peso2 = new System.Windows.Forms.Label();
            this.altura = new System.Windows.Forms.TextBox();
            this.Peso = new System.Windows.Forms.TextBox();
            this.IMC = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Altura1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Altura1);
            this.tabPage1.Controls.Add(this.Peso2);
            this.tabPage1.Controls.Add(this.altura);
            this.tabPage1.Controls.Add(this.Peso);
            this.tabPage1.Controls.Add(this.IMC);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(576, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // Peso2
            // 
            this.Peso2.AutoSize = true;
            this.Peso2.BackColor = System.Drawing.Color.SteelBlue;
            this.Peso2.Location = new System.Drawing.Point(67, 116);
            this.Peso2.Name = "Peso2";
            this.Peso2.Size = new System.Drawing.Size(31, 13);
            this.Peso2.TabIndex = 3;
            this.Peso2.Text = "Peso";
            // 
            // altura
            // 
            this.altura.BackColor = System.Drawing.SystemColors.Window;
            this.altura.Location = new System.Drawing.Point(126, 159);
            this.altura.Name = "altura";
            this.altura.Size = new System.Drawing.Size(81, 20);
            this.altura.TabIndex = 2;
            this.altura.TextChanged += new System.EventHandler(this.altura_TextChanged);
            // 
            // Peso
            // 
            this.Peso.BackColor = System.Drawing.SystemColors.Window;
            this.Peso.Location = new System.Drawing.Point(126, 113);
            this.Peso.Name = "Peso";
            this.Peso.Size = new System.Drawing.Size(80, 20);
            this.Peso.TabIndex = 1;
            this.Peso.TextChanged += new System.EventHandler(this.Peso1_TextChanged);
            // 
            // IMC
            // 
            this.IMC.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.IMC.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.IMC.Location = new System.Drawing.Point(126, 46);
            this.IMC.Name = "IMC";
            this.IMC.Size = new System.Drawing.Size(40, 27);
            this.IMC.TabIndex = 0;
            this.IMC.Text = "IMC";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(576, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Altura1
            // 
            this.Altura1.AutoSize = true;
            this.Altura1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Altura1.Location = new System.Drawing.Point(67, 166);
            this.Altura1.Name = "Altura1";
            this.Altura1.Size = new System.Drawing.Size(34, 13);
            this.Altura1.TabIndex = 4;
            this.Altura1.Text = "Altura";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox Peso;
        private System.Windows.Forms.TextBox IMC;
        private System.Windows.Forms.Label Peso2;
        private System.Windows.Forms.TextBox altura;
        private System.Windows.Forms.Label Altura1;
    }
}

