namespace GestorTareas;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    
    // tarea
    public class Tarea
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public string Estado { get; set; }
    }
    
    // lista tarre
    List<Tarea> listaTareas = new List<Tarea>();
    
    
    // DatagridVIew
    private void ActualizarGrid()
    {
        dgvTareas.DataSource = null;
        dgvTareas.DataSource = listaTareas;
    }
    
    // evento para agregar tarea
    private void btnAgregar_Click(object sender, EventArgs e)
    {
        Tarea nueva = new Tarea()
        {
            Codigo = txtCodigo.Text,
            Nombre = txtNombre.Text,
            Descripcion = txtDescripcion.Text,
            Fecha = dtpFecha.Value,
            Lugar = textLugar.Text,
            Estado = cmbEstado.SelectedItem.ToString()
        };

        listaTareas.Add(nueva);
        ActualizarGrid();
        MessageBox.Show("Tarea agregada correctamente.");
    }
    // evento para editar tarea 
    
    private void btnEditar_Click(object sender, EventArgs e)
    {
        if (dgvTareas.SelectedRows.Count > 0)
        {
            int index = dgvTareas.SelectedRows[0].Index;
            listaTareas[index].Codigo = txtCodigo.Text;
            listaTareas[index].Nombre = txtNombre.Text;
            listaTareas[index].Descripcion = txtDescripcion.Text;
            listaTareas[index].Fecha = dtpFecha.Value;
            listaTareas[index].Lugar = textLugar.Text;
            listaTareas[index].Estado = cmbEstado.SelectedItem.ToString();

            ActualizarGrid();
            MessageBox.Show("Tarea editada correctamente.");
        }
    }
    
    // evento para eliminar tarea
    private void btnEliminar_Click(object sender, EventArgs e)
    {
        if (dgvTareas.SelectedRows.Count > 0)
        {
            int index = dgvTareas.SelectedRows[0].Index;
            listaTareas.RemoveAt(index);
            ActualizarGrid();
            MessageBox.Show("Tarea eliminada correctamente.");
        }
    }
     // evento para cargar datos en los textbox al selecionar una fila
     private void dgvTareas_CellClick(object sender, DataGridViewCellEventArgs e)
     {
         if (e.RowIndex >= 0)
         {
             txtCodigo.Text = dgvTareas.Rows[e.RowIndex].Cells[0].Value.ToString();
             txtNombre.Text = dgvTareas.Rows[e.RowIndex].Cells[1].Value.ToString();
             txtDescripcion.Text = dgvTareas.Rows[e.RowIndex].Cells[2].Value.ToString();
             dtpFecha.Value = (DateTime)dgvTareas.Rows[e.RowIndex].Cells[3].Value;
             textLugar.Text = dgvTareas.Rows[e.RowIndex].Cells[4].Value.ToString();
             cmbEstado.SelectedItem = dgvTareas.Rows[e.RowIndex].Cells[5].Value.ToString();
         }
     }
     // Buscar tarea por código
     private void btnBuscarCodigo_Click(object sender, EventArgs e)
     {
         string codigo = txtBuscarCodigo.Text.Trim();
         var resultado = listaTareas.Where(t => t.Codigo == codigo).ToList();
         dgvTareas.DataSource = null;
         dgvTareas.DataSource = resultado;
     }

     // Buscar tareas por estado
     private void btnBuscarEstado_Click(object sender, EventArgs e)
     {
         if (cmbBuscarEstado.SelectedItem != null)
         {
             string estado = cmbBuscarEstado.SelectedItem.ToString();
             var resultado = listaTareas.Where(t => t.Estado == estado).ToList();
             dgvTareas.DataSource = null;
             dgvTareas.DataSource = resultado;
         }
     }

     // Buscar tareas por rango de fecha
     private void btnBuscarFecha_Click(object sender, EventArgs e)
     {
         DateTime fechaInicio = dtpFechaInicio.Value.Date;
         DateTime fechaFin = dtpFechaFin.Value.Date;
         var resultado = listaTareas.Where(t => t.Fecha.Date >= fechaInicio && t.Fecha.Date <= fechaFin).ToList();
         dgvTareas.DataSource = null;
         dgvTareas.DataSource = resultado;
     }
}