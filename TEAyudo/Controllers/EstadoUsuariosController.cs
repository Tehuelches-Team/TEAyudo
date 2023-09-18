using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEAyudo;
using TEAyudo.DTO;

namespace TEAyudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoUsuariosController : ControllerBase
    {
        private readonly TEAyudoContext _context;

        public EstadoUsuariosController(TEAyudoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoUsuarioDTO>>> GetEstadoUsuarios()
        {
            var estadoUsuarios = await _context.EstadoUsuarios
                .Select(e => new EstadoUsuarioDTO
                {
                    EstadoUsuarioId = e.EstadoUsuarioId,
                    Descripcion = e.Descripcion
                })
                .ToListAsync();

            if (estadoUsuarios == null)
            {
                return NotFound();
            }

            return estadoUsuarios;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoUsuarioDTO>> GetEstadoUsuario(int id)
        {
            var estadoUsuario = await _context.EstadoUsuarios
                .Where(e => e.EstadoUsuarioId == id)
                .Select(e => new EstadoUsuarioDTO
                {
                    EstadoUsuarioId = e.EstadoUsuarioId,
                    Descripcion = e.Descripcion
                })
                .FirstOrDefaultAsync();

            if (estadoUsuario == null)
            {
                return NotFound();
            }

            return estadoUsuario;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoUsuario(int id, EstadoUsuarioDTO estadoUsuarioDTO)
        {
            if (id != estadoUsuarioDTO.EstadoUsuarioId)
            {
                return BadRequest();
            }

            var estadoUsuario = new EstadoUsuario
            {
                EstadoUsuarioId = estadoUsuarioDTO.EstadoUsuarioId,
                Descripcion = estadoUsuarioDTO.Descripcion
            };

            _context.Entry(estadoUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoUsuarioExists(id))
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

        [HttpPost]
        public async Task<ActionResult<EstadoUsuarioDTO>> PostEstadoUsuario(EstadoUsuarioDTO estadoUsuarioDTO)
        {
            var estadoUsuario = new EstadoUsuario
            {
                Descripcion = estadoUsuarioDTO.Descripcion
            };

            _context.EstadoUsuarios.Add(estadoUsuario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EstadoUsuarioExists(estadoUsuario.EstadoUsuarioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEstadoUsuario", new { id = estadoUsuario.EstadoUsuarioId }, estadoUsuarioDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoUsuario(int id)
        {
            var estadoUsuario = await _context.EstadoUsuarios.FindAsync(id);
            if (estadoUsuario == null)
            {
                return NotFound();
            }

            _context.EstadoUsuarios.Remove(estadoUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoUsuarioExists(int id)
        {
            return _context.EstadoUsuarios.Any(e => e.EstadoUsuarioId == id);
        }
    }
}
