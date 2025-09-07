
namespace visor_de_imagenes
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Controles
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox comboBoxImages;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem archivoMenu;
        private System.Windows.Forms.ToolStripMenuItem guardarMenu;
        private System.Windows.Forms.ToolStripMenuItem salirMenu;
        private System.Windows.Forms.ToolStripMenuItem visionMenu;
        private System.Windows.Forms.ToolStripMenuItem normalVisionMenu;
        private System.Windows.Forms.ToolStripMenuItem grisVisionMenu;
        private System.Windows.Forms.ToolStripMenuItem tamanoMenu;
        private System.Windows.Forms.ToolStripMenuItem centradaTamanoMenu;
        private System.Windows.Forms.ToolStripMenuItem ajustarTamanoMenu;
        private System.Windows.Forms.ToolStripMenuItem zoomTamanoMenu;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripNormalVision;
        private System.Windows.Forms.ToolStripButton toolStripGrisVision;
        private System.Windows.Forms.ToolStripButton toolStripCentradaTamano;
        private System.Windows.Forms.ToolStripButton toolStripAjustarTamano;
        private System.Windows.Forms.ToolStripButton toolStripZoomTamano;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem girarIzquierdaMenu;
        private System.Windows.Forms.ToolStripMenuItem girarDerechaMenu;
        private System.Windows.Forms.ToolStripMenuItem copiarMenu;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.comboBoxImages = new System.Windows.Forms.ComboBox();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.archivoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.salirMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.visionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.normalVisionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.grisVisionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tamanoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.centradaTamanoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ajustarTamanoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomTamanoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripNormalVision = new System.Windows.Forms.ToolStripButton();
            this.toolStripGrisVision = new System.Windows.Forms.ToolStripButton();
            this.toolStripCentradaTamano = new System.Windows.Forms.ToolStripButton();
            this.toolStripAjustarTamano = new System.Windows.Forms.ToolStripButton();
            this.toolStripZoomTamano = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.girarIzquierdaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.girarDerechaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarMenu = new System.Windows.Forms.ToolStripMenuItem();

            // Configuración de controles
            this.SuspendLayout();

            // PictureBox
            this.pictureBox.Location = new System.Drawing.Point(12, 60);
            this.pictureBox.Size = new System.Drawing.Size(428, 300);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.ContextMenuStrip = this.contextMenuStrip;

            // ComboBox
            this.comboBoxImages.Location = new System.Drawing.Point(12, 30);
            this.comboBoxImages.Size = new System.Drawing.Size(300, 23);

            // Botones de navegación
            this.btnFirst.Text = "<<";
            this.btnFirst.Location = new System.Drawing.Point(320, 30);
            this.btnFirst.Size = new System.Drawing.Size(30, 23);
            this.btnPrev.Text = "<";
            this.btnPrev.Location = new System.Drawing.Point(355, 30);
            this.btnPrev.Size = new System.Drawing.Size(30, 23);
            this.btnNext.Text = ">";
            this.btnNext.Location = new System.Drawing.Point(390, 30);
            this.btnNext.Size = new System.Drawing.Size(30, 23);
            this.btnLast.Text = ">>";
            this.btnLast.Location = new System.Drawing.Point(425, 30);
            this.btnLast.Size = new System.Drawing.Size(30, 23);

            // StatusStrip
            this.statusStrip.Items.Add(this.toolStripStatusLabel);
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Size = new System.Drawing.Size(452, 22);

            // MenuStrip
            this.archivoMenu.Text = "Archivo";
            this.archivoMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.guardarMenu, this.salirMenu });
            this.guardarMenu.Text = "Guardar";
            this.salirMenu.Text = "Salir";

            this.visionMenu.Text = "Visión";
            this.visionMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.normalVisionMenu, this.grisVisionMenu });
            this.normalVisionMenu.Text = "Normal";
            this.grisVisionMenu.Text = "Gris";

            this.tamanoMenu.Text = "Tamaño";
            this.tamanoMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.centradaTamanoMenu, this.ajustarTamanoMenu, this.zoomTamanoMenu });
            this.centradaTamanoMenu.Text = "Centrada";
            this.ajustarTamanoMenu.Text = "Ajustar";
            this.zoomTamanoMenu.Text = "Zoom";

            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.archivoMenu, this.visionMenu, this.tamanoMenu });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Size = new System.Drawing.Size(452, 24);

            // ToolStrip (Barra de herramientas)
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.toolStripNormalVision,
                this.toolStripGrisVision,
                this.toolStripCentradaTamano,
                this.toolStripAjustarTamano,
                this.toolStripZoomTamano
            });
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Size = new System.Drawing.Size(452, 25);

            this.toolStripNormalVision.Text = "Normal";
            this.toolStripGrisVision.Text = "Gris";
            this.toolStripCentradaTamano.Text = "Centrada";
            this.toolStripAjustarTamano.Text = "Ajustar";
            this.toolStripZoomTamano.Text = "Zoom";

            // ContextMenuStrip (Menú contextual)
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.girarIzquierdaMenu,
                this.girarDerechaMenu,
                this.copiarMenu
            });
            this.girarIzquierdaMenu.Text = "Girar 90° Izquierda";
            this.girarDerechaMenu.Text = "Girar 90° Derecha";
            this.copiarMenu.Text = "Copiar al portapapeles";

            // Agregar controles al formulario
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.comboBoxImages);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;

            this.ClientSize = new System.Drawing.Size(452, 450);
            this.Text = "Visor de Imágenes";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}