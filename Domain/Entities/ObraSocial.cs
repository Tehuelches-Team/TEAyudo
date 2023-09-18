using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ObraSocial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ObraSocialId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        //        public int AcompananteId { get; set; }  
        public ICollection<Acompanante> Acompanantes { get; set; }
    }
}