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
        public async Task<ActionResult<IEnumerable<Acompanante>>> GetAcompanante(int? Id = null, int? Especialidad = null, int? Disponibilidad = null, int? ObraSocial = null,string ZonaLaboral = null)
        {
            List<AcompananteDTO> result = new List<AcompananteDTO>();

            if (Id > 0)
            {
                AcompananteDTO acom = await _filtro.FiltrarId(Id, result);
                result.Add(acom);
            }

            if (Especialidad != null)
            {
                result = await _filtro.FiltarEspecialidad(Especialidad, result);
            }

            if (Disponibilidad != null)
            {
                result = await _filtro.FiltrarDisponibilidadSemanal(Disponibilidad, result);
            }

            if (ObraSocial != null) 
            {
                result = await _filtro.FiltarObraSocial(ObraSocial,result);
            }

            if (ZonaLaboral != null)
            {
                result = await _filtro.FiltarZonaLaboral(ZonaLaboral, result);
            }

            if(Id == null && Especialidad == null && Disponibilidad == null && ObraSocial == null && ZonaLaboral == null)
            {
                result = await _filtro.RecuperarTodos();
            }

            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
