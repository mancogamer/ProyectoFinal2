using System.ComponentModel.DataAnnotations;

namespace Colegio.Models
{
    public class recursos_educativo
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public string tipo { get; set; }
        public string archivo { get; set; }
        public DateTime fecha { get; set; }
        public DateTime ultimo_acceso { get; set; }
    }
}