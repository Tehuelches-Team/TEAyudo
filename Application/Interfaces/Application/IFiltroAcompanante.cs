using TEAyudo.DTO;

namespace Application.Interfaces.Aplication
{
    public interface IFiltroAcompanante
    {
        Task<List<AcompananteDTO>> FiltarObraSocial(int? Id, List<AcompananteDTO> result);
        Task<List<AcompananteDTO>> FiltarEspecialidad(int? Id, List<AcompananteDTO> result);
        Task<List<AcompananteDTO>> FiltrarDisponibilidadSemanal(int? disponibilidad, List<AcompananteDTO> result);
        Task<List<AcompananteDTO>> FiltarZonaLaboral(string Id, List<AcompananteDTO> result);
        Task<AcompananteDTO> FiltrarId(int? Id, List<AcompananteDTO> result);

        Task<List<AcompananteDTO>> Recuperar();
    }
}
