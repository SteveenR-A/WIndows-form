using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using System.Drawing;

namespace OrdenamientoMultihilo
{
    public partial class Form1 : Form
    {
    // ---------- Comentarios generales ----------
    // Este formulario contiene la interfaz para generar una lista de números aleatorios
    // y ejecutar varios algoritmos de ordenamiento en paralelo (hilos y BackgroundWorkers).
    // Las listas separadas permiten comparar tiempos de ejecución y mostrar trazas.

    // Variables globales para los datos y las copias que usan los distintos algoritmos
    private List<int>? listaOriginal;   // lista base generada por el usuario
    private List<int>? listaBurbuja;    // copia para Burbuja
    private List<int>? listaQuick;      // copia para QuickSort
    private List<int>? listaMerge;      // copia para MergeSort
    private List<int>? listaSelection;  // copia para SelectionSort
    private Thread? hiloBurbuja;        // hilo manual usado para Burbuja

    // Relojes para medir tiempos de cada algoritmo
    private Stopwatch relojBurbuja = new Stopwatch();
    private Stopwatch relojQuick = new Stopwatch();
    private Stopwatch relojMerge = new Stopwatch();
    private Stopwatch relojSelection = new Stopwatch();

    // Flags de cancelación para detener algoritmos en ejecución.
    // 'volatile' garantiza visibilidad entre hilos.
    private volatile bool cancelarBurbuja = false;
    private volatile bool cancelarSelection = false;

    // Tope para cuántas iteraciones guardamos cuando exportamos a Word (evita archivos enormes)
    private int maxIteracionesGuardar = 200; // limitar para Word

    // Diccionario para almacenar tiempos de ejecución y dibujarlos en el chart
    private Dictionary<string, long> tiempos = new Dictionary<string, long>();

    // Redibuja el chart (PictureBox) con barras que representan los tiempos medidos.
    // Se asegura de ejecutarse en el hilo de la UI mediante Invoke cuando sea necesario.
    private void RedibujarChart()
        {
            // Asegurar que se ejecute en el hilo de la UI
            if (chartTiempos == null) return;
            if (chartTiempos.InvokeRequired)
            {
                try { chartTiempos.Invoke(new Action(RedibujarChart)); } catch { }
                return;
            }

            int width = Math.Max(1, chartTiempos.Width);
            int height = Math.Max(1, chartTiempos.Height);

            // Si las dimensiones son demasiado pequeñas (por ejemplo antes de mostrar el formulario), no dibujar
            if (width <= 1 || height <= 1 || tiempos == null || tiempos.Count == 0)
            {
                // limpiar imagen previa si existe
                try { chartTiempos.Image?.Dispose(); chartTiempos.Image = null; } catch { }
                return;
            }

            Bitmap? bmp = null;
            try
            {
                bmp = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(System.Drawing.Color.WhiteSmoke);
                    int margin = 10;
                    int x = margin;
                    int w = Math.Max(40, (bmp.Width - margin * 2) / Math.Max(1, tiempos.Count));
                    long max = tiempos.Count > 0 ? tiempos.Values.Max() : 1;
                    foreach (var kv in tiempos)
                    {
                        int h = (int)((kv.Value / (double)max) * (bmp.Height - margin * 2));
                        Rectangle rect = new Rectangle(x, bmp.Height - margin - h, Math.Max(1, w - 5), Math.Max(1, h));
                        g.FillRectangle(Brushes.SteelBlue, rect);
                        g.DrawString(kv.Key, this.Font, Brushes.Black, x, 5);
                        g.DrawString($"{kv.Value} ms", this.Font, Brushes.Black, x, Math.Max(0, bmp.Height - margin - h - 15));
                        x += w;
                    }
                }

                var old = chartTiempos.Image;
                chartTiempos.Image = bmp;
                try { old?.Dispose(); } catch { }
                // No dispose bmp aquí porque ahora lo usa PictureBox
            }
            catch
            {
                try { bmp?.Dispose(); } catch { }
            }
        }

        // Constructor del formulario: inicializa componentes de la UI
        public Form1()
        {
            InitializeComponent();
        }

    // Evento para generar datos aleatorios
    // Crea una lista de enteros aleatorios de la longitud indicada por numericCantidad
    private void btnGenerar_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int cantidad = 100000;
            try
            {
                cantidad = (int)numericCantidad.Value;
            }
            catch { }

            listaOriginal = new List<int>();

