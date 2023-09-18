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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infraestructure.Querys
{
    public class Query_Acompanante : IConsulta
    {
        private readonly TEAyudoContext _context;

        public Query_Acompanante(TEAyudoContext context)
        {
            _context = context;
        }

        async Task<List<Acompanante>> IConsulta.GetDisponibilidad(int disponibilidad)
        {
            var Acompanante = _context.Acompanantes.Include(s => s.ObrasSociales)
                 .Include(s => s.DisponibilidadesSemanales.Where(s => s.DisponibilidadSemanalId == disponibilidad))
                 .Include(s => s.Especialidades).ToList();

            return Acompanante;
        }

        async Task<List<Acompanante>> IConsulta.GetEspecialidad(string especialidad)
        {
            var Acompanante = _context.Acompanantes.Include(s => s.ObrasSociales)
                   .Include(s => s.DisponibilidadesSemanales)
                   .Include(s => s.Especialidades.Where(s => s.Descripcion == especialidad)).ToList();

            return Acompanante;
        }

       async Task<List<Acompanante>> IConsulta.GetObraSocial(string nombre)
        {
            var Acompanante = _context.Acompanantes.Include(s => s.ObrasSociales.Where(s => s.Nombre == nombre))
                .Include(s => s.DisponibilidadesSemanales)
                .Include(s => s.Especialidades).ToList();

            //var acompanante = _context.ObrasSociales.Include(s => s.Acompanantes)
            //   .ThenInclude(s => s.DisponibilidadesSemanales)
            //   .Include(s => s.Acompanantes)
            //    .Where(s => s. == nombre);

            return Acompanante;
        }


        async Task<List<Acompanante>> IConsulta.GetZonaLaboral(string ZonaLaboral)
        {
            var Acompanante = _context.Acompanantes.Include(s => s.ObrasSociales)
            .Include(s => s.DisponibilidadesSemanales)
            .Include(s => s.Especialidades).Where(s => s.ZonaLaboral == ZonaLaboral).ToList();

            return Acompanante;
        }

        /*List<AcompananteDTO> IConsulta.GetAcompananteDTO() => (from Acompanante in _context.Acompanantes
                                                                     join ObrasSocial in _context.ObrasSociales on Acompanante.ObraSocialId equals ObrasSocial.ObraSocialId
                                                                     join Especialidad in _context.Especialidades on Acompanante.EspecialidadId equals Especialidad.EspecialidadId
                                                                     join Disponibilidad in _context.DisponibilidadesSemanales on Acompanante.DisponibilidadSemanalId equals Disponibilidad.DisponibilidadSemanalId
                                                                     select new AcompananteDTO
                                                                     {
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
                                                                     }).ToList();*/
    }
}
