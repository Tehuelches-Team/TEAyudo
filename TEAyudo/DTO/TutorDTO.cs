using Domain.Entities;

namespace TEAyudo.DTO
{
    public class TutorDTO
    {
        public int TutorId { get; set; }
        public int UsuarioId { get; set; }
<<<<<<< HEAD
        public List<PacienteDTO> Paciente { get; set; }
        public string CertUniDisc { get; set; }
=======
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }
        public string CertUniDisc { get; set; }
        public int EstadoUsuarioId { get; set; }
        public string FotoPerfil { get; set; }
        public string Domicilio { get; set; }
        public DateTime FechaNacimiento { get; set; }
>>>>>>> 6141bafc2a256bf95c1690ec48c858488e5f72d3
    }

}
