using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEAyudo.DTO;

namespace TEAyudo.Controllers
{
    [Route("api/tutores")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        //        private readonly TutorService _tutorService;
        private readonly TEAyudoContext _context;

        public TutorController(TEAyudoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TutorDTO>>> GetAllTutorsAsync()
        {
            try
            {
                var tutors = await _context.Tutores
                    .Include(t => t.Usuario)
                    .ToListAsync();

                // Convierte la lista de Tutor entities a una lista de TutorDTOs
                var tutorDTOs = tutors.Select(tutor => new TutorDTO
                {
                    TutorId = tutor.TutorId,
                    Nombre = tutor.Usuario.Nombre,
                    Apellido = tutor.Usuario.Apellido,
                    CorreoElectronico = tutor.Usuario.CorreoElectronico,
                    // Otras propiedades
                }).ToList();

                return Ok(tutorDTOs); // Devuelve la lista de tutores como respuesta HTTP 200 (OK)
            }
            catch (Exception ex)
            {
                // Manejar excepciones aquí y devolver una respuesta de error adecuada, por ejemplo:
                return StatusCode(500, "Ocurrió un error al recuperar los tutores."); // Error interno del servidor
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TutorDTO>> GetTutorAsync(int tutorId)
        {
            try
            {
                var tutor = await _context.Tutores
                    .Include(t => t.Usuario)
                    .FirstOrDefaultAsync(t => t.TutorId == tutorId);

                if (tutor == null)
                {
                    return NotFound(); // Devuelve una respuesta HTTP 404 (No encontrado) si el tutor no existe
                }

                var tutorDTO = new TutorDTO
                {
                    TutorId = tutor.TutorId,
                    Nombre = tutor.Usuario.Nombre,
                    Apellido = tutor.Usuario.Apellido,
                    CorreoElectronico = tutor.Usuario.CorreoElectronico,
                    // Otras propiedades del tutor que desees incluir en el DTO
                };

                return Ok(tutorDTO); // Devuelve el tutor como respuesta HTTP 200 (OK)
            }
            catch (Exception ex)
            {
                // Manejar excepciones aquí y devolver una respuesta de error adecuada, por ejemplo:
                return StatusCode(500, "Ocurrió un error al obtener el tutor."); // Error interno del servidor
            }
        }



        [HttpPost]
        public async Task<IActionResult> CreateTutorWithUser([FromBody] TutorDTO tutorDTO)
        {
            try
            {
                // Primero, crea el usuario
                var usuario = new Usuario
                {
                    Nombre = tutorDTO.Nombre,
                    Apellido = tutorDTO.Apellido,
                    CorreoElectronico = tutorDTO.CorreoElectronico,
                    Contrasena = tutorDTO.Contrasena,
                    Domicilio = tutorDTO.Domicilio,
                    FotoPerfil = tutorDTO.FotoPerfil,
                    FechanNacimiento = tutorDTO.FechaNacimiento
                    // Otras propiedades del usuario
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                // Una vez que se crea el usuario, utiliza su UsuarioId para crear el Tutor
                var tutor = new Tutor
                {
                    UsuarioId = usuario.UsuarioId,
                    CertUniDisc = tutorDTO.CertUniDisc,
                    EstadoUsuarioId = tutorDTO.EstadoUsuarioId
                    // Otras propiedades del tutor
                };

                _context.Tutores.Add(tutor);
                await _context.SaveChangesAsync();

                // Devuelve una respuesta adecuada, por ejemplo, un código 201 (Created) con la información del nuevo tutor
                return CreatedAtAction("GetTutor", new { id = tutor.TutorId }, tutor);
            }
            catch (Exception ex)
            {
                // Manejar excepciones aquí y devolver una respuesta de error adecuada, por ejemplo:
                return StatusCode(500, "Ocurrió un error al crear el tutor."); // Error interno del servidor
            }
        }

    }
}
