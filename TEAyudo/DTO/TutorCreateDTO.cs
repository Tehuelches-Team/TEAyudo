namespace TEAyudo.DTO
{
    public class TutorCreateDTO
    {
        public int TutorId { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }
        public List<PacienteDTO> Paciente { get; set; }
        public string CertUniDisc { get; set; }
        public int EstadoUsuarioId { get; set; }
    }
}