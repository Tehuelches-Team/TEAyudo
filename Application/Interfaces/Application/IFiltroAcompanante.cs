using Application.UseCase.DTO;
using TEAyudo.DTO;

namespace Application.Interfaces.Aplication
{
    public interface IFiltroAcompanante
    {
        Task<List<RegistrosAcompanantesDTO>> FiltarObraSocial(int? Id, List<RegistrosAcompanantesDTO> result);
        Task<List<RegistrosAcompanantesDTO>> FiltarEspecialidad(int? Id, List<RegistrosAcompanantesDTO> result);
        Task<List<RegistrosAcompanantesDTO>> FiltrarDisponibilidadSemanal(int? disponibilidad, List<RegistrosAcompanantesDTO> result);
        Task<List<RegistrosAcompanantesDTO>> FiltarZonaLaboral(string Id, List<RegistrosAcompanantesDTO> result);
        Task<RegistrosAcompanantesDTO> FiltrarId(int? Id, List<RegistrosAcompanantesDTO> result);
        Task<List<RegistrosAcompanantesDTO>> RecuperarTodos();
    }
}
