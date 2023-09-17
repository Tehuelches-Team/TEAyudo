﻿using Application.Interfaces;
using Domain.Entities;
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

       
        [HttpPost] //listo
        public async Task<IActionResult> createPaciente(Paciente paciente) 
        {
            var result = _service.createPaciente(paciente);
            return new JsonResult(result);
        }

    }
}
