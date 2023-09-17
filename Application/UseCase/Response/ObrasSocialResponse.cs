using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Response
{
    public class ObrasSocialResponse
    {
        public int ObraSocialId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
