namespace TEAyudo
{
    public class ObraSocial
    {
        public int ObraSocialId { get; set; }
        public string Nombre { get; set;}
        public string Descripcion { get; set; }
//        public int AcompananteId { get; set; }  
        public ICollection<Acompanante> Acompanantes { get; set; }
    }
}