using Application.Interfaces;
using Application.Interfaces.Aplication;
using TEAyudo.DTO;

namespace Application.UseCase.Filtros
{
    public class Filtro : IFiltro
    {
        private readonly IConsulta _consultor;

        public Filtro(IConsulta consultor)
        {
            _consultor = consultor;
        }

        async Task<List<AcompananteDTO>> IFiltro.FiltarEspecialidad(string Especialidad)
        {
            List<AcompananteDTO> acompanante = _consultor.GetAcompananteDTO().Where(s => s.Especialidad_Descripcion == Especialidad).ToList();
            return acompanante;
        }

        async Task<List<AcompananteDTO>> IFiltro.FiltarObraSocial(string nombre)
        {
            List<AcompananteDTO> acompanante = _consultor.GetAcompananteDTO().Where(s => s.NombreObraSocial==nombre).ToList();
            return acompanante;
        }

        async Task<List<AcompananteDTO>> IFiltro.FiltarZonaLaboral(string ZonaLaboral)
        {
            List<AcompananteDTO> acompanante = _consultor.GetAcompananteDTO().Where(s => s.ZonaLaboral == ZonaLaboral).ToList();
            return acompanante;
        }

        async Task<List<AcompananteDTO>> IFiltro.FiltrarDisponibilidadSemanal(int Dia)
        {
            List<AcompananteDTO> acompanante = _consultor.GetAcompananteDTO().Where(s => s.DiaSemana == Dia).ToList();
            return acompanante;
        }

        async Task<AcompananteDTO> IFiltro.FiltrarId(int Id)
        {
            List<AcompananteDTO> acompanante = _consultor.GetAcompananteDTO().ToList();
            return acompanante.FirstOrDefault(s => s.AcompananteId == Id);
        }

    }
}
