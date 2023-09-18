using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAyudo;
using TEAyudo.DTO;

namespace Infraestructure.Querys
{
    public class Query_Acompanante : IConsulta
    {
        private readonly TEAyudoContext _context;

        public Query_Acompanante(TEAyudoContext context)
        {
            _context = context;
        }

        List<AcompananteDTO> IConsulta.GetAcompananteDTO() => (from Acompanante in _context.Acompanantes //Se crean los DTOS para los Acompanantes utilizados en los gets por filtros. 
                                                                     join ObrasSocial in _context.ObrasSociales on Acompanante.ObraSocialId equals ObrasSocial.ObraSocialId
                                                                     join Especialidad in _context.Especialidades on Acompanante.EspecialidadId equals Especialidad.EspecialidadId
                                                                     join Disponibilidad in _context.DisponibilidadesSemanales on Acompanante.DisponibilidadSemanalId equals Disponibilidad.DisponibilidadSemanalId
                                                                     select new AcompananteDTO
                                                                     {
                                                                         AcompananteId = Acompanante.AcompananteId,
                                                                         Contacto = Acompanante.Contacto,
                                                                         Documentacion = Acompanante.Documentacion,
                                                                         Experiencia = Acompanante.Experiencia,
                                                                         ZonaLaboral = Acompanante.ZonaLaboral,
                                                                         NombreObraSocial = ObrasSocial.Nombre,
                                                                         ObraSocial_Descripcion = ObrasSocial.Descripcion,
                                                                         Especialidad_Descripcion = Especialidad.Descripcion,
                                                                         DiaSemana = Disponibilidad.DiaSemana,
                                                                         HorarioInicio = Disponibilidad.HorarioInicio,
                                                                         HorarioFin = Disponibilidad.HorarioFin
                                                                     }).ToList();
    }
}
