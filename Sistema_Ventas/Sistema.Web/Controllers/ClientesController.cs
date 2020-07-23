/*reynaldo yunior*/

namespace Sistema.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Sistema.Web.Datos;
    using Sistema.Web.Entidades.Usuario;
    using Sistema.Web.Helpers;
    using Sistema.Web.Models.Usuario.Cliente;

    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly DbContextSistema _context;
        private readonly PasswordHelper passwordHelper;

        public ClientesController(DbContextSistema context, IConfiguration config)
        {
            _context = context;
            passwordHelper = new PasswordHelper(config);
        }

        // GET: api/Clientes/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
        {
            return await _context.Clientes.ToListAsync().ConfigureAwait(false);
        }

        // GET: api/Clientes/Mostrar/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Cliente>> Mostrar(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id).ConfigureAwait(false);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/Actualizar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromForm] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model == null || id != model.Id)
            {
                return BadRequest();
            }

            var cliente = new Cliente
            {
                Id = model.Id,
                Email = model.Email,
                UpdateAt = DateTime.Now,
            };

            if (model.ActPassword)
            {
                this.passwordHelper.CrearPasswordHash(model.Password, out byte[] passwordHash);
                cliente.PasswordHash = passwordHash;
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }

                return BadRequest("Hubo un error al guardar sus datos.");
            }

            return NoContent();
        }

        // POST: api/Clientes/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<ClienteViewModel>> Crear([FromForm] CrearViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fecha = DateTime.Now;
            this.passwordHelper.CrearPasswordHash(model.Password, out byte[] passwordHash);

            var cliente = new Cliente
            {
                Id = model.Id,
                Email = model.Email,
                PasswordHash = passwordHash,
                FechaNac = fecha,
                CreatedAt = fecha,
                UpdateAt = fecha,
            };


            await _context.Clientes.AddAsync(cliente).ConfigureAwait(false);

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Hubo un error al guardar sus datos.");
            }

            var clienteModel = new ClienteViewModel
            {
                Id = cliente.Id,
                Email = cliente.Email,
                PasswordHash = cliente.PasswordHash,
                FechaNac = cliente.FechaNac,
                CreatedAt = cliente.CreatedAt,
                UpdateAt = cliente.UpdateAt,
            };

            return CreatedAtAction("Mostrar", new { id = cliente.Id }, clienteModel);
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
