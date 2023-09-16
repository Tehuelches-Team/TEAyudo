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
        private readonly TEAyudoContext _context; 

        public TutorController(TEAyudoContext context)
        {
            _context = context;
        }

        // GET: api/tutores/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TutorDTO>> GetTutor(int id)
        {
            var tutor = await _context.Tutores
                .FirstOrDefaultAsync(t => t.TutorId == id);

            if (tutor == null)
            {
                return NotFound();
            }

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
    }
}