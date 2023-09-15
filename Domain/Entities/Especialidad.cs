using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Especialidad
    {
        [Key]
        public int EspecialidadId { get; set; }

        public required string Descripcion { get; set; }

        public ICollection<Acompanante> Acompanantes { get; set; }
    }
}