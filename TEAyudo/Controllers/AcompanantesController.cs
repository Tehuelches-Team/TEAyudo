using Application.Interfaces.Aplication;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEAyudo.DTO;

namespace TEAyudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcompanantesController : Controller
    {
        private readonly IFiltro _filtro;
        public AcompanantesController(IFiltro filtro)
        {
            _filtro = filtro;
        }

        [HttpGet("ObraSocial")]
        public async Task<ActionResult<IEnumerable<Acompanante>>> GetAcompanante(string ObraSocial)
        {
            /*var result = _context.Acompanantes.Include(s => s.ObrasSociales.Where(s => s.Nombre == ObraSocial))
                .Include(s => s.DisponibilidadesSemanales)
                .Include(s => s.Especialidades).ToListAsync();*/

            //var result = _context.ObrasSociales.Include(s => s.Acompanantes)
            //    .ThenInclude(s => s.DisponibilidadesSemanales)
            //    .ThenInclude(s => s.Acompanante)
            //    .ThenInclude(s => s.Especialidades)
            //    .Where(s => s.Nombre==ObraSocial);

            var result = _filtro.FiltarObraSocial(ObraSocial);

            if(result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet("ZonaLaboral")]
        public async Task<ActionResult<IEnumerable<AcompananteDTO>>> GetAcompananteZonaLaboral(string zonalaboral)
        {
            var result = _filtro.FiltarZonaLaboral(zonalaboral);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet("Especialidad")]
        public async Task<ActionResult<IEnumerable<AcompananteDTO>>> GetAcompananteEspecialidad(string Especialidad)
        {
            var result = _filtro.FiltarEspecialidad(Especialidad);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet("Disponibilidad")]
        public async Task<ActionResult<IEnumerable<AcompananteDTO>>> GetAcompananteDisponibilidad(int Disponibilidad)
        {
            var result = _filtro.FiltrarDisponibilidadSemanal(Disponibilidad);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
