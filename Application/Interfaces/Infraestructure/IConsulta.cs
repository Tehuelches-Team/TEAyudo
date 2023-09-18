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
        Task<List<Acompanante>> GetObraSocial(string nombre);
        Task<List<Acompanante>> GetZonaLaboral(string nombre);
        Task<List<Acompanante>> GetDisponibilidad(int num);
        Task<List<Acompanante>> GetEspecialidad(string nombre);

        //List<Acompanante> GetAcompananteDTO();
    }
} 
