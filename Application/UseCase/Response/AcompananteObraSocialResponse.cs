using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Response
{
    public class AcompananteObraSocialResponse
    {
        public int AcompananteId { get; set; }
        public AcompananteResponse Acompanante { get; set; }
        public int ObrasocialId { get; set; }
        public ObrasSocialResponse ObraSocial { get; set; }
    }
}
