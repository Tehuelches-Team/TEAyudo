namespace Domain.Entities
{
    public class Propuesta
    {
        public int PropuestaId { get; set; }

        public int TutorId { get; set; }
        public Tutor Tutor { get; set; }

        public int AcompananteId { get; set; }

        public string InfoAdicional { get; set; }

        public int Monto { get; set; }
        public Acompanante Acompanante { get; set; }
        //        public int DisponibilidadHorariaId { get; set; }
        //        public DisponibilidadHoraria Disponibilidad { get; set; }
        //        public int ObraSocialId { get; set; }
        //        public ObraSocial ObraSocial { get; set; }
        public int EstadoPropuestaId { get; set; }
        public EstadoPropuesta EstadoPropuesta { get; set; }
        //        public int EspecialidadId { get; set; }
        //        public Especialidad Especialidad { get;set; }


    }
}
