using Application.Interfaces;
using Application.Interfaces.Aplication;
using TEAyudo.DTO;

namespace Application.UseCase.Filtros
{ //Esta clase se encarga de realizar los filtrados correspondientes para los gets de Acompanante mediante LINQ
    public class FiltroAcompanante : IFiltroAcompanante 
    {
        private readonly IConsulta _consultor;

        public FiltroAcompanante(IConsulta consultor)
        {
            _consultor = consultor;
        }

        async Task<List<AcompananteDTO>> IFiltroAcompanante.Recuperar()
        {
            List<AcompananteDTO> acompanante = _consultor.GetAcompananteDTO();
            return acompanante;
        }

        async Task<List<AcompananteDTO>> IFiltroAcompanante.FiltarEspecialidad(int? Especialidad , List<AcompananteDTO> result)
        {
            List<AcompananteDTO> acompanante = result.Where(s => s.EspecialidadId == Especialidad).ToList();
            return acompanante;
        }

        async Task<List<AcompananteDTO>> IFiltroAcompanante.FiltarObraSocial(int? nombre , List<AcompananteDTO> result)
        {
            List<AcompananteDTO> acompanante = result.Where(s => s.ObraSocialId == nombre).ToList();
            return acompanante;
        }

        async Task<List<AcompananteDTO>> IFiltroAcompanante.FiltarZonaLaboral(string ZonaLaboral, List<AcompananteDTO> result)
        {
            List<AcompananteDTO> acompanante = result.Where(s => s.ZonaLaboral.Contains(ZonaLaboral)).ToList();
            return acompanante;
        }

        async Task<List<AcompananteDTO>> IFiltroAcompanante.FiltrarDisponibilidadSemanal(int? Dia, List<AcompananteDTO> result)
        {
            List<AcompananteDTO> acompanante = result.Where(s => s.DisponibilidadSemanalId == Dia).ToList();
            return acompanante;
        }

        async Task<AcompananteDTO> IFiltroAcompanante.FiltrarId(int? Id, List<AcompananteDTO> result)
        {
            return result.FirstOrDefault(s => s.AcompananteId == Id);
        }

    }
}
