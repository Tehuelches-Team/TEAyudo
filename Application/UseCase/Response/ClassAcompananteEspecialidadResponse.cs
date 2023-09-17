using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Response
{
    public class ClassAcompananteEspecialidadResponse
    {
        public int AcompananteId { get; set; }
        public AcompananteResponse Acompanante { get; set; }
        public int EspecialidadId { get; set; }
        public EspecialidadResponse Especialidad { get; set; }
    }
}
