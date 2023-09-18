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

        async Task<List<AcompananteDTO>> IFiltroAcompanante.FiltarEspecialidad(string Especialidad)
        {
            List<AcompananteDTO> acompanante = _consultor.GetAcompananteDTO().Where(s => s.Especialidad_Descripcion == Especialidad).ToList();
            return acompanante;
        }

        async Task<List<AcompananteDTO>> IFiltroAcompanante.FiltarObraSocial(string nombre)
        {
            List<AcompananteDTO> acompanante = _consultor.GetAcompananteDTO().Where(s => s.NombreObraSocial==nombre).ToList();
            return acompanante;
        }

        async Task<List<AcompananteDTO>> IFiltroAcompanante.FiltarZonaLaboral(string ZonaLaboral)
        {
            List<AcompananteDTO> acompanante = _consultor.GetAcompananteDTO().Where(s => s.ZonaLaboral == ZonaLaboral).ToList();
            return acompanante;
        }

        async Task<List<AcompananteDTO>> IFiltroAcompanante.FiltrarDisponibilidadSemanal(int Dia)
        {
            List<AcompananteDTO> acompanante = _consultor.GetAcompananteDTO().Where(s => s.DiaSemana == Dia).ToList();
            return acompanante;
        }

        async Task<AcompananteDTO> IFiltroAcompanante.FiltrarId(int Id)
        {
            List<AcompananteDTO> acompanante = _consultor.GetAcompananteDTO().ToList();
            return acompanante.FirstOrDefault(s => s.AcompananteId == Id);
        }

    }
}
