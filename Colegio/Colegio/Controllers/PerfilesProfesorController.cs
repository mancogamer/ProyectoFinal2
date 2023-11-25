using Microsoft.AspNetCore.Mvc;
using Colegio.Context;
using colegio.Models;
using colegio.Models;

namespace Colegio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerfilesProfesoresController : ControllerBase
    {
        private readonly ILogger<PerfilesProfesoresController> _logger;
        private readonly AplicacionContext _aplicacionContexto;

        public PerfilesProfesoresController(
            ILogger<PerfilesProfesoresController> logger,
            AplicacionContext aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // Create: Crear perfiles de profesores
        [HttpPost]
        public IActionResult Post([FromBody] perfiles_profesores Perfiles_Profesores)
        {
            _aplicacionContexto.Perfiles_Profesores.Add(Perfiles_Profesores);
            _aplicacionContexto.SaveChanges();
            return Ok(Perfiles_Profesores);
        }

        // READ: Obtener lista de perfiles de profesores
        [HttpGet]
        public IEnumerable<perfiles_profesores> Get()
        {
            return _aplicacionContexto.Perfiles_Profesores.ToList();
        }

        // Update: Modificar perfiles de profesores
        [HttpPut]
        public IActionResult Put([FromBody] perfiles_profesores perfilProfesor)
        {
            _aplicacionContexto.Perfiles_Profesores.Update(perfilProfesor);
            _aplicacionContexto.SaveChanges();
            return Ok(perfilProfesor);
        }

        // Delete: Eliminar perfiles de profesores
        [HttpDelete]
        public IActionResult Delete(int perfilProfesorID)
        {
            _aplicacionContexto.Perfiles_Profesores.Remove(
                _aplicacionContexto.Perfiles_Profesores.ToList()
                .Where(x => x.id == perfilProfesorID)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(perfilProfesorID);
        }
    }
}
