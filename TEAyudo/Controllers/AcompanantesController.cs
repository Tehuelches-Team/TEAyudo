using Application.Interfaces.Aplication;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TEAyudo.DTO;

namespace TEAyudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcompanantesController : Controller
    {
        private readonly IFiltroAcompanante _filtro;
        public AcompanantesController(IFiltroAcompanante filtro)
        {
            _filtro = filtro;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acompanante>>> GetAcompanante([FromQuery] int? ObraSocial = null, [FromQuery] string ZonaLaboral = null, [FromQuery] int? Especialidad = null, [FromQuery] int? Disponibilidad = null, [FromQuery] int? Id = null)
        {
            List<AcompananteDTO> result = await _filtro.Recuperar();

            if (ObraSocial != null) 
            {
                result = await _filtro.FiltarObraSocial(ObraSocial,result);
            }

            if (ZonaLaboral != null)
            {
                result = await _filtro.FiltarZonaLaboral(ZonaLaboral, result);
            }

            if (Especialidad != null)
            {
                result = await _filtro.FiltarEspecialidad(Especialidad, result);
            }

            if (Disponibilidad != null)
            {
                result = await _filtro.FiltrarDisponibilidadSemanal(Disponibilidad, result);
            }

            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
            
            //if (Id > 0)
            //{
            //    result = await _filtro.FiltrarId(Id);
            //}
        }


        /*[HttpGet("ObraSocial")]
        public async Task<ActionResult<IEnumerable<Acompanante>>> GetAcompananteObraSocial(int Id)
        {
            List<AcompananteDTO> result = await _filtro.FiltarObraSocial(Id);

            if(result == null)
            {
                return BadRequest();
            } else if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("ZonaLaboral")]
        public async Task<ActionResult<IEnumerable<AcompananteDTO>>> GetAcompananteZonaLaboral(int Id)
        {
            List<AcompananteDTO> result = await _filtro.FiltarZonaLaboral(Id);

            if (result == null)
            {
                return BadRequest();
            } else if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("Especialidad")]
        public async Task<ActionResult<IEnumerable<AcompananteDTO>>> GetAcompananteEspecialidad(int Id)
        {
            List<AcompananteDTO> result = await _filtro.FiltarEspecialidad(Id);

            if (result == null)
            {
                return BadRequest();
            } else if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("Disponibilidad")]
        public async Task<ActionResult<IEnumerable<AcompananteDTO>>> GetAcompananteDisponibilidad(int Disponibilidad)
        {
            List<AcompananteDTO> result = await _filtro.FiltrarDisponibilidadSemanal(Disponibilidad);

            if (result == null)
            {
                return BadRequest();
            } else if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<IEnumerable<AcompananteDTO>>> GetAcompananteId(int Id)
        {
            AcompananteDTO result = await _filtro.FiltrarId(Id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }*/
    }
}
