using Microsoft.AspNetCore.Mvc;
using Colegio.Context;
using colegio.Models;

namespace Colegio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class calificacionesController : ControllerBase
    {
        private readonly ILogger<calificacionesController> _logger;
        private readonly AplicacionContext _aplicacionContexto;

        public calificacionesController(
            ILogger<calificacionesController> logger,
            AplicacionContext aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // Create: Crear calificaciones
        [HttpPost]
        public IActionResult Post([FromBody] calificaciones Calificaciones)
        {
            _aplicacionContexto.Calificacion.Add(Calificaciones);
            _aplicacionContexto.SaveChanges();
            return Ok(Calificaciones);
        }

        // READ: Obtener lista de calificaciones
        [HttpGet]
        public IEnumerable<calificacionesController> Get()
        {
            return (IEnumerable<calificacionesController>)_aplicacionContexto.Calificacion.ToList();
        }

        // Update: Modificar calificaciones
        [HttpPut]
        public IActionResult Put([FromBody] calificaciones calificacion)
        {
            _aplicacionContexto.Calificacion.Update(calificacion);
            _aplicacionContexto.SaveChanges();
            return Ok(calificacion);
        }

        // Delete: Eliminar calificaciones
        [HttpDelete]
        public IActionResult Delete(int calificacionID)
        {
            _aplicacionContexto.Calificacion.Remove(
                _aplicacionContexto.Calificacion.ToList()
                .Where(x => x.id == calificacionID)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(calificacionID);
        }
    }
}
