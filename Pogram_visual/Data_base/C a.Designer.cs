namespace Data_base
{
    partial class C_a
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.txbContraNN = new System.Windows.Forms.TextBox();
            this.txbContraN = new System.Windows.Forms.TextBox();
            this.txbContra = new System.Windows.Forms.TextBox();
            this.btnGuard = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txbContraNN
            // 
            this.txbContraNN.Location = new System.Drawing.Point(290, 293);
            this.txbContraNN.Name = "txbContraNN";
            this.txbContraNN.Size = new System.Drawing.Size(232, 26);
            this.txbContraNN.TabIndex = 13;
            // 
            // txbContraN
            // 
            this.txbContraN.Location = new System.Drawing.Point(290, 194);
            this.txbContraN.Name = "txbContraN";
            this.txbContraN.Size = new System.Drawing.Size(226, 26);
            this.txbContraN.TabIndex = 12;
            // 
            // txbContra
            // 
            this.txbContra.Location = new System.Drawing.Point(290, 116);
            this.txbContra.Name = "txbContra";
            this.txbContra.Size = new System.Drawing.Size(233, 26);
            this.txbContra.TabIndex = 11;
            // 
            // btnGuard
            // 
            this.btnGuard.Location = new System.Drawing.Point(362, 334);
            this.btnGuard.Name = "btnGuard";
            this.btnGuard.Size = new System.Drawing.Size(84, 38);
            this.btnGuard.TabIndex = 10;
            this.btnGuard.Text = "Guardar";
            this.btnGuard.UseVisualStyleBackColor = true;
            this.btnGuard.Click += new System.EventHandler(this.btnGuard_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(278, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(232, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Ingrese de nuevo la contraseña";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(278, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(210, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Ingrese la nueva contraseña";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(278, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Ingrese su contraseña";
            // 
            // C_a
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txbContraNN);
            this.Controls.Add(this.txbContraN);
            this.Controls.Add(this.txbContra);
            this.Controls.Add(this.btnGuard);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Name = "C_a";
            this.Text = "C_a";
            this.Load += new System.EventHandler(this.C_a_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbContraNN;
        private System.Windows.Forms.TextBox txbContraN;
        private System.Windows.Forms.TextBox txbContra;
        private System.Windows.Forms.Button btnGuard;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}