            // Generar 'cantidad' números aleatorios
            for (int i = 0; i < cantidad; i++)
                listaOriginal.Add(rnd.Next(0, 1000000));

            MessageBox.Show("Lista generada correctamente con 100,000 números.", "Datos Generados", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // Resetear las barras de progreso
            progressBurbuja.Value = 0;
            progressQuickSort.Value = 0;
            lblBurbuja.Text = "Burbuja: 0%";
            lblQuickSort.Text = "QuickSort: 0%";
            // reset adicionales
            lblCantidad.Text = $"Cantidad: {listaOriginal.Count}";
            tiempos.Clear();
            RedibujarChart();
        }

    // Evento para iniciar los algoritmos de ordenamiento
    // Prepara copias de la lista original y arranca Burbuja en un Thread y los demás en BackgroundWorkers.
    private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (listaOriginal == null || listaOriginal.Count == 0)
            {
                MessageBox.Show("Primero genera los datos.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar que no hay hilos ejecutándose
            if (hiloBurbuja != null && hiloBurbuja.IsAlive)
            {
                MessageBox.Show("El ordenamiento ya está en ejecución.", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Copiamos la lista para cada algoritmo
            listaBurbuja = new List<int>(listaOriginal);
            listaQuick = new List<int>(listaOriginal);
            listaMerge = new List<int>(listaOriginal);
            listaSelection = new List<int>(listaOriginal);

            // Resetear las barras de progreso
            progressBurbuja.Value = 0;
            progressQuickSort.Value = 0;
            lblBurbuja.Text = "Burbuja: Iniciando...";
            lblQuickSort.Text = "QuickSort: Iniciando...";

            // Iniciar el hilo Burbuja usando Thread
            // Uso de Thread aquí para demostrar manejo clásico de hilos. El hilo actualizará la UI mediante Invoke.
            cancelarBurbuja = false;
            hiloBurbuja = new Thread(new ThreadStart(OrdenarBurbuja));
            hiloBurbuja.Start();

            // Iniciar el BackgroundWorker (QuickSort)
            if (!backgroundWorkerQuickSort.IsBusy)
            {
                backgroundWorkerQuickSort.RunWorkerAsync(listaQuick);
            }

            if (!backgroundWorkerMergeSort.IsBusy)
            {
                backgroundWorkerMergeSort.RunWorkerAsync(listaMerge);
            }

            if (!backgroundWorkerSelectionSort.IsBusy)
            {
                backgroundWorkerSelectionSort.RunWorkerAsync(listaSelection);
            }
        }

    // Algoritmo de ordenamiento Burbuja ejecutado en un hilo separado.
    // Actualiza la UI con Invoke para reportar progreso y trazas de swaps.
    private void OrdenarBurbuja()
        {
            relojBurbuja.Restart();
            if (listaBurbuja == null || listaBurbuja.Count == 0)
            {
                // Nada que ordenar
                this.Invoke(new Action(() =>
                {
                    lblBurbuja.Text = "Burbuja: No hay datos";
                }));
                return;
            }

            int n = listaBurbuja.Count;

            int iteracionesGuardadas = 0;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (cancelarBurbuja) { goto FIN_BURBUJA; }
                    if (listaBurbuja[j] > listaBurbuja[j + 1])
                    {
                        // Intercambio
                        int temp = listaBurbuja[j];
                        listaBurbuja[j] = listaBurbuja[j + 1];
                        listaBurbuja[j + 1] = temp;
                        // Guardar una traza limitada de iteraciones (primeros swaps)
                        if (iteracionesGuardadas < maxIteracionesGuardar)
                        {
                            try { listBoxBurbuja.Invoke(new Action(() => listBoxBurbuja.Items.Add($"Swap i={i} j={j}"))); } catch { }
                            iteracionesGuardadas++;
                        }
                    }
                }

                // Reportar progreso (cada 1000 iteraciones para mejor rendimiento)
                if (i % 1000 == 0)
                {
                    int progreso = (int)((i / (float)(n - 1)) * 100);
                    
                    // Usar Invoke para actualizar la UI desde el hilo secundario
                    this.Invoke(new Action(() =>
                    {
                        progressBurbuja.Value = Math.Min(progreso, 100);
                        lblBurbuja.Text = $"Burbuja: {progreso}%";
                    }));
                }
            }

            relojBurbuja.Stop();
            
            // Actualizar UI al completarse
            this.Invoke(new Action(() =>
            {
                progressBurbuja.Value = 100;
                lblBurbuja.Text = $"Burbuja: Completado en {relojBurbuja.ElapsedMilliseconds} ms";
            }));
            FIN_BURBUJA:;
            // Si se canceló, marcar en etiqueta
            if (cancelarBurbuja)
            {
                this.Invoke(new Action(() => lblBurbuja.Text = "Burbuja: Cancelado"));
            }
        }

    // SelectionSort (puede cancelarse usando la flag cancelarSelection)
    private void SelectionSort(List<int> lista)
        {
            if (lista == null || lista.Count == 0) return;
            int n = lista.Count;
            int iterGuardadas = 0;
            for (int i = 0; i < n - 1; i++)
            {
                if (cancelarSelection) return;
                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (lista[j] < lista[minIdx]) minIdx = j;
                }
                if (minIdx != i)
                {
                    int tmp = lista[i]; lista[i] = lista[minIdx]; lista[minIdx] = tmp;
                    if (iterGuardadas < maxIteracionesGuardar)
                    {
                        try { listBoxQuick.Invoke(new Action(() => listBoxQuick.Items.Add($"Selection swap i={i} min={minIdx}"))); } catch { }
                        iterGuardadas++;
                    }
                }
            }
        }

