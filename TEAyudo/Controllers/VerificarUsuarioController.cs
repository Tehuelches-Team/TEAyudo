using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEAyudo;
using Domain.Entities;

namespace TEAyudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificacionController : ControllerBase
    {
        private readonly TEAyudoContext _context;

        public VerificacionController(TEAyudoContext context)
        {
            _context = context;
        }

        // GET: api/Verificacion/VerificarCorreo
        [HttpGet("VerificarCorreo")]
        public async Task<IActionResult> VerificarCorreo([FromQuery] string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Token de verificación no válido");
            }

            // Buscar un usuario con el token proporcionado en la base de datos
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Token == token);

            if (usuario != null)
            {
                // Actualizar el campo "EstadoUsuarioId" a 1
                usuario.EstadoUsuarioId = 1;

                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync();

                return Ok(true); // Token encontrado y usuario actualizado, retorna true
            }
            else
            {
                return Ok(false); // Token no encontrado, retorna false
            }
        }
    }
}