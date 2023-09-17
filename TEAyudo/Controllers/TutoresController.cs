using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEAyudo;
using TEAyudo.DTO; // Añadimos el namespace del DTO

namespace TEAyudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutoresController : ControllerBase
    {
        private readonly TEAyudoContext _context;

        public TutoresController(TEAyudoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tutor>>> GetTutores()
        {
            return await _context.Tutores.Include(t => t.Usuario).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tutor>> GetTutor(int id)
        {
            var tutor = await _context.Tutores.Include(t => t.Usuario).FirstOrDefaultAsync(t => t.TutorId == id);

            if (tutor == null)
            {
                return NotFound();
            }

            return tutor;
        }

        [HttpPost]
        public async Task<ActionResult<Tutor>> PostTutor(TutorDTO tutorDTO) // Utilizamos el DTO en lugar de Tutor
        {
            var tutor = new Tutor
            {
                TutorId = tutorDTO.TutorId,
                UsuarioId = tutorDTO.UsuarioId,
                // Asigna otras propiedades del tutor según el DTO
                CertUniDisc = tutorDTO.CertUniDisc
            };

            _context.Tutores.Add(tutor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTutor", new { id = tutor.TutorId }, tutor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTutor(int id, TutorDTO tutorDTO) 
        {
            if (id != tutorDTO.TutorId)
            {
                return BadRequest();
            }

            var tutor = new Tutor
            {
                TutorId = tutorDTO.TutorId,
                UsuarioId = tutorDTO.UsuarioId,
                CertUniDisc = tutorDTO.CertUniDisc
                
            };

            _context.Entry(tutor).State = EntityState.Modified;

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

        // DELETE: api/Tutores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTutor(int id)
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
