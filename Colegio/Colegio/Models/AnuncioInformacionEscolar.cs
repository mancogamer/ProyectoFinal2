using System.ComponentModel.DataAnnotations;

namespace Colegio.Models
{
    public class AnuncioInformacionEscolar
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string contenido { get; set; }
        public DateTime fecha { get; set; }
        public string autor { get; set; }
    }
}
