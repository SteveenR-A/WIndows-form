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
            this.login = new System.Windows.Forms.Label();
            this.User = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.Ususario = new System.Windows.Forms.TextBox();
            this.contrasena = new System.Windows.Forms.TextBox();
            this.iniciarsesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // login
            // 
            this.login.AutoSize = true;
            this.login.BackColor = System.Drawing.SystemColors.Highlight;
            this.login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.login.Location = new System.Drawing.Point(220, 51);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(71, 25);
            this.login.TabIndex = 0;
            this.login.Text = "Login ";
            this.login.Click += new System.EventHandler(this.label1_Click);
            // 
            // User
            // 
            this.User.AutoSize = true;
            this.User.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.User.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.User.Location = new System.Drawing.Point(42, 109);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(48, 22);
            this.User.TabIndex = 1;
            this.User.Text = "User";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.BackColor = System.Drawing.SystemColors.Highlight;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.password.Location = new System.Drawing.Point(42, 162);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(89, 22);
            this.password.TabIndex = 2;
            this.password.Text = "Password";
            // 
            // Ususario
            // 
            this.Ususario.Location = new System.Drawing.Point(160, 111);
            this.Ususario.Name = "Ususario";
            this.Ususario.Size = new System.Drawing.Size(167, 20);
            this.Ususario.TabIndex = 3;
            this.Ususario.TextChanged += new System.EventHandler(this.Ususario_TextChanged);
            // 
            // contrasena
            // 
            this.contrasena.Location = new System.Drawing.Point(163, 157);
            this.contrasena.Name = "contrasena";
            this.contrasena.PasswordChar = '#';
            this.contrasena.Size = new System.Drawing.Size(163, 20);
            this.contrasena.TabIndex = 4;
            // 
            // iniciarsesion
            // 
            this.iniciarsesion.BackColor = System.Drawing.SystemColors.HotTrack;
            this.iniciarsesion.Location = new System.Drawing.Point(194, 227);
            this.iniciarsesion.Name = "iniciarsesion";
            this.iniciarsesion.Size = new System.Drawing.Size(159, 32);
            this.iniciarsesion.TabIndex = 5;
            this.iniciarsesion.Text = "Iniciar sesion";
            this.iniciarsesion.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 344);
            this.Controls.Add(this.iniciarsesion);
            this.Controls.Add(this.contrasena);
            this.Controls.Add(this.Ususario);
            this.Controls.Add(this.password);
            this.Controls.Add(this.User);
            this.Controls.Add(this.login);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label login;
        private System.Windows.Forms.Label User;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox Ususario;
        private System.Windows.Forms.TextBox contrasena;
        private System.Windows.Forms.Button iniciarsesion;
    }
}

