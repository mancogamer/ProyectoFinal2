using Microsoft.AspNetCore.Mvc;
using Colegio.Context;
using colegio.Models;

namespace Colegio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerfilesAlumnosController : ControllerBase
    {
        private readonly ILogger<PerfilesAlumnosController> _logger;
        private readonly AplicacionContext _aplicacionContexto;

        public PerfilesAlumnosController(
            ILogger<PerfilesAlumnosController> logger,
            AplicacionContext aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // Create: Crear perfiles de alumnos
        [HttpPost]
        public IActionResult Post([FromBody] perfiles_alumnos Perfiles_Alumnos)
        {
            _aplicacionContexto.Perfiles_Alumnos.Add(Perfiles_Alumnos);
            _aplicacionContexto.SaveChanges();
            return Ok(Perfiles_Alumnos);
        }

        // READ: Obtener lista de perfiles de alumnos
        [HttpGet]
        public IEnumerable<perfiles_alumnos> Get()
        {
            return _aplicacionContexto.Perfiles_Alumnos.ToList();
        }

        // Update: Modificar perfiles de alumnos
        [HttpPut]
        public IActionResult Put([FromBody] perfiles_alumnos Perfiles_Alumnos)
        {
            _aplicacionContexto.Perfiles_Alumnos.Update(Perfiles_Alumnos);
            _aplicacionContexto.SaveChanges();
            return Ok(Perfiles_Alumnos);
        }

        // Delete: Eliminar perfiles de alumnos
        [HttpDelete]
        public IActionResult Delete(int perfilAlumnoID)
        {
            _aplicacionContexto.Perfiles_Alumnos.Remove(
                _aplicacionContexto.Perfiles_Alumnos.ToList()
                .Where(x => x.id == perfilAlumnoID)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(perfilAlumnoID);
        }
    }
}
