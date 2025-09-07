
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox = new System.Windows.Forms.PictureBox();
            contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            girarIzquierdaMenu = new System.Windows.Forms.ToolStripMenuItem();
            girarDerechaMenu = new System.Windows.Forms.ToolStripMenuItem();
            copiarMenu = new System.Windows.Forms.ToolStripMenuItem();
            comboBoxImages = new System.Windows.Forms.ComboBox();
            btnFirst = new System.Windows.Forms.Button();
            btnPrev = new System.Windows.Forms.Button();
            btnNext = new System.Windows.Forms.Button();
            btnLast = new System.Windows.Forms.Button();
            statusStrip = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            menuStrip = new System.Windows.Forms.MenuStrip();
            archivoMenu = new System.Windows.Forms.ToolStripMenuItem();
            guardarMenu = new System.Windows.Forms.ToolStripMenuItem();
            salirMenu = new System.Windows.Forms.ToolStripMenuItem();
            visionMenu = new System.Windows.Forms.ToolStripMenuItem();
            normalVisionMenu = new System.Windows.Forms.ToolStripMenuItem();
            grisVisionMenu = new System.Windows.Forms.ToolStripMenuItem();
            tamanoMenu = new System.Windows.Forms.ToolStripMenuItem();
            centradaTamanoMenu = new System.Windows.Forms.ToolStripMenuItem();
            ajustarTamanoMenu = new System.Windows.Forms.ToolStripMenuItem();
            zoomTamanoMenu = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip = new System.Windows.Forms.ToolStrip();
            toolStripNormalVision = new System.Windows.Forms.ToolStripButton();
            toolStripGrisVision = new System.Windows.Forms.ToolStripButton();
            toolStripCentradaTamano = new System.Windows.Forms.ToolStripButton();
            toolStripAjustarTamano = new System.Windows.Forms.ToolStripButton();
            toolStripZoomTamano = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            contextMenuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            toolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.ContextMenuStrip = contextMenuStrip;
            pictureBox.Location = new System.Drawing.Point(12, 106);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(428, 300);
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { girarIzquierdaMenu, girarDerechaMenu, copiarMenu });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new System.Drawing.Size(193, 70);
            // 
            // girarIzquierdaMenu
            // 
            girarIzquierdaMenu.Name = "girarIzquierdaMenu";
            girarIzquierdaMenu.Size = new System.Drawing.Size(192, 22);
            girarIzquierdaMenu.Text = "Girar 90° Izquierda";
            // 
            // girarDerechaMenu
            // 
            girarDerechaMenu.Name = "girarDerechaMenu";
            girarDerechaMenu.Size = new System.Drawing.Size(192, 22);
            girarDerechaMenu.Text = "Girar 90° Derecha";
            // 
            // copiarMenu
            // 
            copiarMenu.Name = "copiarMenu";
            copiarMenu.Size = new System.Drawing.Size(192, 22);
            copiarMenu.Text = "Copiar al portapapeles";
            // 
            // comboBoxImages
            // 
            comboBoxImages.Location = new System.Drawing.Point(12, 52);
            comboBoxImages.Name = "comboBoxImages";
            comboBoxImages.Size = new System.Drawing.Size(300, 23);
            comboBoxImages.TabIndex = 2;
            // 
            // btnFirst
            // 
            btnFirst.Location = new System.Drawing.Point(319, 51);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new System.Drawing.Size(30, 23);
            btnFirst.TabIndex = 3;
            btnFirst.Text = "<<";
            // 
            // btnPrev
            // 
            btnPrev.Location = new System.Drawing.Point(355, 51);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new System.Drawing.Size(30, 23);
            btnPrev.TabIndex = 4;
            btnPrev.Text = "<";
            // 
            // btnNext
            // 
            btnNext.Location = new System.Drawing.Point(391, 51);
            btnNext.Name = "btnNext";
            btnNext.Size = new System.Drawing.Size(30, 23);
            btnNext.TabIndex = 5;
            btnNext.Text = ">";
            // 
            // btnLast
            // 
            btnLast.Location = new System.Drawing.Point(427, 51);
            btnLast.Name = "btnLast";
            btnLast.Size = new System.Drawing.Size(30, 23);
            btnLast.TabIndex = 6;
            btnLast.Text = ">>";
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new System.Drawing.Point(0, 428);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new System.Drawing.Size(554, 22);
            statusStrip.TabIndex = 7;
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { archivoMenu, visionMenu, tamanoMenu });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new System.Drawing.Size(554, 24);
            menuStrip.TabIndex = 9;
            // 
            // archivoMenu
            // 
            archivoMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { guardarMenu, salirMenu });
            archivoMenu.Name = "archivoMenu";
            archivoMenu.Size = new System.Drawing.Size(60, 20);
            archivoMenu.Text = "Archivo";
            // 
            // guardarMenu
            // 
            guardarMenu.Name = "guardarMenu";
            guardarMenu.Size = new System.Drawing.Size(116, 22);
            guardarMenu.Text = "Guardar";
            // 
            // salirMenu
            // 
            salirMenu.Name = "salirMenu";
            salirMenu.Size = new System.Drawing.Size(116, 22);
            salirMenu.Text = "Salir";
            // 
            // visionMenu
            // 
            visionMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { normalVisionMenu, grisVisionMenu });
            visionMenu.Name = "visionMenu";
            visionMenu.Size = new System.Drawing.Size(51, 20);
            visionMenu.Text = "Visión";
            // 
            // normalVisionMenu
            // 
            normalVisionMenu.Name = "normalVisionMenu";
            normalVisionMenu.Size = new System.Drawing.Size(114, 22);
            normalVisionMenu.Text = "Normal";
            // 
            // grisVisionMenu
            // 
            grisVisionMenu.Name = "grisVisionMenu";
            grisVisionMenu.Size = new System.Drawing.Size(114, 22);
            grisVisionMenu.Text = "Gris";
            // 
            // tamanoMenu
            // 
            tamanoMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { centradaTamanoMenu, ajustarTamanoMenu, zoomTamanoMenu });
            tamanoMenu.Name = "tamanoMenu";
            tamanoMenu.Size = new System.Drawing.Size(62, 20);
            tamanoMenu.Text = "Tamaño";
            // 
            // centradaTamanoMenu
            // 
            centradaTamanoMenu.Name = "centradaTamanoMenu";
            centradaTamanoMenu.Size = new System.Drawing.Size(122, 22);
            centradaTamanoMenu.Text = "Centrada";
            // 
            // ajustarTamanoMenu
            // 
            ajustarTamanoMenu.Name = "ajustarTamanoMenu";
            ajustarTamanoMenu.Size = new System.Drawing.Size(122, 22);
            ajustarTamanoMenu.Text = "Ajustar";
            // 
            // zoomTamanoMenu
            // 
            zoomTamanoMenu.Name = "zoomTamanoMenu";
            zoomTamanoMenu.Size = new System.Drawing.Size(122, 22);
            zoomTamanoMenu.Text = "Zoom";
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripNormalVision, toolStripGrisVision, toolStripCentradaTamano, toolStripAjustarTamano, toolStripZoomTamano });
            toolStrip.Location = new System.Drawing.Point(0, 24);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new System.Drawing.Size(554, 25);
            toolStrip.TabIndex = 8;
            // 
            // toolStripNormalVision
            // 
            toolStripNormalVision.Name = "toolStripNormalVision";
            toolStripNormalVision.Size = new System.Drawing.Size(51, 22);
            toolStripNormalVision.Text = "Normal";
            // 
            // toolStripGrisVision
            // 
            toolStripGrisVision.Name = "toolStripGrisVision";
            toolStripGrisVision.Size = new System.Drawing.Size(31, 22);
            toolStripGrisVision.Text = "Gris";
            // 
            // toolStripCentradaTamano
            // 
            toolStripCentradaTamano.Name = "toolStripCentradaTamano";
            toolStripCentradaTamano.Size = new System.Drawing.Size(59, 22);
            toolStripCentradaTamano.Text = "Centrada";
            // 
            // toolStripAjustarTamano
            // 
            toolStripAjustarTamano.Name = "toolStripAjustarTamano";
            toolStripAjustarTamano.Size = new System.Drawing.Size(48, 22);
            toolStripAjustarTamano.Text = "Ajustar";
            // 
            // toolStripZoomTamano
            // 
            toolStripZoomTamano.Name = "toolStripZoomTamano";
            toolStripZoomTamano.Size = new System.Drawing.Size(43, 22);
            toolStripZoomTamano.Text = "Zoom";
            // 
            // Form1
            // 
            ClientSize = new System.Drawing.Size(554, 450);
            Controls.Add(pictureBox);
            Controls.Add(comboBoxImages);
            Controls.Add(btnFirst);
            Controls.Add(btnPrev);
            Controls.Add(btnNext);
            Controls.Add(btnLast);
            Controls.Add(statusStrip);
            Controls.Add(toolStrip);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Text = "Visor de Imágenes";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            contextMenuStrip.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}