using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using TEAyudo;
using Application.UseCase.ObrasSociales;
using TEAyudo.DTO;

namespace TEAyudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObrasSocialesController : ControllerBase
    {
        private readonly TEAyudoContext _context;

        public ObrasSocialesController(TEAyudoContext context)
        {
            _context = context;
        }

        // GET: api/ObrasSociales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObraSocialDTO>>> GetObrasSociales()
        {
            var obrasSociales = await _context.ObrasSociales.ToListAsync();
            var obraSocialDTOs = obrasSociales.Select(os => new ObraSocialDTO
            {
                Nombre = os.Nombre,
                Descripcion = os.Descripcion
            }).ToList();

            return Ok(obraSocialDTOs);
        }


        // GET: api/ObraSocialws/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ObraSocialDTO>> GetObraSocial(int id)
        {
            var obraSocial = await _context.ObrasSociales.FindAsync(id);

            if (obraSocial == null)
            {
                return NotFound("Obra Social no encontrada.");
            }

            var obraSocialDTO = new ObraSocialDTO
            {
                Nombre = obraSocial.Nombre,
                Descripcion = obraSocial.Descripcion
                // Mapea otros campos si es necesario
            };

            return Ok(obraSocialDTO);
        }


        // PUT: api/ObraSocials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObraSocial(int id, ObraSocialDTO obraSocialDTO)
        {

            var obraSocial = await _context.ObrasSociales.FindAsync(id);

            if (obraSocial == null)
            {
                return NotFound("Obra Social no encontrada.");
            }

            // Actualiza los campos de la entidad en función de los datos del DTO
            obraSocial.Nombre = obraSocialDTO.Nombre;
            obraSocial.Descripcion = obraSocialDTO.Descripcion;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent(); // 204 No Content
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObraSocialExists(id))
                {
                    return NotFound("Obra Social no encontrada.");
                }
                else
                {
                    throw;
                }
            }
        }


        // POST: api/ObraSociales

        [HttpPost]
        public async Task<ActionResult<ObraSocial>> PostObraSocial(ObraSocialDTO obraSocialDTO)
        {
            var obraSocial = new ObraSocial
            {
                Nombre = obraSocialDTO.Nombre,
                Descripcion = obraSocialDTO.Descripcion
            };

            _context.ObrasSociales.Add(obraSocial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObraSocial", new { id = obraSocial.ObraSocialId }, obraSocial);
        }

        // DELETE: api/ObraSocials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObraSocial(int id)
        {
            if (_context.ObrasSociales == null)
            {
                return NotFound();
            }
            var obraSocial = await _context.ObrasSociales.FindAsync(id);
            if (obraSocial == null)
            {
                return NotFound();
            }

            _context.ObrasSociales.Remove(obraSocial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObraSocialExists(int id)
        {
            return (_context.ObrasSociales?.Any(e => e.ObraSocialId == id)).GetValueOrDefault();
        }
    }
}
