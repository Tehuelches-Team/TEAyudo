using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.DTO
{
    public class RegistrosAcompanantesDTO
    {
        public int AcompananteId { get; set; }
        public int ObraSocialId { get; set; }
        public int EspecialidadId { get; set; }
        public int DisponibilidadSemanalId { get; set; }
        public string ZonaLaboral { get; set; }
        public string Contacto { get; set; }
        public string Documentacion { get; set; }
        public string Experiencia { get; set; }
        public string NombreObraSocial { get; set; }
        public string ObraSocial_Descripcion { get; set; }
        public string Especialidad_Descripcion { get; set; }
        public int DiaSemana { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFin { get; set; }
    }
}
