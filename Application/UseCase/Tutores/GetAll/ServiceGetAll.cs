using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Tutores.GetAll
{
    public class ServiceGetAll : IServiceGetAll
    {
        public object GetAll()
        {
            return new { name = "Soy el dato que estabas buscando" };
        }
    }
}
