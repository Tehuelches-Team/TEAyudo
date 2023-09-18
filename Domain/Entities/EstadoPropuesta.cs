using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class EstadoPropuesta
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EstadoPropuestaId { get; set; }
    public string Descripcion { get; set; }
    //    public int PropuestaId { get; set; }
    public ICollection<Propuesta> Propuestas { get; set; }


}
