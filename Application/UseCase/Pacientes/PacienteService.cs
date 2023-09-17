using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Pacientes
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacientesCommand _command;
        private readonly IPacientesQuerys _querys;

        public PacienteService(IPacientesCommand command, IPacientesQuerys querys)
        {
            _command = command;
            _querys = querys;
        }

        public async Task<Paciente> createPaciente(Paciente paciente)  //listo
        {
            await _command.insertPaciente(paciente);
            return paciente;
        }

        public Task<Paciente> updatePaciente(int pacienteID) 
        {
            throw new NotImplementedException();
        }

        public Task<List<Paciente>> getAll() 
        {
            throw new NotImplementedException ();
        }

        public Task<Paciente> getById(int pacienteID) 
        {
            throw new NotImplementedException () ;
        }
    }
}
