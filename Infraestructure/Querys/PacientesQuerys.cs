using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAyudo;

namespace Infraestructure.Querys
{
    public class PacientesQuerys : IPacientesQuerys
    {
        private readonly TEAyudoContext context;

        public PacientesQuerys(TEAyudoContext context)
        {
            this.context = context;
        }
        public async Task<List<Paciente>> getListPacientes() 
        {
            List<Paciente> list = context.Pacientes.ToList();
            return list;
        }
        public async Task<Paciente> getPaciente(int pacienteID) 
        {
            Paciente paciente = context.Pacientes.FirstOrDefault(p => p.PacienteId == pacienteID);
            return paciente;
        }
    }
}
