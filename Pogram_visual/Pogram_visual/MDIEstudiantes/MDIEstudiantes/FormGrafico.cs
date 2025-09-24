using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MDIEstudiantes
{
	public partial class FormGrafico : Form
	{
		private Chart? chartPromedios;

		public FormGrafico()
		{
			InicializarControles();
		}

		private void InicializarControles()
		{
			this.Text = "Mejores Promedios";
			this.Size = new System.Drawing.Size(600, 400);

			chartPromedios = new Chart
			{
				Dock = DockStyle.Fill
			};
			var chartArea = new ChartArea();
			chartPromedios.ChartAreas.Add(chartArea);
			var series = new Series
			{
				Name = "Promedios",
				ChartType = SeriesChartType.Column
			};
			chartPromedios.Series.Add(series);
			this.Controls.Add(chartPromedios);
			this.Load += FormGrafico_Load;
		}

		private void FormGrafico_Load(object? sender, EventArgs e)
		{
			if (DatosCompartidos.Estudiantes.Count > 0)
			{
				chartPromedios!.Series["Promedios"].Points.Clear();
				var promedios = DatosCompartidos.Estudiantes
					.Select(e => new
					{
						Nombre = string.IsNullOrEmpty(e.Nombre) ? e.Carnet : e.Nombre,
						Promedio = e.Asignaturas.Count > 0 ? e.Asignaturas.Average(a => a.Nota) : 0
					})
					.OrderByDescending(x => x.Promedio)
					.Take(10);
				foreach (var est in promedios)
				{
					chartPromedios.Series["Promedios"].Points.AddXY(est.Nombre, est.Promedio);
				}
			}
			else
			{
				MessageBox.Show("No hay estudiantes registrados.");
			}
		}
	}
}
