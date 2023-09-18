using Domain.Entities;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPacientesCommand
    {
        Task<Paciente> insertPaciente(Paciente paciente);
        Task<string> removePaciente(int pacienteID);
        Task<string> updatePaciente(Paciente paciente);
    }
}
