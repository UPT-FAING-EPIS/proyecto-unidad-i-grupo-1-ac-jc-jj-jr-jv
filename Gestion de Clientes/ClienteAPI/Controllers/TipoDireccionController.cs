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
    public class TipoDireccionController : ControllerBase
    {
        private readonly BdClientesContext _context;

        public TipoDireccionController(BdClientesContext context)
        {
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoDireccion(byte id, TipoDireccion tipoDireccion)
        {
            if (id != tipoDireccion.IdDireccion)
            {
                return BadRequest();
            }

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
        public async Task<ActionResult<TipoDireccion>> PostTipoDireccion(TipoDireccion tipoDireccion)
        {
          if (_context.TipoDireccions == null)
          {
              return Problem("Entity set 'BdClientesContext.TipoDireccions'  is null.");
          }
            _context.TipoDireccions.Add(tipoDireccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoDireccion", new { id = tipoDireccion.IdDireccion }, tipoDireccion);
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
