using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using TEAyudo;

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

        // GET: api/EstadoUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoUsuario>>> GetEstadoUsuarios()
        {
          if (_context.EstadoUsuarios == null)
          {
              return NotFound();
          }
            return await _context.EstadoUsuarios.ToListAsync();
        }

        // GET: api/EstadoUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoUsuario>> GetEstadoUsuario(int id)
        {
          if (_context.EstadoUsuarios == null)
          {
              return NotFound();
          }
            var estadoUsuario = await _context.EstadoUsuarios.FindAsync(id);

            if (estadoUsuario == null)
            {
                return NotFound();
            }

            return estadoUsuario;
        }

        // PUT: api/EstadoUsuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoUsuario(int id, EstadoUsuario estadoUsuario)
        {
            if (id != estadoUsuario.EstadoUsuarioId)
            {
                return BadRequest();
            }

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

        // POST: api/EstadoUsuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadoUsuario>> PostEstadoUsuario(EstadoUsuario estadoUsuario)
        {
          if (_context.EstadoUsuarios == null)
          {
              return Problem("Entity set 'TEAyudoContext.EstadoUsuarios'  is null.");
          }
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

            return CreatedAtAction("GetEstadoUsuario", new { id = estadoUsuario.EstadoUsuarioId }, estadoUsuario);
        }

        // DELETE: api/EstadoUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoUsuario(int id)
        {
            if (_context.EstadoUsuarios == null)
            {
                return NotFound();
            }
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
            return (_context.EstadoUsuarios?.Any(e => e.EstadoUsuarioId == id)).GetValueOrDefault();
        }
    }
}
