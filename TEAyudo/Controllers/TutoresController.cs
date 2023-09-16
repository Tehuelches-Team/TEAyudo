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
<<<<<<< HEAD
        private readonly TEAyudoContext _context; 
=======
        //        private readonly TutorService _tutorService;
        private readonly TEAyudoContext _context;
>>>>>>> 6141bafc2a256bf95c1690ec48c858488e5f72d3

        public TutorController(TEAyudoContext context)
        {
            _context = context;
        }

<<<<<<< HEAD
        // GET: api/tutores/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TutorDTO>> GetTutor(int id)
        {
            var tutor = await _context.Tutores
                .FirstOrDefaultAsync(t => t.TutorId == id);

            if (tutor == null)
=======
        [HttpGet]
        public async Task<ActionResult<List<TutorDTO>>> GetAllTutorsAsync()
        {
            try
>>>>>>> 6141bafc2a256bf95c1690ec48c858488e5f72d3
            {
                var tutors = await _context.Tutores
                    .Include(t => t.Usuario)
                    .ToListAsync();

<<<<<<< HEAD
            var tutorDTO = new TutorDTO
            {
                TutorId = tutor.TutorId,
                CertUniDisc = tutor.CertUniDisc
                // Otros campos específicos del tutor que desees incluir en el DTO
            };

            return tutorDTO;
        }

        // GET: api/tutores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TutorDTO>>> GetTutores()

        {
            var tutores = await _context.Tutores.ToListAsync();

            var tutoresDTO = tutores.Select(tutor => new TutorDTO
            {
                TutorId = tutor.TutorId,
                CertUniDisc = tutor.CertUniDisc
                // Otros campos específicos del tutor que desees incluir en el DTO
            }).ToList();

            return tutoresDTO;
        }

        // POST: api/tutores
        [HttpPost]
        public async Task<ActionResult<TutorDTO>> PostTutor(TutorDTO tutorDTO)
        {
            var tutor = new Tutor
            {
                TutorId = tutorDTO.TutorId,
                CertUniDisc = tutorDTO.CertUniDisc
                // Asigna otras propiedades si es necesario
            };

            _context.Tutores.Add(tutor);
            await _context.SaveChangesAsync();

            // Actualiza el ID del tutorDTO con el ID generado en la base de datos
            tutorDTO.TutorId = tutor.TutorId;

            return CreatedAtAction("GetTutor", new { id = tutorDTO.TutorId }, tutorDTO);
        }

        // PUT: api/tutores/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarTutor(int id, [FromBody] TutorDTO tutorDTO)
        {
            if (id != tutorDTO.TutorId)
            {
                return BadRequest("ID en el cuerpo de la solicitud no coincide con el ID de la ruta.");
            }

            var tutor = await _context.Tutores.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }
            
            tutor.CertUniDisc = tutorDTO.CertUniDisc;
            // Actualiza otros campos específicos del tutor si es necesario

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/tutores/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTutor(int id)
        {
            var tutor = await _context.Tutores.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }

            _context.Tutores.Remove(tutor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TutorExists(int id)
        {
            return _context.Tutores.Any(e => e.TutorId == id);
        }
=======
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

>>>>>>> 6141bafc2a256bf95c1690ec48c858488e5f72d3
    }
}