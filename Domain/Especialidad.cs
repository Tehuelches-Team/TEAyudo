namespace TEAyudo
{
    public class Especialidad
    {
        public int EspecialidadId { get; set; }

        public string Descripcion { get; set; }

        //        public int AcompananteId { get; set; }
        public ICollection<Acompanante> Acompanantes { get; set; }
    }
}