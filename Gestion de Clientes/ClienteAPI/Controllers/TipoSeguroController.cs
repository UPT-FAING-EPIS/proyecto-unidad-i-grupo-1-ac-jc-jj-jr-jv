using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClienteAPI.Data;
using ClienteAPI.Models;

namespace ClienteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoSeguroController : ControllerBase
    {
        private readonly BdClientesContext _context;

        public TipoSeguroController(BdClientesContext context)
        {
            _context = context;
        }

        // GET: api/TipoSeguro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoSeguro>>> GetTipoSeguros()
        {
          if (_context.TipoSeguros == null)
          {
              return NotFound();
          }
            return await _context.TipoSeguros.ToListAsync();
        }

        // GET: api/TipoSeguro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoSeguro>> GetTipoSeguro(byte id)
        {
          if (_context.TipoSeguros == null)
          {
              return NotFound();
          }
            var tipoSeguro = await _context.TipoSeguros.FindAsync(id);

            if (tipoSeguro == null)
            {
                return NotFound();
            }

            return tipoSeguro;
        }

        // PUT: api/TipoSeguro/5
[HttpPut("{id}")]
public async Task<IActionResult> PutTipoSeguro(byte id, [FromBody] TipoSeguroDTO tipoSeguroDTO)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    if (id != tipoSeguroDTO.IdSeguro)
    {
        return BadRequest();
    }

    var tipoSeguroInDatabase = await _context.TipoSeguros.FindAsync(id);

    if (tipoSeguroInDatabase == null)
    {
        return NotFound(); // Si el tipo de seguro no existe, devolver un error 404.
    }

    // Actualizar los campos del tipo de seguro con los valores proporcionados en el DTO.
    tipoSeguroInDatabase.TipSeguro = tipoSeguroDTO.TipSeguro;
    tipoSeguroInDatabase.Poliza = tipoSeguroDTO.Poliza;
    tipoSeguroInDatabase.Cobertura = tipoSeguroDTO.Cobertura;
    tipoSeguroInDatabase.DocumentoSeguro = tipoSeguroDTO.DocumentoSeguro;

    _context.Entry(tipoSeguroInDatabase).State = EntityState.Modified;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!TipoSeguroExists(id))
        {
            return NotFound();
        }
        else
        {
            throw;
        }
    }

    return NoContent();
}

// POST: api/TipoSeguro
[HttpPost]
public async Task<ActionResult<TipoSeguroDTO>> PostTipoSeguro([FromBody] TipoSeguroDTO tipoSeguroDTO)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    var tipoSeguro = new TipoSeguro
    {
        TipSeguro = tipoSeguroDTO.TipSeguro,
        Poliza = tipoSeguroDTO.Poliza,
        Cobertura = tipoSeguroDTO.Cobertura,
        DocumentoSeguro = tipoSeguroDTO.DocumentoSeguro
    };

    _context.TipoSeguros.Add(tipoSeguro);
    await _context.SaveChangesAsync();

    var tipoSeguroCreatedDTO = new TipoSeguroDTO
    {
        IdSeguro = tipoSeguro.IdSeguro,
        TipSeguro = tipoSeguro.TipSeguro,
        Poliza = tipoSeguro.Poliza,
        Cobertura = tipoSeguro.Cobertura,
        DocumentoSeguro = tipoSeguro.DocumentoSeguro
    };

    return CreatedAtAction("GetTipoSeguro", new { id = tipoSeguro.IdSeguro }, tipoSeguroCreatedDTO);
}


        // DELETE: api/TipoSeguro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoSeguro(byte id)
        {
            if (_context.TipoSeguros == null)
            {
                return NotFound();
            }
            var tipoSeguro = await _context.TipoSeguros.FindAsync(id);
            if (tipoSeguro == null)
            {
                return NotFound();
            }

            _context.TipoSeguros.Remove(tipoSeguro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoSeguroExists(byte id)
        {
            return (_context.TipoSeguros?.Any(e => e.IdSeguro == id)).GetValueOrDefault();
        }
    }
}
