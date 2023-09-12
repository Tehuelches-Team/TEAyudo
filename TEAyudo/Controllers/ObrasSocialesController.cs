﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using TEAyudo;
using Application.UseCase.ObrasSociales;

namespace TEAyudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObrasSocialesController : ControllerBase
    {
        private readonly TEAyudoContext _context;

        public ObrasSocialesController(TEAyudoContext context)
        {
            _context = context;
        }

        // GET: api/ObraSociales
        [HttpGet]
        public IActionResult GetObrasSociales()
        {
            return (IActionResult)_context.ObrasSociales.ToList();
        }


        //if (_context.ObrasSociales == null)
        //{
        //    return NotFound();
        //}
        //  return await _context.ObrasSociales.ToListAsync();


        //// GET: api/ObraSocialws/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ObraSocial>> GetObraSocial(int id)
        //{
        //  if (_context.ObrasSociales == null)
        //  {
        //      return NotFound();
        //  }
        //    var obraSocial = await _context.ObrasSociales.FindAsync(id);

        //    if (obraSocial == null)
        //    {
        //        return NotFound();
        //    }

        //    return obraSocial;
        //}

        //// PUT: api/ObraSocials/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutObraSocial(int id, ObraSocial obraSocial)
        //{
        //    if (id != obraSocial.ObraSocialId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(obraSocial).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ObraSocialExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/ObraSocials
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<ObraSocial>> PostObraSocial(ObraSocial obraSocial)
        //{
        //  if (_context.ObrasSociales == null)
        //  {
        //      return Problem("Entity set 'TEAyudoContext.ObrasSociales'  is null.");
        //  }
        //    _context.ObrasSociales.Add(obraSocial);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetObraSocial", new { id = obraSocial.ObraSocialId }, obraSocial);
        //}

        //// DELETE: api/ObraSocials/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteObraSocial(int id)
        //{
        //    if (_context.ObrasSociales == null)
        //    {
        //        return NotFound();
        //    }
        //    var obraSocial = await _context.ObrasSociales.FindAsync(id);
        //    if (obraSocial == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.ObrasSociales.Remove(obraSocial);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ObraSocialExists(int id)
        //{
        //    return (_context.ObrasSociales?.Any(e => e.ObraSocialId == id)).GetValueOrDefault();
        //}
    }
}
