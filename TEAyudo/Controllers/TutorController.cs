using Application.Interfaces;
using Application.UseCase.Tutores.GetAll;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TEAyudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly TEAyudoContext _context;

        public TutorController(TEAyudoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CrearTutor([FromBody] Tutor tutor)
        {
            if (tutor == null)
            {
                return BadRequest("Los datos del tutor son inválidos.");
            }

            // Validación adicional si es necesario

            try
            {
                // Crear primero el usuario
                var usuario = new Usuario { Nombre = "PEDRO" /* otros campos comunes */ };
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                // Luego, crea el tutor y establece la relación con el usuario
                tutor.UsuarioId = usuario.UsuarioId;
                _context.Tutores.Add(tutor);
                await _context.SaveChangesAsync();

                return Ok("Tutor creado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
