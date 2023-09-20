using TEAyudo.DTO;

namespace Application.Interfaces
{
    public interface IConsulta
    {
        List<AcompananteDTO> GetAcompananteDTO();
        List<AcompananteDTO> GetAcompananteDTOId(int? id, List<AcompananteDTO> acompanantes);
        List<AcompananteDTO> GetAcompananteDTOEspecialidad(int? Especialidad, List<AcompananteDTO> acompanantes);
        List<AcompananteDTO> GetAcompananteDTODisponibilidad(int? Disponibilidad, List<AcompananteDTO> acompanantes);
        List<AcompananteDTO> GetAcompananteDTOObraSocial(int? ObraSocial, List<AcompananteDTO> acompanantes);
        List<AcompananteDTO> GetAcompananteDTOZonaLaboral(string ZonaLaboral, List<AcompananteDTO> acompanantes);
    }
}
