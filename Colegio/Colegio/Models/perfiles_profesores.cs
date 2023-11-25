using System.ComponentModel.DataAnnotations;

namespace colegio.Models
{
    public class perfiles_profesores
    {
        public int id { get; set; }
        public int usuario_id { get; set; }
        public string informacion_personal { get; set; }
        public string informacion_academica { get; set; }
        public string informacion_contacto { get; set; }
        public string foto { get; set; }
    }
}
