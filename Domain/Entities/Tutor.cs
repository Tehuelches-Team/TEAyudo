namespace Domain.Entities;
public class Tutor
{
    public int TutorId { get; set; }
    public int UsuarioId { get; set; }
    public ICollection<Paciente> Pacientes { get; set; }
    public string CertUniDisc { get; set; }
    //public string Nombre { get; set; }
    //public string Apellido { get; set; }
    //public string CorreoElectronico { get; set; }
    //public string Contrasena { get; set; }
    //public string FotoPerfil { get; set; }
    //public string Domicilio { get; set; }

    //public int Edad { get; set; }
    public int EstadoUsuarioId { get; set; }
    public EstadoUsuario EstadoUsuario { get; set; }
    public ICollection<Propuesta> Propuestas { get; set; }

    public Usuario Usuario { get; set; }
}
