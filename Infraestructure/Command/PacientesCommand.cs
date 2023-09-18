using Application.Interfaces;
using Domain.Entities;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Paciente> insertPaciente(Paciente paciente) 
        {
            context.Pacientes.Add(paciente);
            await context.SaveChangesAsync();
            return paciente;
        }

        public async Task<string> removePaciente(int pacienteID) 
        {
            Paciente paciente = await context.Pacientes.FindAsync(pacienteID);
            if (paciente == null) 
            {
                return "No se encontro el ID de usuario.";
            }
            context.Pacientes.Remove(paciente);
            await context.SaveChangesAsync();
            return "Usuario removido exitosamente.";
        }

        public async Task<string> updatePaciente(Paciente paciente) 
        {
            context.Pacientes.Update(paciente);
            await context.SaveChangesAsync();
            return "Datos actualizados satisfactoriamente";
        }
    }
}
