using Microsoft.EntityFrameworkCore;
using Colegio.Controllers;
using Colegio.Models;

namespace Colegio.Context
{
    public class AplicacionContext : DbContext
    {
        public AplicacionContext (DbContextOptions<AplicacionContext> options)
            : base(options) 
        {
        
        }
        
        public DbSet<AnuncioInformacionEscolar> AnuncioInformacionEscolar { get; set; }
        public DbSet<calificaciones> Calificacion { get; set; }
        public DbSet<recursos_educativo> recursos_educativos { get; set; }
        public DbSet<perfiles_alumnos> Perfiles_Alumnos { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<perfiles_profesores> Perfiles_Profesores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
