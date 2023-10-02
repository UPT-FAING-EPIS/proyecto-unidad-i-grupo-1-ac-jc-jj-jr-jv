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
    public class TipoCorreoController : ControllerBase
    {
        private readonly BdClientesContext _context;

        public TipoCorreoController(BdClientesContext context)
        {
            _context = context;
        }

        // GET: api/TipoCorreo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCorreo>>> GetTipoCorreos()
        {
          if (_context.TipoCorreos == null)
          {
              return NotFound();
          }
            return await _context.TipoCorreos.ToListAsync();
        }

        // GET: api/TipoCorreo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoCorreo>> GetTipoCorreo(byte id)
        {
          if (_context.TipoCorreos == null)
          {
              return NotFound();
          }
            var tipoCorreo = await _context.TipoCorreos.FindAsync(id);

            if (tipoCorreo == null)
            {
                return NotFound();
            }

            return tipoCorreo;
        }

// PUT: api/TipoCorreo/5
[HttpPut("{id}")]
public async Task<IActionResult> PutTipoCorreo(byte id, [FromBody] TipoCorreoDTO tipoCorreoDTO)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    if (id != tipoCorreoDTO.IdTipoCorreo)
    {
        return BadRequest();
    }

    var tipoCorreo = await _context.TipoCorreos.FindAsync(id);

    if (tipoCorreo == null)
    {
        return NotFound(); // Si el tipo de correo no existe, devolver un error 404.
    }

    // Actualizar los campos del tipo de correo con los valores proporcionados en el DTO.
    tipoCorreo.TipoCorreo1 = tipoCorreoDTO.TipoCorreo1;
    tipoCorreo.DesTipoCorreo = tipoCorreoDTO.DesTipoCorreo;

    _context.Entry(tipoCorreo).State = EntityState.Modified;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!TipoCorreoExists(id))
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


// POST: api/TipoCorreo
[HttpPost]
public async Task<ActionResult<TipoCorreoDTO>> PostTipoCorreo([FromBody] TipoCorreoDTO tipoCorreoDTO)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    var tipoCorreo = new TipoCorreo
    {
        TipoCorreo1 = tipoCorreoDTO.TipoCorreo1,
        DesTipoCorreo = tipoCorreoDTO.DesTipoCorreo
    };

    _context.TipoCorreos.Add(tipoCorreo);
    await _context.SaveChangesAsync();

    var tipoCorreoCreatedDTO = new TipoCorreoDTO
    {
        IdTipoCorreo = tipoCorreo.IdTipoCorreo,
        TipoCorreo1 = tipoCorreo.TipoCorreo1,
        DesTipoCorreo = tipoCorreo.DesTipoCorreo,
        IdCli = tipoCorreo.IdCli // Añadir el IdCli si es necesario
    };

    return CreatedAtAction("GetTipoCorreo", new { id = tipoCorreo.IdTipoCorreo }, tipoCorreoCreatedDTO);
}


        // DELETE: api/TipoCorreo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoCorreo(byte id)
        {
            if (_context.TipoCorreos == null)
            {
                return NotFound();
            }
            var tipoCorreo = await _context.TipoCorreos.FindAsync(id);
            if (tipoCorreo == null)
            {
                return NotFound();
            }

            _context.TipoCorreos.Remove(tipoCorreo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoCorreoExists(byte id)
        {
            return (_context.TipoCorreos?.Any(e => e.IdTipoCorreo == id)).GetValueOrDefault();
        }
    }
}
