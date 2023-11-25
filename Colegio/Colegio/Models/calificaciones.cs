using System.ComponentModel.DataAnnotations;

namespace colegio.Models
{
    public class calificaciones
    {
        public int id { get; set; }
        public int alumno_id { get; set; }
        public int asignatura_id { get; set; }
        public int calificacion { get; set; }
        public string comentario { get; set; }
        public DateTime fecha { get; set; }

    }
}