    // Método principal de QuickSort (recursivo)
    // Usa el BackgroundWorker para reportar progreso parcial a la UI.
    private void QuickSort(List<int> lista, int izquierda, int derecha, BackgroundWorker worker, int totalElementos)
        {
            if (izquierda < derecha)
            {
                int pivot = Particionar(lista, izquierda, derecha);
                QuickSort(lista, izquierda, pivot - 1, worker, totalElementos);
                QuickSort(lista, pivot + 1, derecha, worker, totalElementos);
            }

            // Reportar progreso periódicamente (método aproximado para no llamar ReportProgress en cada recursión)
            if (derecha % 5000 == 0 && derecha > 0)
            {
                int progreso = (int)((derecha / (float)totalElementos) * 100);
                worker.ReportProgress(Math.Min(progreso, 100));
            }
        }

    // MergeSort recursivo. Después del merge parcial reporta progreso aproximado.
    private void MergeSort(List<int> lista, int left, int right, BackgroundWorker worker, int total)
        {
            if (left >= right) return;
            int mid = (left + right) / 2;
            MergeSort(lista, left, mid, worker, total);
            MergeSort(lista, mid + 1, right, worker, total);
            // merge
            List<int> temp = new List<int>();
            int i = left, j = mid + 1;
            while (i <= mid && j <= right)
            {
                if (lista[i] <= lista[j]) { temp.Add(lista[i++]); }
                else { temp.Add(lista[j++]); }
            }
            while (i <= mid) temp.Add(lista[i++]);
            while (j <= right) temp.Add(lista[j++]);
            for (int k = 0; k < temp.Count; k++) lista[left + k] = temp[k];

            // Reportar progreso aproximado para actualizar la UI
            if (worker != null && (right - left) % Math.Max(1, total / 20) == 0)
            {
                int progreso = (int)((right / (float)total) * 100);
                worker.ReportProgress(Math.Min(progreso, 100));
            }
        }

        // Método auxiliar para particionar en QuickSort
        private int Particionar(List<int> lista, int izquierda, int derecha)
        {
            int pivote = lista[derecha];
            int i = izquierda - 1;
            
            for (int j = izquierda; j < derecha; j++)
            {
                if (lista[j] <= pivote)
                {
                    i++;
                    // Intercambio
                    int temp = lista[i];
                    lista[i] = lista[j];
                    lista[j] = temp;
                }
            }
            
            // Intercambio final
            int temp2 = lista[i + 1];
            lista[i + 1] = lista[derecha];
            lista[derecha] = temp2;
            
            return i + 1;
        }

    // Evento DoWork del BackgroundWorker para QuickSort: se ejecuta en un hilo del pool
    // y no bloquea la UI. El resultado se envía en e.Result.
    private void backgroundWorkerQuickSort_DoWork(object sender, DoWorkEventArgs e)
        {
            relojQuick.Restart();

            // Protección contra argumentos nulos
            List<int>? lista = e.Argument as List<int>;
            if (lista == null)
            {
                e.Result = null;
                return;
            }


            // Ejecutar QuickSort
            QuickSort(lista, 0, lista.Count - 1, backgroundWorkerQuickSort, lista.Count);

            relojQuick.Stop();
            e.Result = lista; // Pasar el resultado al evento Completed
        }

