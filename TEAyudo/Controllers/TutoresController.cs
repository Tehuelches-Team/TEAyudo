using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEAyudo.API.Services;
using TEAyudo.DTO;

namespace TEAyudo.Controllers
{
    [Route("api/tutores")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly TutorService _tutorService;
        private readonly TEAyudoContext _context;

        public TutorController(TEAyudoContext context)
        {
            _context = context;
        }

        // GET: api/tutores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TutorDTO>> GetTutor(int id)
        {
            var tutorDTO = await _tutorService.GetTutorAsync(id);

            if (tutorDTO == null)
            {
                return NotFound();
            }

            return tutorDTO;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTutorWithUser([FromBody] UsuarioDTO usuarioDTO)
        {
            // Primero, crea el usuario
            var usuario = new Usuario
            {
                Nombre = usuarioDTO.Nombre,
                Apellido = usuarioDTO.Apellido,
                CorreoElectronico = usuarioDTO.CorreoElectronico
                //Contrasena = usuarioDTO.Contrasena,
                //Domicilio = usuarioDTO.Domicilio,
                //FotoPerfil = usuarioDTO.FotoPerfil,
                //FechanNacimiento = usuarioDTO.FechaNacimiento
                // Otras propiedades del usuario
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            // Una vez que se crea el usuario, utiliza su UsuarioId para crear el Tutor
            var tutor = new Tutor
            {
                UsuarioId = usuario.UsuarioId, // Asigna el UsuarioId del usuario recién creado
                // Otras propiedades del tutor
            };

            _context.Tutores.Add(tutor);
            await _context.SaveChangesAsync();

            // Devuelve una respuesta adecuada, por ejemplo, un código 201 (Created) con la información del nuevo tutor
            return CreatedAtAction("GetTutor", new { id = tutor.TutorId }, tutor);
        }

        // Agrega más métodos según tus necesidades, como métodos para gestionar pacientes, etc.
    }
}
