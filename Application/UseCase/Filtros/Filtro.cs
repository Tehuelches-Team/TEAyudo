using Application.Interfaces;
using Application.Interfaces.Aplication;
using Application.UseCase.Response;
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

        async Task<List<AcompananteDTO>> IFiltro.FiltarEspecialidad(string Especialidad)
        {
            List<AcompananteDTO> acompanante = _consultor.GetAcompananteDTO().Where(s => s.Especialidad_Descripcion == Especialidad).ToList();
            return acompanante;
        }

        async Task<List<AcompananteDTO>> IFiltro.FiltarObraSocial(string nombre)
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
            List<AcompananteDTO> acompanante = _consultor.GetAcompananteDTO().Where(s => s.NombreObraSocial==nombre).ToList();
            //Acompanante.where(p => p.Titulo.Contains(peli)).ToList();
            return acompanante;
        }

        async Task<List<AcompananteDTO>> IFiltro.FiltarZonaLaboral(string ZonaLaboral)
        {
            List<AcompananteDTO> acompanante = _consultor.GetAcompananteDTO().Where(s => s.ZonaLaboral == ZonaLaboral).ToList();
            return acompanante;
        }

        async Task<List<AcompananteDTO>> IFiltro.FiltrarDisponibilidadSemanal(int Dia)
        {
            List<AcompananteDTO> acompanante = _consultor.GetAcompananteDTO().Where(s => s.DiaSemana == Dia).ToList();
            return acompanante;
        }
    }
}
