namespace OrdenamientoMultihilo
{
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.progressBurbuja = new System.Windows.Forms.ProgressBar();
            this.progressQuickSort = new System.Windows.Forms.ProgressBar();
            this.lblBurbuja = new System.Windows.Forms.Label();
            this.lblQuickSort = new System.Windows.Forms.Label();
            this.lblMergeSort = new System.Windows.Forms.Label();
            this.lblSelectionSort = new System.Windows.Forms.Label();
            this.progressMergeSort = new System.Windows.Forms.ProgressBar();
            this.progressSelectionSort = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerQuickSort = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerMergeSort = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSelectionSort = new System.ComponentModel.BackgroundWorker();
            this.btnDetener = new System.Windows.Forms.Button();
            this.numericCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.chartTiempos = new System.Windows.Forms.PictureBox();
            this.listBoxBurbuja = new System.Windows.Forms.ListBox();
            this.listBoxQuick = new System.Windows.Forms.ListBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnOrdenar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.LightBlue;
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.Location = new System.Drawing.Point(30, 60);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(140, 38);
            this.btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnGenerar.TabIndex = 0;
            this.btnGenerar.Text = "Generar Datos";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.LightGreen;
            this.btnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnIniciar.Location = new System.Drawing.Point(180, 60);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(200, 38);
            this.btnIniciar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnIniciar.TabIndex = 1;
            this.btnIniciar.Text = "Iniciar Ordenamiento";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // progressBurbuja
            // 
            this.progressBurbuja.Location = new System.Drawing.Point(30, 140);
            this.progressBurbuja.Name = "progressBurbuja";
            this.progressBurbuja.Size = new System.Drawing.Size(640, 22);
            this.progressBurbuja.TabIndex = 2;
            this.progressBurbuja.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            // 
            // progressQuickSort
            // 
            this.progressQuickSort.Location = new System.Drawing.Point(30, 190);
            this.progressQuickSort.Name = "progressQuickSort";
            this.progressQuickSort.Size = new System.Drawing.Size(640, 22);
            this.progressQuickSort.TabIndex = 3;
            this.progressQuickSort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            // 
            // lblBurbuja
            // 
            this.lblBurbuja.AutoSize = true;
            this.lblBurbuja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblBurbuja.Location = new System.Drawing.Point(30, 120);
            this.lblBurbuja.Name = "lblBurbuja";
            this.lblBurbuja.Size = new System.Drawing.Size(77, 17);
            this.lblBurbuja.TabIndex = 4;
            this.lblBurbuja.Text = "Burbuja: 0%";
            // 
            // lblQuickSort
            // 
            this.lblQuickSort.AutoSize = true;
            this.lblQuickSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblQuickSort.Location = new System.Drawing.Point(30, 170);
            this.lblQuickSort.Name = "lblQuickSort";
            this.lblQuickSort.Size = new System.Drawing.Size(92, 17);
            this.lblQuickSort.TabIndex = 5;
            this.lblQuickSort.Text = "QuickSort: 0%";
            // 
            // lblMergeSort
            // 
            this.lblMergeSort.AutoSize = true;
            this.lblMergeSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblMergeSort.Location = new System.Drawing.Point(30, 220);
            this.lblMergeSort.Name = "lblMergeSort";
            this.lblMergeSort.Size = new System.Drawing.Size(92, 17);
            this.lblMergeSort.TabIndex = 5;
            this.lblMergeSort.Text = "MergeSort: 0%";
            // 
            // lblSelectionSort
            // 
            this.lblSelectionSort.AutoSize = true;
            this.lblSelectionSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblSelectionSort.Location = new System.Drawing.Point(30, 270);
            this.lblSelectionSort.Name = "lblSelectionSort";
            this.lblSelectionSort.Size = new System.Drawing.Size(102, 17);
            this.lblSelectionSort.TabIndex = 5;
            this.lblSelectionSort.Text = "SelectionSort: 0%";
            // 
            // progressMergeSort
            // 
            this.progressMergeSort.Location = new System.Drawing.Point(30, 240);
            this.progressMergeSort.Name = "progressMergeSort";
            this.progressMergeSort.Size = new System.Drawing.Size(640, 22);
            this.progressMergeSort.TabIndex = 3;
            this.progressMergeSort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            // 
            // progressSelectionSort
            // 
            this.progressSelectionSort.Location = new System.Drawing.Point(30, 290);
            this.progressSelectionSort.Name = "progressSelectionSort";
            this.progressSelectionSort.Size = new System.Drawing.Size(640, 22);
            this.progressSelectionSort.TabIndex = 3;
            this.progressSelectionSort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            // 
            // backgroundWorkerQuickSort
            // 
            this.backgroundWorkerQuickSort.WorkerReportsProgress = true;
            this.backgroundWorkerQuickSort.WorkerSupportsCancellation = false;
            this.backgroundWorkerQuickSort.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerQuickSort_DoWork);
            this.backgroundWorkerQuickSort.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerQuickSort_ProgressChanged);
            this.backgroundWorkerQuickSort.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerQuickSort_RunWorkerCompleted);
            // 
            // backgroundWorkerMergeSort
            // 
            this.backgroundWorkerMergeSort.WorkerReportsProgress = true;
            this.backgroundWorkerMergeSort.WorkerSupportsCancellation = true;
            this.backgroundWorkerMergeSort.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerMergeSort_DoWork);
            this.backgroundWorkerMergeSort.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerMergeSort_ProgressChanged);
            this.backgroundWorkerMergeSort.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerMergeSort_RunWorkerCompleted);
            // 
            // backgroundWorkerSelectionSort
            // 
            this.backgroundWorkerSelectionSort.WorkerReportsProgress = true;
            this.backgroundWorkerSelectionSort.WorkerSupportsCancellation = true;
            this.backgroundWorkerSelectionSort.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSelectionSort_DoWork);
            this.backgroundWorkerSelectionSort.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerSelectionSort_ProgressChanged);
            this.backgroundWorkerSelectionSort.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSelectionSort_RunWorkerCompleted);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(980, 32);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Ordenamiento Multihilo - Demo";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDetener
            // 
            this.btnDetener.BackColor = System.Drawing.Color.LightCoral;
            this.btnDetener.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnDetener.Location = new System.Drawing.Point(400, 60);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(120, 38);
            this.btnDetener.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnDetener.TabIndex = 7;
            this.btnDetener.Text = "Detener";
            this.btnDetener.UseVisualStyleBackColor = false;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // numericCantidad
            // 
            this.numericCantidad.Location = new System.Drawing.Point(120, 60);
            this.numericCantidad.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numericCantidad.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numericCantidad.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numericCantidad.Value = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numericCantidad.Name = "numericCantidad";
            this.numericCantidad.Size = new System.Drawing.Size(120, 23);
            this.numericCantidad.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(30, 64);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(80, 15);
            this.lblCantidad.Text = "Cantidad:";
            // 
            // chartTiempos
            // 
            this.chartTiempos.Location = new System.Drawing.Point(30, 330);
            this.chartTiempos.Name = "chartTiempos";
            this.chartTiempos.Size = new System.Drawing.Size(640, 280);
            this.chartTiempos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chartTiempos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chartTiempos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            // 
            // listBoxBurbuja
            // 
            this.listBoxBurbuja.Location = new System.Drawing.Point(700, 140);
            this.listBoxBurbuja.Name = "listBoxBurbuja";
            this.listBoxBurbuja.Size = new System.Drawing.Size(300, 120);
            this.listBoxBurbuja.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            // 
            // listBoxQuick
            // 
            this.listBoxQuick.Location = new System.Drawing.Point(700, 270);
            this.listBoxQuick.Name = "listBoxQuick";
            this.listBoxQuick.Size = new System.Drawing.Size(300, 120);
            this.listBoxQuick.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            // 
            // btnOrdenar
            // 
            this.btnOrdenar.BackColor = System.Drawing.Color.LightYellow;
            this.btnOrdenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnOrdenar.Location = new System.Drawing.Point(620, 60);
            this.btnOrdenar.Name = "btnOrdenar";
            this.btnOrdenar.Size = new System.Drawing.Size(120, 38);
            this.btnOrdenar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnOrdenar.TabIndex = 8;
            this.btnOrdenar.Text = "Ordenar";
            this.btnOrdenar.UseVisualStyleBackColor = false;
            this.btnOrdenar.Click += new System.EventHandler(this.btnOrdenar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.LightGray;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Location = new System.Drawing.Point(760, 60);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 38);
            this.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // numCantidad
            // 
            this.numCantidad.Location = new System.Drawing.Point(120, 60);
            this.numCantidad.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numCantidad.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numCantidad.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numCantidad.Value = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(120, 23);
            this.numCantidad.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(30, 64);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(80, 15);
            this.lblCantidad.Text = "Cantidad:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 640);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblQuickSort);
            this.Controls.Add(this.lblMergeSort);
            this.Controls.Add(this.lblSelectionSort);
            this.Controls.Add(this.lblBurbuja);
            this.Controls.Add(this.progressQuickSort);
            this.Controls.Add(this.progressMergeSort);
            this.Controls.Add(this.progressSelectionSort);
            this.Controls.Add(this.progressBurbuja);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.numericCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.chartTiempos);
            this.Controls.Add(this.listBoxBurbuja);
            this.Controls.Add(this.listBoxQuick);
            this.Controls.Add(this.btnOrdenar);
            this.Controls.Add(this.btnLimpiar);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenamiento Multihilo";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.ProgressBar progressBurbuja;
        private System.Windows.Forms.ProgressBar progressQuickSort;
        private System.Windows.Forms.Label lblBurbuja;
        private System.Windows.Forms.Label lblQuickSort;
        private System.Windows.Forms.Label lblMergeSort;
        private System.Windows.Forms.Label lblSelectionSort;
        private System.Windows.Forms.ProgressBar progressMergeSort;
        private System.Windows.Forms.ProgressBar progressSelectionSort;
        private System.ComponentModel.BackgroundWorker backgroundWorkerQuickSort;
    private System.ComponentModel.BackgroundWorker backgroundWorkerMergeSort;
    private System.ComponentModel.BackgroundWorker backgroundWorkerSelectionSort;
    private System.Windows.Forms.Button btnDetener;
    private System.Windows.Forms.NumericUpDown numericCantidad;
    private System.Windows.Forms.Label lblCantidad;
    private System.Windows.Forms.PictureBox chartTiempos;
    private System.Windows.Forms.ListBox listBoxBurbuja;
    private System.Windows.Forms.ListBox listBoxQuick;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnOrdenar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label lblCantidad;
    }
}