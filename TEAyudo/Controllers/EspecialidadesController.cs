using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using TEAyudo;
using TEAyudo.DTO;

namespace TEAyudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        private readonly TEAyudoContext _context;

        public EspecialidadesController(TEAyudoContext context)
        {
            _context = context;
        }

        // GET: api/Especialidades
        // GET: api/Especialidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspecialidadDTO>>> GetEspecialidades()
        {
            var especialidades = await _context.Especialidades.ToListAsync();

            var especialidadesDTO = especialidades.Select(especialidad => new EspecialidadDTO
            {
                EspecialidadId = especialidad.EspecialidadId,
                Descripcion = especialidad.Descripcion
                // Mapea otras propiedades si es necesario
            }).ToList();

            return Ok(especialidadesDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EspecialidadDTO>> GetEspecialidad(int id)
        {
            var especialidad = await _context.Especialidades.FindAsync(id);

            if (especialidad == null)
            {
                return NotFound("Especialidad no encontrada.");
            }

            var especialidadDTO = new EspecialidadDTO
            {
                Descripcion = especialidad.Descripcion
                // Mapea otras propiedades si es necesario
            };

            return Ok(especialidadDTO);
        }


        // PUT: api/Especialidades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecialidad(int id, EspecialidadDTO especialidadDTO)
        {
            var especialidad = await _context.Especialidades.FindAsync(id);

            if (especialidad == null)
            {
                return NotFound("Especialidad no encontrada.");
            }

            // Actualiza las propiedades de la entidad según los valores del DTO
            especialidad.Descripcion = especialidadDTO.Descripcion;
            // Actualiza otras propiedades si es necesario

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadExiste(id))
                {
                    return NotFound("Especialidad no encontrada.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Especialidades
        [HttpPost]
        public async Task<ActionResult<EspecialidadDTO>> PostEspecialidad(EspecialidadDTO especialidadDTO)
        {
            var especialidad = new Especialidad
            {
                EspecialidadId = especialidadDTO.EspecialidadId,
                Descripcion = especialidadDTO.Descripcion
                // Asigna otras propiedades si es necesario
            };

            _context.Especialidades.Add(especialidad);
            await _context.SaveChangesAsync();

            // Actualiza el ID de la especialidadDTO con el ID generado en la base de datos
            especialidadDTO.EspecialidadId = especialidad.EspecialidadId;

            return CreatedAtAction("GetEspecialidad", new { id = especialidadDTO.EspecialidadId }, especialidadDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecialidad(int id)
        {
            var especialidad = await _context.Especialidades.FindAsync(id);

            if (especialidad == null)
            {
                return NotFound("Especialidad no encontrada.");
            }

            _context.Especialidades.Remove(especialidad);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool EspecialidadExiste(int id)
        {
            return (_context.Especialidades?.Any(e => e.EspecialidadId == id)).GetValueOrDefault();
        }
    }
}
