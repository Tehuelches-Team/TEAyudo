using Application.Interfaces;
using Domain.Entities;
using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TEAyudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _service;

        public PacientesController (IPacienteService service)
        {
            _service = service;
        }

        [HttpGet ("GetAll")]
        public IActionResult Get() 
        {
            var result = _service.getAll();
            return new JsonResult(result);
        }

       
        [HttpPost] //listo, falta chequear con un tutor hardcodeado
        public async Task<IActionResult> createPaciente(PacienteDTO paciente) 
        {
            var result = await _service.createPaciente(paciente);
            return new JsonResult(result);
        }

    }
}
