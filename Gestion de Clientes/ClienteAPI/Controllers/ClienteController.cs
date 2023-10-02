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
    public class ClienteController : ControllerBase
    {
        private readonly BdClientesContext _context;

        public ClienteController(BdClientesContext context)
        {
            _context = context;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
          if (_context.Clientes == null)
          {
              return NotFound();
          }
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
          if (_context.Clientes == null)
          {
              return NotFound();
          }
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }
        




















        
// PUT: api/Cliente/5
[HttpPut("{id}")]
public async Task<IActionResult> PutCliente(int id, [FromBody] ClienteCreateDTO clienteDTO)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    if (id != clienteDTO.IdCliente)
    {
        return BadRequest();
    }

    var cliente = await _context.Clientes.FindAsync(id);

    if (cliente == null)
    {
        return NotFound(); // Si el cliente no existe, devolver un error 404.
    }

    // Actualizar los campos del cliente con los valores proporcionados en el DTO.
    cliente.NomCliente = clienteDTO.NomCliente;
    cliente.ApePaterno = clienteDTO.ApePaterno;
    cliente.ApeMaterno = clienteDTO.ApeMaterno;
    cliente.Numero = clienteDTO.Numero;
    cliente.Genero = clienteDTO.Genero;

    _context.Entry(cliente).State = EntityState.Modified;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!ClienteExists(id))
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




        // POST: api/Cliente
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente([FromBody] ClienteCreateDTO clienteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cliente = new Cliente
            {
                NomCliente = clienteDTO.NomCliente,
                ApePaterno = clienteDTO.ApePaterno,
                ApeMaterno = clienteDTO.ApeMaterno,
                Numero = clienteDTO.Numero,
                Genero = clienteDTO.Genero
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.IdCliente }, cliente);
        }



        
        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return (_context.Clientes?.Any(e => e.IdCliente == id)).GetValueOrDefault();
        }
    }
}
