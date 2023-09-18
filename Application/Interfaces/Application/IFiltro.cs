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
        Task<List<Acompanante>> FiltarObraSocial(string nombre);
        Task<List<Acompanante>> FiltarEspecialidad(string Especialidad);
        Task<List<Acompanante>> FiltrarDisponibilidadSemanal(int Dia);
        Task<List<Acompanante>> FiltarZonaLaboral(string ZonaLaboral);
    }
}
