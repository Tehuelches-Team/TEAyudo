using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPacienteService
    {
        Task<Paciente> createPaciente(Paciente paciente); //listo
        Task<Paciente> updatePaciente(int pacienteID);
        Task<List<Paciente>> getAll();
        Task<Paciente> getById(int pacienteID);
    }
}
