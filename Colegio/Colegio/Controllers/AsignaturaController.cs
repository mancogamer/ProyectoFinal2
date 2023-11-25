using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Colegio.Context;
using Colegio.Models;
using Colegio.Context;
using Colegio.Models;

namespace Colegio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsignaturaController : ControllerBase
    {
        private readonly ILogger<AsignaturaController> _logger;
        private readonly AplicacionContext _aplicacionContexto;

        public AsignaturaController(
            ILogger<AsignaturaController> logger,
            AplicacionContext aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // Create: Crear asignaturas
        [HttpPost]
        [Route("CrearAsignatura")]
        public IActionResult CrearAsignatura([FromBody] Asignatura asignatura)
        {
            _aplicacionContexto.Asignaturas.Add(asignatura);
            _aplicacionContexto.SaveChanges();
            return Ok(asignatura);
        }

        // READ: Obtener lista de asignaturas
        [HttpGet]
        [Route("MostrarAsignaturas")]
        public IEnumerable<Asignatura> MostrarAsignaturas()
        {
            return _aplicacionContexto.Asignaturas.OrderByDescending(asignatura => asignatura.id).ToList();
        }

        // Update: Modificar asignaturas
        [HttpPut]
        [Route("EditarAsignatura")]
        public IActionResult EditarAsignatura([FromBody] Asignatura asignatura)
        {
            _aplicacionContexto.Asignaturas.Update(asignatura);
            _aplicacionContexto.SaveChanges();
            return Ok(asignatura);
        }

        // Delete: Eliminar asignaturas
        [HttpDelete]
        [Route("EliminarAsignatura")]
        public IActionResult EliminarAsignatura(int id)
        {
            Asignatura asignatura = _aplicacionContexto.Asignaturas.Find(id);
            if (asignatura != null)
            {
                _aplicacionContexto.Asignaturas.Remove(asignatura);
                _aplicacionContexto.SaveChanges();
                return Ok(asignatura);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
