using Domain.Entities;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPacienteService
    {
        Task<Paciente> createPaciente(PacienteDTO paciente); //listo
        Task<List<Paciente>> getAll();
        Task<Paciente> getById(int pacienteID);
        Task<string> deletePaciente(int pacienteID);
        Task<string> updatePaciente(PacienteIdDTO pacienteID);
    }
}
