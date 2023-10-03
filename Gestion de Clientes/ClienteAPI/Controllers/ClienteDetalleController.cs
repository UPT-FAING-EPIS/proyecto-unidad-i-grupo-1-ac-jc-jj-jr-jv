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
    public class ClienteDetalleController : ControllerBase
    {
        private readonly BdClientesContext _context;
        private readonly IMapper _mapper;

        public ClienteDetalleController(IMapper mapper, BdClientesContext context)
        {
            _mapper = mapper;
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

<<<<<<< HEAD
        // PUT: api/ClienteDetalle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClienteDetalle(byte id, ClienteDetalleDTO clienteDetalleDTO)
        {
            if (id != clienteDetalleDTO.IdCliDet)
            {
                return BadRequest();
            }
            ClienteDetalle clienteDetalle = _mapper.Map<ClienteDetalle>(clienteDetalleDTO);
            _context.Entry(clienteDetalleDTO).State = EntityState.Modified;

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
        public async Task<ActionResult<ClienteDetalleDTO>> PostClienteDetalle(ClienteDetalleDTO clienteDetalleDTO)
        {
          if (_context.ClienteDetalles == null)
          {
              return Problem("Entity set 'BdClientesContext.ClienteDetalles'  is null.");
          }
        ClienteDetalle clienteDetalle = _mapper.Map<ClienteDetalle>(clienteDetalleDTO);
            _context.ClienteDetalles.Add(clienteDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClienteDetalle", new { id = clienteDetalle.IdCliDet }, clienteDetalle);
=======
// PUT: api/ClienteDetalle/5
[HttpPut("{id}")]
public async Task<IActionResult> PutClienteDetalle(byte id, [FromBody] ClienteDetalleDTO clienteDetalleDTO)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    if (id != clienteDetalleDTO.IdCliDet)
    {
        return BadRequest();
    }

    var clienteDetalle = await _context.ClienteDetalles.FindAsync(id);

    if (clienteDetalle == null)
    {
        return NotFound(); // Si el clienteDetalle no existe, devolver un error 404.
    }

    // Actualizar los campos del clienteDetalle con los valores proporcionados en el DTO.
    clienteDetalle.IdCli = clienteDetalleDTO.IdCli;
    clienteDetalle.Correo = clienteDetalleDTO.Correo;
    clienteDetalle.Seguro = clienteDetalleDTO.Seguro;
    clienteDetalle.Direccion = clienteDetalleDTO.Direccion;
    clienteDetalle.Documento = clienteDetalleDTO.Documento;
    clienteDetalle.Residencia = clienteDetalleDTO.Residencia;

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
>>>>>>> e6bea6542e711101d2348b7149afdc02d34216da
        }
    }

    return NoContent();
}


// POST: api/ClienteDetalle
[HttpPost]
public async Task<ActionResult<ClienteDetalleDTO>> PostClienteDetalle([FromBody] ClienteDetalleDTO clienteDetalleDTO)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    var clienteDetalle = new ClienteDetalle
    {
        IdCli = clienteDetalleDTO.IdCli,
        Correo = clienteDetalleDTO.Correo,
        Seguro = clienteDetalleDTO.Seguro,
        Direccion = clienteDetalleDTO.Direccion,
        Documento = clienteDetalleDTO.Documento,
        Residencia = clienteDetalleDTO.Residencia
    };

    _context.ClienteDetalles.Add(clienteDetalle);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetClienteDetalle", new { id = clienteDetalle.IdCliDet }, clienteDetalleDTO);
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
