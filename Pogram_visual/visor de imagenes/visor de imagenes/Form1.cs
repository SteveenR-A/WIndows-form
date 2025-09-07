namespace visor_de_imagenes;

public partial class Form1 : Form
{
    // Ruta de la carpeta de imágenes
    private readonly string imagenesFolder = @"C:\Users\herna\RiderProjects\WIndows-form\Pogram_visual\visor de imagenes\visor de imagenes\Imagenes";
    private List<string> imagenes = new List<string>();
    private int imagenActual = -1;
    // Estado de modo de visión y tamaño
    private string modoVision = "Normal";
    private string modoTamano = "Centrada";

    public Form1()
    {
    InitializeComponent();
    CargarImagenes();
    comboBoxImages.SelectedIndexChanged += comboBoxImages_SelectedIndexChanged;

    // Menú Archivo
    guardarMenu.Click += guardarMenu_Click;
    salirMenu.Click += salirMenu_Click;

    // Menú Visión
    normalVisionMenu.Click += visionMenu_Click;
    grisVisionMenu.Click += visionMenu_Click;

    // Menú Tamaño
    centradaTamanoMenu.Click += tamanoMenu_Click;
    ajustarTamanoMenu.Click += tamanoMenu_Click;
    zoomTamanoMenu.Click += tamanoMenu_Click;

    // Barra de herramientas
    toolStripNormalVision.Click += visionMenu_Click;
    toolStripGrisVision.Click += visionMenu_Click;
    toolStripCentradaTamano.Click += tamanoMenu_Click;
    toolStripAjustarTamano.Click += tamanoMenu_Click;
    toolStripZoomTamano.Click += tamanoMenu_Click;

    // Menú contextual
    girarIzquierdaMenu.Click += girarIzquierdaMenu_Click;
    girarDerechaMenu.Click += girarDerechaMenu_Click;
    copiarMenu.Click += copiarMenu_Click;
    }

    private void CargarImagenes()
    {
        if (Directory.Exists(imagenesFolder))
        {
            var extensiones = new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
            imagenes = Directory.GetFiles(imagenesFolder)
                .Where(f => extensiones.Contains(Path.GetExtension(f).ToLower()))
                .ToList();
            comboBoxImages.Items.Clear();
            foreach (var img in imagenes)
            {
                comboBoxImages.Items.Add(Path.GetFileName(img));
            }
            if (imagenes.Count > 0)
            {
                comboBoxImages.SelectedIndex = -1; // No selecciona ninguna imagen por defecto
                pictureBox.Image = null; // No muestra imagen por defecto
            }
        }
    }

    private void MostrarImagen(int index)
    {
        if (index >= 0 && index < imagenes.Count)
        {
            pictureBox.Image = Image.FromFile(imagenes[index]);
            imagenActual = index;
            comboBoxImages.SelectedIndex = index;
        }
    }

    // Evento para seleccionar imagen desde el ComboBox
    private void comboBoxImages_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboBoxImages.SelectedIndex >= 0)
        {
            MostrarImagen(comboBoxImages.SelectedIndex);
        }
    }

    // Guardar imagen actual
    private void guardarMenu_Click(object? sender, EventArgs e)
    {
        if (imagenActual >= 0 && imagenActual < imagenes.Count && pictureBox.Image != null)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                sfd.FileName = Path.GetFileName(imagenes[imagenActual]);
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image.Save(sfd.FileName);
                }
            }
        }
    }

    // Salir de la aplicación
    private void salirMenu_Click(object? sender, EventArgs e)
    {
        Application.Exit();
    }

    // Cambiar modo de visión (Normal/Gris)
    private void visionMenu_Click(object? sender, EventArgs e)
    {
        if (sender == normalVisionMenu || sender == toolStripNormalVision)
            modoVision = "Normal";
        else if (sender == grisVisionMenu || sender == toolStripGrisVision)
            modoVision = "Gris";
        SincronizarVision();
    }

    // Cambiar modo de tamaño (Centrada/Ajustar/Zoom)
    private void tamanoMenu_Click(object? sender, EventArgs e)
    {
        if (sender == centradaTamanoMenu || sender == toolStripCentradaTamano)
            modoTamano = "Centrada";
        else if (sender == ajustarTamanoMenu || sender == toolStripAjustarTamano)
            modoTamano = "Ajustar";
        else if (sender == zoomTamanoMenu || sender == toolStripZoomTamano)
            modoTamano = "Zoom";
        SincronizarTamano();
    }

    // Sincronizar modo de visión entre menú y barra de herramientas
    private void SincronizarVision()
    {
        normalVisionMenu.Checked = modoVision == "Normal";
        grisVisionMenu.Checked = modoVision == "Gris";
        toolStripNormalVision.Checked = modoVision == "Normal";
        toolStripGrisVision.Checked = modoVision == "Gris";
        // Aplicar efecto visual si es necesario
        if (pictureBox.Image != null)
        {
            if (modoVision == "Gris")
            {
                var bmp = new Bitmap(pictureBox.Image);
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        var c = bmp.GetPixel(x, y);
                        int g = (int)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                        bmp.SetPixel(x, y, Color.FromArgb(g, g, g));
                    }
                }
                pictureBox.Image = bmp;
            }
            else
            {
                MostrarImagen(imagenActual);
            }
        }
    }

    // Sincronizar modo de tamaño entre menú y barra de herramientas
    private void SincronizarTamano()
    {
        centradaTamanoMenu.Checked = modoTamano == "Centrada";
        ajustarTamanoMenu.Checked = modoTamano == "Ajustar";
        zoomTamanoMenu.Checked = modoTamano == "Zoom";
        toolStripCentradaTamano.Checked = modoTamano == "Centrada";
        toolStripAjustarTamano.Checked = modoTamano == "Ajustar";
        toolStripZoomTamano.Checked = modoTamano == "Zoom";
        // Cambiar el modo de visualización del PictureBox
        if (modoTamano == "Centrada")
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
        else if (modoTamano == "Ajustar")
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        else if (modoTamano == "Zoom")
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
    }

    // Girar imagen 90° a la izquierda
    private void girarIzquierdaMenu_Click(object? sender, EventArgs e)
    {
        if (pictureBox.Image != null)
        {
            pictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox.Refresh();
        }
    }

    // Girar imagen 90° a la derecha
    private void girarDerechaMenu_Click(object? sender, EventArgs e)
    {
        if (pictureBox.Image != null)
        {
            pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox.Refresh();
        }
    }

    // Copiar imagen al portapapeles
    private void copiarMenu_Click(object? sender, EventArgs e)
    {
        if (pictureBox.Image != null)
        {
            Clipboard.SetImage(pictureBox.Image);
        }
    }
    }
