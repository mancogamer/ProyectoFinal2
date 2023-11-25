using System.ComponentModel.DataAnnotations;

namespace Colegio.Models
{
    public class Asignatura
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string nivel { get; set; }
        public string descripcion { get; set; }
    }
}
