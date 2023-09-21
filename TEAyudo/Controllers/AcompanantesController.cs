using Application.Interfaces.Aplication;
using Application.UseCase.DTO;
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
        public async Task<ActionResult<IEnumerable<AcompananteDTO>>> GetAcompanante(int? Id = null, int? Especialidad = null, int? Disponibilidad = null, int? ObraSocial = null,string ZonaLaboral = null)
        {
            List<RegistrosAcompanantesDTO> result = new List<RegistrosAcompanantesDTO>();
            bool controlador=true;

            if (Id > 0)
            {
                RegistrosAcompanantesDTO acom = await _filtro.FiltrarId(Id, result);
                if (acom!= null)
                {
                    result.Add(acom);
                }
                else controlador = false;

            }

            if (Especialidad != null && controlador)
            {
                result = await _filtro.FiltarEspecialidad(Especialidad, result);
                if (result.Count() == 0) controlador = false;
            }

            if (Disponibilidad != null && controlador)
            {
                result = await _filtro.FiltrarDisponibilidadSemanal(Disponibilidad, result);
                if (result.Count() == 0) controlador = false;
            }

            if (ObraSocial != null && controlador) 
            {
                result = await _filtro.FiltarObraSocial(ObraSocial,result);
                if (result.Count() == 0) controlador = false;
            }

            if (ZonaLaboral != null && controlador)
            {
                result = await _filtro.FiltarZonaLaboral(ZonaLaboral, result);
            }

            if(Id == null && Especialidad == null && Disponibilidad == null && ObraSocial == null && ZonaLaboral == null)
            {
                result = await _filtro.RecuperarTodos();
            }

            if (!result.Any())
            {
                return NotFound("No se encuentran acompañantes con los requisitos buscados");
            }
            else
            {
                List<AcompananteDTO> entrega = new List<AcompananteDTO>();
                foreach (var acom in result)
                {
                    entrega.Add(new AcompananteDTO
                    {
                        Contacto = acom.Contacto,
                        Documentacion = acom.Documentacion,
                        Experiencia = acom.Experiencia,
                        ZonaLaboral = acom.ZonaLaboral,
                        NombreObraSocial = acom.NombreObraSocial,
                        ObraSocial_Descripcion = acom.ObraSocial_Descripcion,
                        Especialidad_Descripcion = acom.Especialidad_Descripcion,
                        DiaSemana = acom.DiaSemana,
                        HorarioInicio = acom.HorarioInicio,
                        HorarioFin = acom.HorarioFin
                    });
                }
                return Ok(entrega);
            }



        }
    }
}
