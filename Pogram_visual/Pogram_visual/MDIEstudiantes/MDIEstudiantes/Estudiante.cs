using System.Collections.Generic;

namespace MDIEstudiantes
{
    public class Estudiante
    {
        public string? Carnet { get; set; }
        public string? Nombre { get; set; }
        public List<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
    }

    public class Asignatura
    {
        public string? Nombre { get; set; }
        public double Nota { get; set; }
    }

    public static class DatosCompartidos
    {
        public static List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
        public static Estudiante? EstudianteActual { get; set; }
    }
}
