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
    public class ClienteDetalleController : ControllerBase
    {
        private readonly BdClientesContext _context;

        public ClienteDetalleController(BdClientesContext context)
        {
            _context = context;
        }

        // GET: api/ClienteDetalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDetalle>>> GetClienteDetalles()
        {
          if (_context.ClienteDetalles == null)
          {
              return NotFound();
          }
            return await _context.ClienteDetalles.ToListAsync();
        }

        // GET: api/ClienteDetalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDetalle>> GetClienteDetalle(byte id)
        {
          if (_context.ClienteDetalles == null)
          {
              return NotFound();
          }
            var clienteDetalle = await _context.ClienteDetalles.FindAsync(id);

            if (clienteDetalle == null)
            {
                return NotFound();
            }

            return clienteDetalle;
        }

        // PUT: api/ClienteDetalle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClienteDetalle(byte id, ClienteDetalle clienteDetalle)
        {
            if (id != clienteDetalle.IdCliDet)
            {
                return BadRequest();
            }

            _context.Entry(clienteDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteDetalleExists(id))
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

        // POST: api/ClienteDetalle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClienteDetalle>> PostClienteDetalle(ClienteDetalle clienteDetalle)
        {
          if (_context.ClienteDetalles == null)
          {
              return Problem("Entity set 'BdClientesContext.ClienteDetalles'  is null.");
          }
            _context.ClienteDetalles.Add(clienteDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClienteDetalle", new { id = clienteDetalle.IdCliDet }, clienteDetalle);
        }

        // DELETE: api/ClienteDetalle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClienteDetalle(byte id)
        {
            if (_context.ClienteDetalles == null)
            {
                return NotFound();
            }
            var clienteDetalle = await _context.ClienteDetalles.FindAsync(id);
            if (clienteDetalle == null)
            {
                return NotFound();
            }

            _context.ClienteDetalles.Remove(clienteDetalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteDetalleExists(byte id)
        {
            return (_context.ClienteDetalles?.Any(e => e.IdCliDet == id)).GetValueOrDefault();
        }
    }
}
