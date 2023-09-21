using Application.Interfaces;
using Application.Interfaces.Aplication;
using Application.UseCase.DTO;
using Domain.Entities;
using TEAyudo.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.UseCase.Filtros
{ //Esta clase se encarga de realizar los filtrados correspondientes para los gets de Acompanante mediante LINQ
    public class FiltroAcompanante : IFiltroAcompanante 
    {
        private readonly IConsulta _consultor;

        public FiltroAcompanante(IConsulta consultor)
        {
            _consultor = consultor;
        }

        async Task<List<RegistrosAcompanantesDTO>> IFiltroAcompanante.RecuperarTodos()
        {
            List<RegistrosAcompanantesDTO> acompanante = _consultor.GetAcompananteDTO();
            return acompanante;
        }

        async Task<RegistrosAcompanantesDTO> IFiltroAcompanante.FiltrarId(int? Id, List<RegistrosAcompanantesDTO> result)
        {
            if (result.Count() == 0 && Id!= null)
            {
                result = _consultor.GetAcompananteDTOId(Id,result);
            }
            return result.FirstOrDefault(s => s.AcompananteId == Id);
        }

        async Task<List<RegistrosAcompanantesDTO>> IFiltroAcompanante.FiltarEspecialidad(int? Especialidad , List<RegistrosAcompanantesDTO> result)
        {
            if (result.Count() == 0 && Especialidad != null)
            {
                result = _consultor.GetAcompananteDTOEspecialidad(Especialidad, result);
                return result;
            }
            else
            {
                result = result.Where(s => s.EspecialidadId == Especialidad).ToList(); 
                return result;
            }
        }

        async Task<List<RegistrosAcompanantesDTO>> IFiltroAcompanante.FiltrarDisponibilidadSemanal(int? Dia, List<RegistrosAcompanantesDTO> result)
        {
            if (result.Count() == 0 && Dia != null)
            {
                result = _consultor.GetAcompananteDTODisponibilidad(Dia, result);
                return result;
            }
            else
            {
                result = result.Where(s => s.DisponibilidadSemanalId == Dia).ToList();
                return result;
            }
        }

        async Task<List<RegistrosAcompanantesDTO>> IFiltroAcompanante.FiltarObraSocial(int? nombre , List<RegistrosAcompanantesDTO> result)
        {
            if (result.Count() == 0 && nombre != null)
            {
                result = _consultor.GetAcompananteDTOObraSocial(nombre, result);
                return result;
            }
            else
            {
                result = result.Where(s => s.ObraSocialId == nombre).ToList();
                return result;
            }
        }

        async Task<List<RegistrosAcompanantesDTO>> IFiltroAcompanante.FiltarZonaLaboral(string ZonaLaboral, List<RegistrosAcompanantesDTO> result)
        {
            if (result.Count() == 0 && ZonaLaboral != null)
            {
                result = _consultor.GetAcompananteDTOZonaLaboral(ZonaLaboral, result);
                return result;
            }
            else 
            {
                result = result.Where(s => s.ZonaLaboral.Contains(ZonaLaboral)).ToList();
                return result;
            }
            
        }
    }
}
