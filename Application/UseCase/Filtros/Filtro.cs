using Application.Interfaces;
using Application.Interfaces.Aplication;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAyudo.DTO;

namespace Application.UseCase.Filtros
{
    public class Filtro : IFiltro
    {
        private readonly IConsulta _consultor;

        public Filtro(IConsulta consultor)
        {
            _consultor = consultor;
        }

        async Task<List<Acompanante>> IFiltro.FiltarEspecialidad(string Especialidad)
        {
            List<Acompanante> acompanante = await _consultor.GetEspecialidad(Especialidad);
            return acompanante;
        }

        async Task<List<Acompanante>> IFiltro.FiltarObraSocial(string nombre)
        {
            /*var Acompanante = _consultor.GetObraSocial(id);
            return Task.FromResult(new AcompananteResponse
            {
                AcompananteId = Acompanante.AcompananteId,
                UsuarioId= Acompanante.UsuarioId,
                ZonaLaboral = Acompanante.ZonaLaboral,
                EstadoUsuarioId = Acompanante.EstadoUsuarioId,
                ObraSocialId = Acompanante.ObraSocialId,
                Contacto = Acompanante.Contacto,
                Documentacion = Acompanante.Documentacion,
                EspecialidadId = Acompanante.EspecialidadId,
                Experiencia = Acompanante.Experiencia,
                DisponibilidadSemanalId = Acompanante.DisponibilidadSemanalId
            });*/
            List<Acompanante> acompanante = await _consultor.GetObraSocial(nombre);
            //Acompanante.where(p => p.Titulo.Contains(peli)).ToList();
            return acompanante;
        }

        async Task<List<Acompanante>> IFiltro.FiltarZonaLaboral(string ZonaLaboral)
        {
            List<Acompanante> acompanante = await _consultor.GetZonaLaboral(ZonaLaboral);
            return acompanante;
        }

        async Task<List<Acompanante>> IFiltro.FiltrarDisponibilidadSemanal(int Dia)
        {
            List<Acompanante> acompanante = await _consultor.GetDisponibilidad(Dia);
            return acompanante;
        }
    }
}
