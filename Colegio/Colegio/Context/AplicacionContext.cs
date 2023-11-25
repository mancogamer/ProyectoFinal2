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
        

    }
}
