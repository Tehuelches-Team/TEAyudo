﻿using Application.Interfaces;
using Domain.Entities;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public async Task<Paciente> createPaciente(PacienteDTO pacienteDTO)  //listo pendiente de chequeo
        {
            Paciente paciente = new Paciente
            {
                Nombre = pacienteDTO.Nombre,
                Apellido = pacienteDTO.Apellido,
                FechaNacimiento = pacienteDTO.FechaNacimiento,
                DiagnosticoTEA = pacienteDTO.DiagnosticoTEA,
                Sexo = pacienteDTO.Sexo,
                TutorId = pacienteDTO.TutorId
            };
            return await _command.insertPaciente(paciente);
        }
        public async Task<List<Paciente>> getAll() //listo pendiente de chequeo
        {
            List<Paciente> list = await _querys.getListPacientes();
            return list;
        }
        public async Task<Paciente> getById(int pacienteID) 
        {
            Paciente paciente = await _querys.getPaciente(pacienteID);
            return paciente;
        }

        public async Task<string> deletePaciente(int pacienteID) 
        {
            string mensaje = await _command.removePaciente(pacienteID);
            return mensaje;
        }

        public async Task<string> updatePaciente(PacienteIdDTO pacienteID) 
        {
            Paciente paciente = new Paciente
            {
                PacienteId = pacienteID.PacienteId,
                Nombre = pacienteID.Nombre,
                Apellido = pacienteID.Apellido,
                FechaNacimiento = pacienteID.FechaNacimiento,
                DiagnosticoTEA = pacienteID.DiagnosticoTEA,
                Sexo = pacienteID.Sexo,
                TutorId = pacienteID.TutorId
            };
            string mensaje = await _command.updatePaciente(paciente);
            return mensaje;
        }


    }
}
