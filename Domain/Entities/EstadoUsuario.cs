namespace Domain.Entities
{
    public class EstadoUsuario
    {
        public int EstadoUsuarioId { get; set; }
        public string Descripcion { get; set; }
        //        public int AcompananteId { get; set; }
        public Acompanante Acompanante { get; set; }

        //        public int TutorId { get; set; }
        public Tutor Tutor { get; set; }

    }
}