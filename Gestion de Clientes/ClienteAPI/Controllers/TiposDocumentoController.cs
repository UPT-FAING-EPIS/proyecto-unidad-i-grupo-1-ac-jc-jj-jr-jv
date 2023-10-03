using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClienteAPI.Data;
using ClienteAPI.Models;
using AutoMapper;

namespace ClienteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDocumentoController : ControllerBase
    {
        private readonly BdClientesContext _context;
        private readonly IMapper _mapper;

        public TiposDocumentoController(IMapper mapper, BdClientesContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/TiposDocumento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposDocumento>>> GetTiposDocumentos()
        {
          if (_context.TiposDocumentos == null)
          {
              return NotFound();
          }
            return await _context.TiposDocumentos.ToListAsync();
        }

        // GET: api/TiposDocumento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiposDocumento>> GetTiposDocumento(byte id)
        {
          if (_context.TiposDocumentos == null)
          {
              return NotFound();
          }
            var tiposDocumento = await _context.TiposDocumentos.FindAsync(id);

            if (tiposDocumento == null)
            {
                return NotFound();
            }

            return tiposDocumento;
        }

        // PUT: api/TiposDocumento/5
<<<<<<< HEAD
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiposDocumento(byte id, TiposDocumentoDTO tiposDocumentoDTO)
        {
            if (id != tiposDocumentoDTO.IdTipoDocumento)
            {
                return BadRequest();
            }
            TiposDocumento tiposDocumento = _mapper.Map<TiposDocumento>(tiposDocumentoDTO);
            _context.Entry(tiposDocumento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposDocumentoExists(id))
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

        // POST: api/TiposDocumento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TiposDocumentoDTO>> PostTiposDocumento(TiposDocumentoDTO tiposDocumentoDTO)
        {
          if (_context.TiposDocumentos == null)
          {
              return Problem("Entity set 'BdClientesContext.TiposDocumentos'  is null.");
          }
          TiposDocumento tiposDocumento = _mapper.Map<TiposDocumento>(tiposDocumentoDTO);
            _context.TiposDocumentos.Add(tiposDocumento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiposDocumento", new { id = tiposDocumento.IdTipoDocumento }, tiposDocumento);
=======
[HttpPut("{id}")]
public async Task<IActionResult> PutTiposDocumento(byte id, [FromBody] TiposDocumentoDTO tiposDocumentoDTO)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    if (id != tiposDocumentoDTO.IdTipoDocumento)
    {
        return BadRequest();
    }

    var tiposDocumentoInDatabase = await _context.TiposDocumentos.FindAsync(id);

    if (tiposDocumentoInDatabase == null)
    {
        return NotFound(); // Si el tipo de documento no existe, devolver un error 404.
    }

    // Actualizar los campos del tipo de documento con los valores proporcionados en el DTO.
    tiposDocumentoInDatabase.DesTipoDocumento = tiposDocumentoDTO.DesTipoDocumento;
    tiposDocumentoInDatabase.NumDocumento = tiposDocumentoDTO.NumDocumento;
    tiposDocumentoInDatabase.FechaEmision = tiposDocumentoDTO.FechaEmision;
    tiposDocumentoInDatabase.FechaVencimiento = tiposDocumentoDTO.FechaVencimiento;
    tiposDocumentoInDatabase.Imagen = tiposDocumentoDTO.Imagen;

    _context.Entry(tiposDocumentoInDatabase).State = EntityState.Modified;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!TiposDocumentoExists(id))
        {
            return NotFound();
        }
        else
        {
            throw;
>>>>>>> e6bea6542e711101d2348b7149afdc02d34216da
        }
    }

    return NoContent();
}

// POST: api/TiposDocumento
[HttpPost]
public async Task<ActionResult<TiposDocumentoDTO>> PostTiposDocumento([FromBody] TiposDocumentoDTO tiposDocumentoDTO)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    var tiposDocumento = new TiposDocumento
    {
        DesTipoDocumento = tiposDocumentoDTO.DesTipoDocumento,
        NumDocumento = tiposDocumentoDTO.NumDocumento,
        FechaEmision = tiposDocumentoDTO.FechaEmision,
        FechaVencimiento = tiposDocumentoDTO.FechaVencimiento,
        Imagen = tiposDocumentoDTO.Imagen
    };

    _context.TiposDocumentos.Add(tiposDocumento);
    await _context.SaveChangesAsync();

    var tiposDocumentoCreatedDTO = new TiposDocumentoDTO
    {
        IdTipoDocumento = tiposDocumento.IdTipoDocumento,
        DesTipoDocumento = tiposDocumento.DesTipoDocumento,
        NumDocumento = tiposDocumento.NumDocumento,
        FechaEmision = tiposDocumento.FechaEmision,
        FechaVencimiento = tiposDocumento.FechaVencimiento,
        Imagen = tiposDocumento.Imagen
    };

    return CreatedAtAction("GetTiposDocumento", new { id = tiposDocumento.IdTipoDocumento }, tiposDocumentoCreatedDTO);
}


        // DELETE: api/TiposDocumento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiposDocumento(byte id)
        {
            if (_context.TiposDocumentos == null)
            {
                return NotFound();
            }
            var tiposDocumento = await _context.TiposDocumentos.FindAsync(id);
            if (tiposDocumento == null)
            {
                return NotFound();
            }

            _context.TiposDocumentos.Remove(tiposDocumento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiposDocumentoExists(byte id)
        {
            return (_context.TiposDocumentos?.Any(e => e.IdTipoDocumento == id)).GetValueOrDefault();
        }
    }
}
