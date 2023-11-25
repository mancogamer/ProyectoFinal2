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
    public class RecursosEducativosController : ControllerBase
    {
        private readonly ILogger<RecursosEducativosController> _logger;
        private readonly AplicacionContext _aplicacionContexto;

        public RecursosEducativosController(
            ILogger<RecursosEducativosController> logger,
            AplicacionContext aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // Create: Crear recursos educativos
        [HttpPost]
        [Route("CrearRecursoEducativo")]
        public IActionResult CrearRecursoEducativo([FromBody] recursos_educativo RecursosEducativos)
        {
            _aplicacionContexto.recursos_educativos.Add(RecursosEducativos);
            _aplicacionContexto.SaveChanges();
            return Ok(RecursosEducativos);
        }

        // READ: Obtener lista de recursos educativos
        [HttpGet]
        [Route("MostrarRecursosEducativos")]
        public IEnumerable<recursos_educativo> MostrarRecursosEducativos()
        {
            return _aplicacionContexto.recursos_educativos.OrderByDescending(recurso => recurso.id).ToList();
        }

        // Update: Modificar recursos educativos
        [HttpPut]
        [Route("EditarRecursoEducativo")]
        public IActionResult EditarRecursoEducativo([FromBody] recursos_educativo RecursosEducativos)
        {
            _aplicacionContexto.recursos_educativos.Update(RecursosEducativos);
            _aplicacionContexto.SaveChanges();
            return Ok(RecursosEducativos);
        }

        // Delete: Eliminar recursos educativos
        [HttpDelete]
        [Route("EliminarRecursoEducativo")]
        public IActionResult EliminarRecursoEducativo(int id)
        {
            recursos_educativo recursoEducativo = _aplicacionContexto.recursos_educativos.Find(id);
            if (recursoEducativo != null)
            {
                _aplicacionContexto.recursos_educativos.Remove(recursoEducativo);
                _aplicacionContexto.SaveChanges();
                return Ok(recursoEducativo);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
