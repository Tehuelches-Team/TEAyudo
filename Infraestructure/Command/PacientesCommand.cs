using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAyudo;

namespace Infraestructure.Command
{
    public class PacientesCommand : IPacientesCommand
    {
        private readonly TEAyudoContext context;

        public PacientesCommand(TEAyudoContext context)
        {
            this.context = context;
        }

        public async Task insertPaciente(Paciente paciente) 
        {
            context.Pacientes.Add(paciente);
            await context.SaveChangesAsync();
        }

        public async Task removePaciente(int pacienteID) 
        {
        }
    }
}
