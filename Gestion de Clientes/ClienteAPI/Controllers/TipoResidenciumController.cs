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
    public class TipoResidenciumController : ControllerBase
    {
        private readonly BdClientesContext _context;

        public TipoResidenciumController(BdClientesContext context)
        {
            _context = context;
        }

        // GET: api/TipoResidencium
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoResidencium>>> GetTipoResidencia()
        {
          if (_context.TipoResidencia == null)
          {
              return NotFound();
          }
            return await _context.TipoResidencia.ToListAsync();
        }

        // GET: api/TipoResidencium/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoResidencium>> GetTipoResidencium(byte id)
        {
          if (_context.TipoResidencia == null)
          {
              return NotFound();
          }
            var tipoResidencium = await _context.TipoResidencia.FindAsync(id);

            if (tipoResidencium == null)
            {
                return NotFound();
            }

            return tipoResidencium;
        }

        // PUT: api/TipoResidencium/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoResidencium(byte id, TipoResidencium tipoResidencium)
        {
            if (id != tipoResidencium.IdResidencia)
            {
                return BadRequest();
            }

            _context.Entry(tipoResidencium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoResidenciumExists(id))
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

        // POST: api/TipoResidencium
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoResidencium>> PostTipoResidencium(TipoResidencium tipoResidencium)
        {
          if (_context.TipoResidencia == null)
          {
              return Problem("Entity set 'BdClientesContext.TipoResidencia'  is null.");
          }
            _context.TipoResidencia.Add(tipoResidencium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoResidencium", new { id = tipoResidencium.IdResidencia }, tipoResidencium);
        }

        // DELETE: api/TipoResidencium/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoResidencium(byte id)
        {
            if (_context.TipoResidencia == null)
            {
                return NotFound();
            }
            var tipoResidencium = await _context.TipoResidencia.FindAsync(id);
            if (tipoResidencium == null)
            {
                return NotFound();
            }

            _context.TipoResidencia.Remove(tipoResidencium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoResidenciumExists(byte id)
        {
            return (_context.TipoResidencia?.Any(e => e.IdResidencia == id)).GetValueOrDefault();
        }
    }
}
