using System.ComponentModel.DataAnnotations;

namespace Colegio.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo_electronico { get; set; }
        public string contrasena { get; set; }
        public string rol { get; set; }
        public string estado { get; set; }
    }
}
