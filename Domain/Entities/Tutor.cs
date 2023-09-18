using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Tutor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TutorId { get; set; }
    public int UsuarioId { get; set; }
    public ICollection<Paciente> Pacientes { get; set; }
    public string CertUniDisc { get; set; }
    public ICollection<Propuesta> Propuestas { get; set; }
    public Usuario Usuario { get; set; }
}
