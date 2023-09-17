using Application.UseCase.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAyudo.DTO;

namespace Application.Interfaces
{
    public interface IConsulta
    {
        //List<Acompanante> GetObraSocial(string nombre);
        //Task<List<AcompananteDTO>> GetObraSocial(string nombre);
        //Task<List<AcompananteDTO>> GetZonaLaboral();
        //Task<List<AcompananteDTO>> GetEspecialidad();
        //Task<List<AcompananteDTO>> GetDisponibilidad();

        List<AcompananteDTO> GetAcompananteDTO();

        //ObrasSocialResponse GetObraSocial(int id);
        //Task<List<AcompananteResponse>> GetZonaLaboral();
        //Task<List<EspecialidadResponse>> GetEspecialidad();
        //Task<List<DisponibilidadSemanalResponse>> GetDisponibilidad();
    }
}
