using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using TEAyudo.DTO;

namespace TEAyudo.Controllers
{
    [Route("api/pacientes")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly TEAyudoContext _context;

        public PacienteController(TEAyudoContext context)
        {
            _context = context;
        }

    }
}
