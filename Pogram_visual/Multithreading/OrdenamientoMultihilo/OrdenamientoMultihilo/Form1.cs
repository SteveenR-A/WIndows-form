using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace OrdenamientoMultihilo
{
    public partial class Form1 : Form
    {
        // Variables globales para el multithreading
        private List<int> listaOriginal;
        private List<int> listaBurbuja;
        private List<int> listaQuick;
        private Thread hiloBurbuja;
        private Stopwatch relojBurbuja = new Stopwatch();
        private Stopwatch relojQuick = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
        }

        // Evento para generar datos aleatorios
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            listaOriginal = new List<int>();
            
            // Generar 100,000 números aleatorios
            for (int i = 0; i < 100000; i++)
                listaOriginal.Add(rnd.Next(0, 1000000));

            MessageBox.Show("Lista generada correctamente con 100,000 números.", "Datos Generados", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // Resetear las barras de progreso
            progressBurbuja.Value = 0;
            progressQuickSort.Value = 0;
            lblBurbuja.Text = "Burbuja: 0%";
            lblQuickSort.Text = "QuickSort: 0%";
        }

        // Evento para iniciar los algoritmos de ordenamiento
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

            // Resetear las barras de progreso
            progressBurbuja.Value = 0;
            progressQuickSort.Value = 0;
            lblBurbuja.Text = "Burbuja: Iniciando...";
            lblQuickSort.Text = "QuickSort: Iniciando...";

            // Iniciar el hilo Burbuja usando Thread
            hiloBurbuja = new Thread(new ThreadStart(OrdenarBurbuja));
            hiloBurbuja.Start();

            // Iniciar el BackgroundWorker (QuickSort)
            if (!backgroundWorkerQuickSort.IsBusy)
            {
                backgroundWorkerQuickSort.RunWorkerAsync(listaQuick);
            }
        }

        // Algoritmo de ordenamiento Burbuja usando Thread y delegados
        private void OrdenarBurbuja()
        {
            relojBurbuja.Restart();
            int n = listaBurbuja.Count;
            
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (listaBurbuja[j] > listaBurbuja[j + 1])
                    {
                        // Intercambio
                        int temp = listaBurbuja[j];
                        listaBurbuja[j] = listaBurbuja[j + 1];
                        listaBurbuja[j + 1] = temp;
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
        }

        // Método principal de QuickSort
        private void QuickSort(List<int> lista, int izquierda, int derecha, BackgroundWorker worker, int totalElementos)
        {
            if (izquierda < derecha)
            {
                int pivot = Particionar(lista, izquierda, derecha);
                QuickSort(lista, izquierda, pivot - 1, worker, totalElementos);
                QuickSort(lista, pivot + 1, derecha, worker, totalElementos);
            }

            // Reportar progreso periódicamente
            if (derecha % 5000 == 0 && derecha > 0)
            {
                int progreso = (int)((derecha / (float)totalElementos) * 100);
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

        // Evento DoWork del BackgroundWorker
        private void backgroundWorkerQuickSort_DoWork(object sender, DoWorkEventArgs e)
        {
            relojQuick.Restart();
            List<int> lista = (List<int>)e.Argument;
            
            // Ejecutar QuickSort
            QuickSort(lista, 0, lista.Count - 1, backgroundWorkerQuickSort, lista.Count);
            
            relojQuick.Stop();
            e.Result = lista; // Pasar el resultado al evento Completed
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
            }
        }
    }
}