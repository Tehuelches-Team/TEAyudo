using Application.UseCase.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAyudo.DTO;

namespace Application.Interfaces.Aplication
{
    public interface IFiltro
    {
        Task<List<AcompananteDTO>> FiltarObraSocial(string nombre);
        Task<List<AcompananteDTO>> FiltarEspecialidad(string Especialidad);
        Task<List<AcompananteDTO>> FiltrarDisponibilidadSemanal(int Dia);
        Task<List<AcompananteDTO>> FiltarZonaLaboral(string ZonaLaboral);
    }
}