        // MergeSort BackgroundWorker handlers
        private void backgroundWorkerMergeSort_DoWork(object sender, DoWorkEventArgs e)
        {
            relojMerge.Restart();
            List<int>? lista = e.Argument as List<int>;
            if (lista == null) { e.Result = null; return; }
            MergeSort(lista, 0, lista.Count - 1, backgroundWorkerMergeSort, lista.Count);
            relojMerge.Stop();
            e.Result = lista;
        }

        private void backgroundWorkerMergeSort_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // usar progressQuickSort para representar merge (UI simplificada)
            progressQuickSort.Value = Math.Min(e.ProgressPercentage, 100);
            lblQuickSort.Text = $"MergeSort: {e.ProgressPercentage}%";
        }

        private void backgroundWorkerMergeSort_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null) MessageBox.Show($"Error Merge: {e.Error.Message}");
            else
            {
                lblQuickSort.Text = $"MergeSort: Completado en {relojMerge.ElapsedMilliseconds} ms";
                tiempos["MergeSort"] = relojMerge.ElapsedMilliseconds;
                RedibujarChart();
            }
        }

        // SelectionSort BackgroundWorker handlers
        private void backgroundWorkerSelectionSort_DoWork(object sender, DoWorkEventArgs e)
        {
            relojSelection.Restart();
            List<int>? lista = e.Argument as List<int>;
            if (lista == null) { e.Result = null; return; }
            // Ejecutar SelectionSort (en el hilo del BackgroundWorker, soporta cancelación)
            SelectionSort(lista);
            relojSelection.Stop();
            e.Result = lista;
        }

        private void backgroundWorkerSelectionSort_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // No usado actualmente
        }

        private void backgroundWorkerSelectionSort_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null) MessageBox.Show($"Error Selection: {e.Error.Message}");
            else
            {
                // actualizar chart
                tiempos["SelectionSort"] = relojSelection.ElapsedMilliseconds;
                RedibujarChart();
            }
        }

        // Evento ProgressChanged del BackgroundWorker
        private void backgroundWorkerQuickSort_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressQuickSort.Value = e.ProgressPercentage;
            lblQuickSort.Text = $"QuickSort: {e.ProgressPercentage}%";
        }

        // Evento RunWorkerCompleted del BackgroundWorker
        private void backgroundWorkerQuickSort_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show($"Error en QuickSort: {e.Error.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lblQuickSort.Text = $"QuickSort: Completado en {relojQuick.ElapsedMilliseconds} ms";
                progressQuickSort.Value = 100;
                tiempos["QuickSort"] = relojQuick.ElapsedMilliseconds;
                RedibujarChart();
                // Guardar en Word (trazas limitadas)
                try { SaveIterationsToWord("QuickSort", listBoxQuick.Items.Cast<object>().Select(x => x.ToString() ?? "").ToList()); } catch { }
            }
        }

        // Botón Detener
        private void btnDetener_Click(object sender, EventArgs e)
        {
            // Señales de cancelación
            cancelarBurbuja = true;
            cancelarSelection = true;

            if (backgroundWorkerMergeSort.IsBusy && backgroundWorkerMergeSort.WorkerSupportsCancellation)
                backgroundWorkerMergeSort.CancelAsync();
            if (backgroundWorkerSelectionSort.IsBusy && backgroundWorkerSelectionSort.WorkerSupportsCancellation)
                backgroundWorkerSelectionSort.CancelAsync();

            MessageBox.Show("Se ha solicitado la detención. Espere a que los hilos terminen.", "Detener", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Guardar iteraciones en Word (simple, cada línea como párrafo)
        private void SaveIterationsToWord(string algoritmo, List<string> iteraciones)
        {
            string carpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Ordenamientos");
            Directory.CreateDirectory(carpeta);
            string ruta = Path.Combine(carpeta, $"{algoritmo}_{DateTime.Now:yyyyMMdd_HHmmss}.docx");
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(ruta, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());
                body.AppendChild(new Paragraph(new Run(new Text($"Iteraciones para {algoritmo}"))));
                int count = 0;
                foreach (var it in iteraciones)
                {
                    body.AppendChild(new Paragraph(new Run(new Text(it))));
                    count++;
                    if (count >= maxIteracionesGuardar) break;
                }
            }
        }
    }
}