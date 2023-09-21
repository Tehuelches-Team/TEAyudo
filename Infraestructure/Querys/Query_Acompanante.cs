using Application.Interfaces;
using Application.UseCase.DTO;
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

        List<RegistrosAcompanantesDTO> IConsulta.GetAcompananteDTOId(int? _id, List<RegistrosAcompanantesDTO> acompanantes)
        {
                acompanantes = (from Acompanante in _context.Acompanantes //Se crean los DTOS para los Acompanantes utilizados en los gets por filtros. 
                                join ObrasSocial in _context.ObrasSociales on Acompanante.ObraSocialId equals ObrasSocial.ObraSocialId
                                join Especialidad in _context.Especialidades on Acompanante.EspecialidadId equals Especialidad.EspecialidadId
                                join Disponibilidad in _context.DisponibilidadesSemanales on Acompanante.DisponibilidadSemanalId equals Disponibilidad.DisponibilidadSemanalId
                                where Acompanante.AcompananteId == _id
                                select new RegistrosAcompanantesDTO
                                {
                                    AcompananteId = Acompanante.AcompananteId,
                                    ObraSocialId = ObrasSocial.ObraSocialId,
                                    EspecialidadId = Especialidad.EspecialidadId,
                                    DisponibilidadSemanalId = Disponibilidad.DisponibilidadSemanalId,
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
                return acompanantes;
        }
        List<RegistrosAcompanantesDTO> IConsulta.GetAcompananteDTOEspecialidad(int? _Especialidad, List<RegistrosAcompanantesDTO> acompanantes)
        {
                acompanantes = (from Acompanante in _context.Acompanantes //Se crean los DTOS para los Acompanantes utilizados en los gets por filtros. 
                                join ObrasSocial in _context.ObrasSociales on Acompanante.ObraSocialId equals ObrasSocial.ObraSocialId
                                join Especialidad in _context.Especialidades on Acompanante.EspecialidadId equals Especialidad.EspecialidadId
                                join Disponibilidad in _context.DisponibilidadesSemanales on Acompanante.DisponibilidadSemanalId equals Disponibilidad.DisponibilidadSemanalId
                                where Especialidad.EspecialidadId == _Especialidad
                                select new RegistrosAcompanantesDTO
                                {
                                    AcompananteId = Acompanante.AcompananteId,
                                    ObraSocialId = ObrasSocial.ObraSocialId,
                                    EspecialidadId = Especialidad.EspecialidadId,
                                    DisponibilidadSemanalId = Disponibilidad.DisponibilidadSemanalId,
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
                return acompanantes;
        }

        List<RegistrosAcompanantesDTO> IConsulta.GetAcompananteDTODisponibilidad(int? _Disponibilidad, List<RegistrosAcompanantesDTO> acompanantes)
        {
                acompanantes = (from Acompanante in _context.Acompanantes //Se crean los DTOS para los Acompanantes utilizados en los gets por filtros. 
                join ObrasSocial in _context.ObrasSociales on Acompanante.ObraSocialId equals ObrasSocial.ObraSocialId
                join Especialidad in _context.Especialidades on Acompanante.EspecialidadId equals Especialidad.EspecialidadId
                join Disponibilidad in _context.DisponibilidadesSemanales on Acompanante.DisponibilidadSemanalId equals Disponibilidad.DisponibilidadSemanalId
                where Disponibilidad.DisponibilidadSemanalId== _Disponibilidad
                select new RegistrosAcompanantesDTO
                {
                    AcompananteId = Acompanante.AcompananteId,
                    ObraSocialId = ObrasSocial.ObraSocialId,
                    EspecialidadId = Especialidad.EspecialidadId,
                    DisponibilidadSemanalId = Disponibilidad.DisponibilidadSemanalId,
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
            return acompanantes;
        }

        List<RegistrosAcompanantesDTO> IConsulta.GetAcompananteDTOObraSocial(int? _ObraSocial, List<RegistrosAcompanantesDTO> acompanantes)
        {
                acompanantes = (from Acompanante in _context.Acompanantes //Se crean los DTOS para los Acompanantes utilizados en los gets por filtros. 
                                join ObrasSocial in _context.ObrasSociales on Acompanante.ObraSocialId equals ObrasSocial.ObraSocialId
                                join Especialidad in _context.Especialidades on Acompanante.EspecialidadId equals Especialidad.EspecialidadId
                                join Disponibilidad in _context.DisponibilidadesSemanales on Acompanante.DisponibilidadSemanalId equals Disponibilidad.DisponibilidadSemanalId
                                where ObrasSocial.ObraSocialId == _ObraSocial
                                select new RegistrosAcompanantesDTO
                                {
                                    AcompananteId = Acompanante.AcompananteId,
                                    ObraSocialId = ObrasSocial.ObraSocialId,
                                    EspecialidadId = Especialidad.EspecialidadId,
                                    DisponibilidadSemanalId = Disponibilidad.DisponibilidadSemanalId,
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
                return acompanantes;
        }

        List<RegistrosAcompanantesDTO> IConsulta.GetAcompananteDTOZonaLaboral(string _ZonaLaboral, List<RegistrosAcompanantesDTO> acompanantes)
        {
                acompanantes = (from Acompanante in _context.Acompanantes //Se crean los DTOS para los Acompanantes utilizados en los gets por filtros. 
                                join ObrasSocial in _context.ObrasSociales on Acompanante.ObraSocialId equals ObrasSocial.ObraSocialId
                                join Especialidad in _context.Especialidades on Acompanante.EspecialidadId equals Especialidad.EspecialidadId
                                join Disponibilidad in _context.DisponibilidadesSemanales on Acompanante.DisponibilidadSemanalId equals Disponibilidad.DisponibilidadSemanalId
                                where Acompanante.ZonaLaboral.Contains(_ZonaLaboral) //Ojo con el problema de las mayúsculas
                                select new RegistrosAcompanantesDTO
                                {
                                    AcompananteId = Acompanante.AcompananteId,
                                    ObraSocialId = ObrasSocial.ObraSocialId,
                                    EspecialidadId = Especialidad.EspecialidadId,
                                    DisponibilidadSemanalId = Disponibilidad.DisponibilidadSemanalId,
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
                return acompanantes;
        }

        List<RegistrosAcompanantesDTO> IConsulta.GetAcompananteDTO() => (from Acompanante in _context.Acompanantes //Se crean los DTOS para los Acompanantes utilizados en los gets por filtros. 
                                                                     join ObrasSocial in _context.ObrasSociales on Acompanante.ObraSocialId equals ObrasSocial.ObraSocialId
                                                                     join Especialidad in _context.Especialidades on Acompanante.EspecialidadId equals Especialidad.EspecialidadId
                                                                     join Disponibilidad in _context.DisponibilidadesSemanales on Acompanante.DisponibilidadSemanalId equals Disponibilidad.DisponibilidadSemanalId
                                                                     select new RegistrosAcompanantesDTO
                                                                     {
                                                                         AcompananteId = Acompanante.AcompananteId,
                                                                         ObraSocialId = ObrasSocial.ObraSocialId,
                                                                         EspecialidadId = Especialidad.EspecialidadId,
                                                                         DisponibilidadSemanalId= Disponibilidad.DisponibilidadSemanalId,
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
