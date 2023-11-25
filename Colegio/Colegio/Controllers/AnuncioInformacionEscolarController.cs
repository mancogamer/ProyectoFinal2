using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Colegio.Context;
using Colegio.Models;  // Asegúrate de ajustar el espacio de nombres según tu estructura de carpetas

namespace Colegio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnuncioInformacionEscolarController : ControllerBase
    {
        private readonly ILogger<AnuncioInformacionEscolarController> _logger;
        private readonly AplicacionContext _aplicacionContexto;

        public AnuncioInformacionEscolarController(
            ILogger<AnuncioInformacionEscolarController> logger,
            AplicacionContext aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // Create: Crear anuncios de información escolar
        [HttpPost]
        public IActionResult Post([FromBody] AnuncioInformacionEscolar anuncio)
        {
            _aplicacionContexto.AnuncioInformacionEscolar.Add(anuncio);
            _aplicacionContexto.SaveChanges();
            return Ok(anuncio);
        }

        // READ: Obtener lista de anuncios de información escolar
        [HttpGet]
        public IEnumerable<AnuncioInformacionEscolar> Get()
        {
            return _aplicacionContexto.AnuncioInformacionEscolar.ToList();
        }

        // Update: Modificar anuncios de información escolar
        [HttpPut]
        public IActionResult Put([FromBody] AnuncioInformacionEscolar anuncio)
        {
            _aplicacionContexto.AnuncioInformacionEscolar.Update(anuncio);
            _aplicacionContexto.SaveChanges();
            return Ok(anuncio);
        }

        // Delete: Eliminar anuncios de información escolar
        [HttpDelete]
        public IActionResult Delete(int anuncioID)
        {
            _aplicacionContexto.AnuncioInformacionEscolar.Remove(
                _aplicacionContexto.AnuncioInformacionEscolar.ToList()
                .Where(x => x.id == anuncioID)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(anuncioID);
        }
    }
}
