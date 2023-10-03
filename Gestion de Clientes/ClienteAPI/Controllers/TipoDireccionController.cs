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
    public class TipoDireccionController : ControllerBase
    {
        private readonly BdClientesContext _context;
        private readonly IMapper _mapper;
        public TipoDireccionController(IMapper mapper,BdClientesContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/TipoDireccion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDireccion>>> GetTipoDireccions()
        {
          if (_context.TipoDireccions == null)
          {
              return NotFound();
          }
            return await _context.TipoDireccions.ToListAsync();
        }

        // GET: api/TipoDireccion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDireccion>> GetTipoDireccion(byte id)
        {
          if (_context.TipoDireccions == null)
          {
              return NotFound();
          }
            var tipoDireccion = await _context.TipoDireccions.FindAsync(id);

            if (tipoDireccion == null)
            {
                return NotFound();
            }

            return tipoDireccion;
        }
// PUT: api/TipoDireccion/5
[HttpPut("{id}")]
public async Task<IActionResult> PutTipoDireccion(byte id, [FromBody] TipoDireccionDTO tipoDireccionDTO)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

<<<<<<< HEAD
        // PUT: api/TipoDireccion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoDireccion(byte id, TipoDireccionDTO tipoDireccionDTO)
        {
            if (id != tipoDireccionDTO.IdDireccion)
            {
                return BadRequest();
            }
            TipoDireccion tipoDireccion = _mapper.Map<TipoDireccion>(tipoDireccionDTO);
            _context.Entry(tipoDireccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDireccionExists(id))
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

        // POST: api/TipoDireccion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoDireccionDTO>> PostTipoDireccion(TipoDireccionDTO tipoDireccionDTO)
        {
          if (_context.TipoDireccions == null)
          {
              return Problem("Entity set 'BdClientesContext.TipoDireccions'  is null.");
          }
          TipoDireccion tipoDireccion = _mapper.Map<TipoDireccion>(tipoDireccionDTO);
            _context.TipoDireccions.Add(tipoDireccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoDireccion", new { id = tipoDireccion.IdDireccion }, tipoDireccion);
=======
    if (id != tipoDireccionDTO.IdDireccion)
    {
        return BadRequest();
    }

    var tipoDireccionInDatabase = await _context.TipoDireccions.FindAsync(id);

    if (tipoDireccionInDatabase == null)
    {
        return NotFound(); // Si el tipo de dirección no existe, devolver un error 404.
    }

    // Actualizar los campos del tipo de dirección con los valores proporcionados en el DTO.
    tipoDireccionInDatabase.TipoDireccion1 = tipoDireccionDTO.TipoDireccion1;
    tipoDireccionInDatabase.DesTipoDireccion = tipoDireccionDTO.DesTipoDireccion;
    tipoDireccionInDatabase.Calle = tipoDireccionDTO.Calle;
    tipoDireccionInDatabase.Referencia = tipoDireccionDTO.Referencia;

    _context.Entry(tipoDireccionInDatabase).State = EntityState.Modified;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!TipoDireccionExists(id))
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

// POST: api/TipoDireccion
[HttpPost]
public async Task<ActionResult<TipoDireccionDTO>> PostTipoDireccion([FromBody] TipoDireccionDTO tipoDireccionDTO)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    var tipoDireccion = new TipoDireccion
    {
        TipoDireccion1 = tipoDireccionDTO.TipoDireccion1,
        DesTipoDireccion = tipoDireccionDTO.DesTipoDireccion,
        Calle = tipoDireccionDTO.Calle,
        Referencia = tipoDireccionDTO.Referencia
    };

    _context.TipoDireccions.Add(tipoDireccion);
    await _context.SaveChangesAsync();

    var tipoDireccionCreatedDTO = new TipoDireccionDTO
    {
        IdDireccion = tipoDireccion.IdDireccion,
        TipoDireccion1 = tipoDireccion.TipoDireccion1,
        DesTipoDireccion = tipoDireccion.DesTipoDireccion,
        Calle = tipoDireccion.Calle,
        Referencia = tipoDireccion.Referencia
    };

    return CreatedAtAction("GetTipoDireccion", new { id = tipoDireccion.IdDireccion }, tipoDireccionCreatedDTO);
}



        // DELETE: api/TipoDireccion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoDireccion(byte id)
        {
            if (_context.TipoDireccions == null)
            {
                return NotFound();
            }
            var tipoDireccion = await _context.TipoDireccions.FindAsync(id);
            if (tipoDireccion == null)
            {
                return NotFound();
            }

            _context.TipoDireccions.Remove(tipoDireccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoDireccionExists(byte id)
        {
            return (_context.TipoDireccions?.Any(e => e.IdDireccion == id)).GetValueOrDefault();
        }
    }
}
