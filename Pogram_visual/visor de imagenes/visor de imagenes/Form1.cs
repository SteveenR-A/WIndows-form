namespace visor_de_imagenes;

public partial class Form1 : Form
{
    // Ruta de la carpeta de imágenes
    private readonly string imagenesFolder = @"C:\Users\herna\RiderProjects\WIndows-form\Pogram_visual\visor de imagenes\visor de imagenes\Imagenes";
    private List<string> imagenes = new List<string>();
    private int imagenActual = 0;

    public Form1()
    {
        InitializeComponent();
        CargarImagenes();
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
                comboBoxImages.SelectedIndex = 0;
                MostrarImagen(0);
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
    }
