using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Acompanante
{
    [Key]
    public int AcompananteId { get; set; }
    public int UsuarioId { get; set; }
    public string ZonaLaboral { get; set; }
    public int EstadoUsuarioId { get; set; }
    public int ObraSocialId { get; set; }
    public string Contacto { get; set; }
    public string Documentacion { get; set; }
    public int EspecialidadId { get; set; }
    public string Experiencia { get; set; }
    public int DisponibilidadSemanalId { get; set; }

    public EstadoUsuario EstadoUsuario { get; set; }
    public ICollection<ObraSocial> ObrasSociales { get; set; }
    public ICollection<Especialidad> Especialidades { get; set; }
    public ICollection<DisponibilidadSemanal> DisponibilidadesSemanales { get; set; }
    public ICollection<Propuesta> Propuestas { get; set; }
    public Usuario Usuario { get; set; }

}
