using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IZUMI.Clientes.API.Data;
using IZUMI.Clientes.Shared.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace IZUMI.Clientes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesDbContext _context;

        public ClientesController(ClientesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get() =>
            await _context.Clientes.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();
            return cliente;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Cliente cliente)
        {
            var existe = await _context.Clientes.AnyAsync(c =>
                c.TipoDocumento == cliente.TipoDocumento &&
                c.NumeroDocumento == cliente.NumeroDocumento);

            if (existe)
                return Conflict("Cliente ya registrado.");

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok("Cliente registrado exitosamente.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Cliente cliente)
        {
            if (id != cliente.Id) return BadRequest();

            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("Cliente actualizado exitosamente.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return Ok("Cliente eliminado exitosamente.");
        }
    }
}
