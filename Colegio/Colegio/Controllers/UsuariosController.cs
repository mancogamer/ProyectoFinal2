using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Colegio.Context;
using Colegio.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Colegio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly AplicacionContext _aplicacionContexto;

        public UsuarioController(
            ILogger<UsuarioController> logger,
            AplicacionContext aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // Create: Crear un nuevo usuario
        [HttpPost]
        public IActionResult Post([FromBody] Usuario nuevoUsuario)
        {
            try
            {
                // Verificar si ya existe un usuario con el mismo correo electrónico
                var existingUser = _aplicacionContexto.Usuarios.SingleOrDefault(u => u.correo_electronico == nuevoUsuario.correo_electronico);
                if (existingUser != null)
                {
                    return Conflict($"El correo electrónico '{nuevoUsuario.correo_electronico}' ya está en uso por el usuario con ID {existingUser.id}.");
                }

                _aplicacionContexto.Usuarios.Add(nuevoUsuario);
                _aplicacionContexto.SaveChanges();
                return Ok(nuevoUsuario);
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException postgresException)
            {
                // Capturar la excepción y manejarla
                // Puedes logear el error para análisis posterior
                _logger.LogError(postgresException, "Error al insertar usuario");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
