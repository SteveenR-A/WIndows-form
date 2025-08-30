namespace GestorTareas;

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
        lblCodigo = new System.Windows.Forms.Label();
        txtCodigo = new System.Windows.Forms.TextBox();
        lblNombre = new System.Windows.Forms.Label();
        txtNombre = new System.Windows.Forms.TextBox();
        lblDescripcion = new System.Windows.Forms.Label();
        label1 = new System.Windows.Forms.Label();
        textBox1 = new System.Windows.Forms.TextBox();
        txtDescripcion = new System.Windows.Forms.TextBox();
        lblFecha = new System.Windows.Forms.Label();
        dtpFecha = new System.Windows.Forms.DateTimePicker();
        lblLugar = new System.Windows.Forms.Label();
        textLugar = new System.Windows.Forms.TextBox();
        lblEstado = new System.Windows.Forms.Label();
        cmbEstado = new System.Windows.Forms.ComboBox();
        btAgregar = new System.Windows.Forms.Button();
        btnEditar = new System.Windows.Forms.Button();
        btnEliminar = new System.Windows.Forms.Button();
        dgvTareas = new System.Windows.Forms.DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvTareas).BeginInit();
        SuspendLayout();
        // 
        // lblCodigo
        // 
        lblCodigo.Location = new System.Drawing.Point(57, 32);
        lblCodigo.Name = "lblCodigo";
        lblCodigo.Size = new System.Drawing.Size(67, 24);
        lblCodigo.TabIndex = 0;
        lblCodigo.Text = "Codigo";
        // 
        // txtCodigo
        // 
        txtCodigo.Location = new System.Drawing.Point(57, 59);
        txtCodigo.Name = "txtCodigo";
        txtCodigo.Size = new System.Drawing.Size(204, 23);
        txtCodigo.TabIndex = 1;
        // 
        // lblNombre
        // 
        lblNombre.Location = new System.Drawing.Point(291, 28);
        lblNombre.Name = "lblNombre";
        lblNombre.Size = new System.Drawing.Size(67, 28);
        lblNombre.TabIndex = 2;
        lblNombre.Text = "Nombre";
        // 
        // txtNombre
        // 
        txtNombre.BackColor = System.Drawing.SystemColors.InactiveCaption;
        txtNombre.Location = new System.Drawing.Point(291, 59);
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new System.Drawing.Size(204, 23);
        txtNombre.TabIndex = 3;
        // 
        // lblDescripcion
        // 
        lblDescripcion.Location = new System.Drawing.Point(59, 178);
        lblDescripcion.Name = "lblDescripcion";
        lblDescripcion.Size = new System.Drawing.Size(111, 28);
        lblDescripcion.TabIndex = 4;
        lblDescripcion.Text = "Descripcion";
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(82, 214);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(111, 28);
        label1.TabIndex = 4;
        label1.Visible = false;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(298, 214);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(204, 23);
        textBox1.TabIndex = 5;
        textBox1.Visible = false;
        // 
        // txtDescripcion
        // 
        txtDescripcion.BackColor = System.Drawing.SystemColors.InactiveCaption;
        txtDescripcion.Location = new System.Drawing.Point(57, 209);
        txtDescripcion.Multiline = true;
        txtDescripcion.Name = "txtDescripcion";
        txtDescripcion.Size = new System.Drawing.Size(204, 83);
        txtDescripcion.TabIndex = 5;
        // 
        // lblFecha
        // 
        lblFecha.Location = new System.Drawing.Point(307, 93);
        lblFecha.Name = "lblFecha";
        lblFecha.Size = new System.Drawing.Size(160, 28);
        lblFecha.TabIndex = 6;
        lblFecha.Text = "Fecha de Realizacion";
        // 
        // dtpFecha
        // 
        dtpFecha.Location = new System.Drawing.Point(298, 124);
        dtpFecha.Name = "dtpFecha";
        dtpFecha.Size = new System.Drawing.Size(169, 23);
        dtpFecha.TabIndex = 7;
        // 
        // lblLugar
        // 
        lblLugar.Location = new System.Drawing.Point(59, 93);
        lblLugar.Name = "lblLugar";
        lblLugar.Size = new System.Drawing.Size(160, 28);
        lblLugar.TabIndex = 8;
        lblLugar.Text = "Lugar\r\n\r\n";
        // 
        // textLugar
        // 
        textLugar.BackColor = System.Drawing.SystemColors.InactiveCaption;
        textLugar.Location = new System.Drawing.Point(57, 127);
        textLugar.Name = "textLugar";
        textLugar.Size = new System.Drawing.Size(204, 23);
        textLugar.TabIndex = 9;
        // 
        // lblEstado
        // 
        lblEstado.Location = new System.Drawing.Point(293, 178);
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new System.Drawing.Size(160, 28);
        lblEstado.TabIndex = 10;
        lblEstado.Text = "Estado";
        // 
        // cmbEstado
        // 
        cmbEstado.BackColor = System.Drawing.SystemColors.InactiveCaption;
        cmbEstado.FormattingEnabled = true;
        cmbEstado.Items.AddRange(new object[] { "No realizado", "En proceso", "Terminada" });
        cmbEstado.Location = new System.Drawing.Point(291, 209);
        cmbEstado.Name = "cmbEstado";
        cmbEstado.Size = new System.Drawing.Size(162, 23);
        cmbEstado.TabIndex = 11;
        // 
        // btAgregar
        // 
        btAgregar.Location = new System.Drawing.Point(57, 566);
        btAgregar.Name = "btAgregar";
        btAgregar.Size = new System.Drawing.Size(100, 34);
        btAgregar.TabIndex = 12;
        btAgregar.Text = "Agregar Tarea";
        btAgregar.UseVisualStyleBackColor = true;
        
        // 
        // btnEditar
        // 
        btnEditar.Location = new System.Drawing.Point(174, 566);
        btnEditar.Name = "btnEditar";
        btnEditar.Size = new System.Drawing.Size(100, 34);
        btnEditar.TabIndex = 13;
        btnEditar.Text = "Editar Tarea";
        btnEditar.UseVisualStyleBackColor = true;
        // 
        // btnEliminar
        // 
        btnEliminar.Location = new System.Drawing.Point(291, 566);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new System.Drawing.Size(100, 34);
        btnEliminar.TabIndex = 14;
        btnEliminar.Text = "Eliminar Tarea";
        btnEliminar.UseVisualStyleBackColor = true;
        // 
        // dgvTareas
        // 
        dgvTareas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvTareas.Location = new System.Drawing.Point(81, 427);
        dgvTareas.MultiSelect = false;
        dgvTareas.Name = "dgvTareas";
        dgvTareas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvTareas.Size = new System.Drawing.Size(204, 150);
        dgvTareas.TabIndex = 15;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(527, 749);
        Controls.Add(dgvTareas);
        Controls.Add(btnEliminar);
        Controls.Add(btnEditar);
        Controls.Add(btAgregar);
        Controls.Add(cmbEstado);
        Controls.Add(lblEstado);
        Controls.Add(textLugar);
        Controls.Add(lblLugar);
        Controls.Add(dtpFecha);
        Controls.Add(lblFecha);
        Controls.Add(txtDescripcion);
        Controls.Add(lblDescripcion);
        Controls.Add(txtNombre);
        Controls.Add(lblNombre);
        Controls.Add(txtCodigo);
        Controls.Add(lblCodigo);
        Location = new System.Drawing.Point(15, 15);
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)dgvTareas).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button btAgregar;
    private System.Windows.Forms.Button btnEditar;

    private System.Windows.Forms.Button btnEliminar;

    private System.Windows.Forms.ComboBox cmbEstado;

    private System.Windows.Forms.Label lblLugar;
    private System.Windows.Forms.TextBox textLugar;

    private System.Windows.Forms.Label lblEstado;

    private System.Windows.Forms.Label lblFecha;
    private System.Windows.Forms.DateTimePicker dtpFecha;

    private System.Windows.Forms.TextBox txtDescripcion;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.Label lblDescripcion;

    private System.Windows.Forms.TextBox txtNombre;

    private System.Windows.Forms.TextBox txtCodigo;
    private System.Windows.Forms.Label lblNombre;

    private System.Windows.Forms.Label lblCodigo;

    private System.Windows.Forms.DataGridView dgvTareas;

    #endregion
}

