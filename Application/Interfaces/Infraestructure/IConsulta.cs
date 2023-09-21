using Application.UseCase.DTO;
using TEAyudo.DTO;

namespace Application.Interfaces
{
    public interface IConsulta
    {
        List<RegistrosAcompanantesDTO> GetAcompananteDTO();
        List<RegistrosAcompanantesDTO> GetAcompananteDTOId(int? id, List<RegistrosAcompanantesDTO> acompanantes);
        List<RegistrosAcompanantesDTO> GetAcompananteDTOEspecialidad(int? Especialidad, List<RegistrosAcompanantesDTO> acompanantes);
        List<RegistrosAcompanantesDTO> GetAcompananteDTODisponibilidad(int? Disponibilidad, List<RegistrosAcompanantesDTO> acompanantes);
        List<RegistrosAcompanantesDTO> GetAcompananteDTOObraSocial(int? ObraSocial, List<RegistrosAcompanantesDTO> acompanantes);
        List<RegistrosAcompanantesDTO> GetAcompananteDTOZonaLaboral(string ZonaLaboral, List<RegistrosAcompanantesDTO> acompanantes);
    }
}
