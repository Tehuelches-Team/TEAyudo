using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Response
{
    public class AcompananteResponse
    {
        public int AcompananteId { get; set; }
        public int UsuarioId { get; set; }
        public string ZonaLaboral { get; set; }
        public int EstadoUsuarioId { get; set; }
        public int ObraSocialId { get; set; }
        public string Contacto { get; set; }
        public string Documentacion { get; set; }
        public int EspecialidadId { get; set; }
        public string Experiencia { get; set; }
        public int DisponibilidadSemanalId { get; set; }
    }
}
