namespace Domain.Entities;
public class Tutor
{
    public int TutorId { get; set; }
    public int UsuarioId { get; set; }
    public ICollection<Paciente> Pacientes { get; set; }
    public string CertUniDisc { get; set; }

    public int EstadoUsuarioId { get; set; }
    public EstadoUsuario EstadoUsuario { get; set; }
    public ICollection<Propuesta> Propuestas { get; set; }

    public Usuario Usuario { get; set; }
}
