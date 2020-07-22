/*reynaldo yunior*/

namespace Sistema.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Sistema.Web.Datos;
    using Sistema.Web.Entidades.Usuario;
    using Sistema.Web.Models.Usuario.Administrador;
    using System.IO;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;

    [Route("api/[controller]")]
    [ApiController]
    public class AdministradoresController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public AdministradoresController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Administradores/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Administrador>>> Listar()
        {
            return await _context.Administradores.ToListAsync().ConfigureAwait(false);
        }

        // GET: api/Administradores/ListarAdministradores/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<Administrador>>> ListarAdministradores(int id)
        {
            return await _context.Administradores.Where(a => a.RolId == id).ToListAsync();
        }

        // GET: api/Administradores/Mostrar/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Administrador>> Mostrar(int id)
        {
            var administrador = await _context.Administradores.FindAsync(id).ConfigureAwait(false);

            if (administrador == null)
            {
                return NotFound();
            }

            return administrador;
        }

        // PUT: api/Administradores/Actualizar/id

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

            var administrador = new Administrador
            {
                Id = model.Id,
                RolId = model.RolId,
                Email = model.Email,
                Username = model.Username,
                PasswordHash = model.PasswordHash,
                PasswordSalt = model.PasswordSalt,
                Estado = true,
                UpdateAt = DateTime.Now,
            };

            _context.Entry(administrador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorExists(id))
                {
                    return NotFound();
                }

                return BadRequest("Hubo un error al guardar sus datos.");
            }

            return NoContent();
        }

        // POST: api/Administradores/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<AdministradorViewModel>> Crear([FromForm] CrearViewModel model)
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

            var administrador = new Administrador
            {
                RolId = model.RolId,
                Email = model.Email,
                Username = model.Username,
                PasswordHash = model.PasswordHash,
                PasswordSalt = model.PasswordSalt,
                CreatedAt = fecha,
                UpdateAt = fecha,
            };

            await _context.Administradores.AddAsync(administrador).ConfigureAwait(false);

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Hubo un error al guardar sus datos.");
            }

            var administradorModel = new AdministradorViewModel
            {
                Id = administrador.Id,
                Email = model.Email,
                Username = model.Username,
                PasswordHash = model.PasswordHash,
                PasswordSalt = model.PasswordSalt,
                CreatedAt = administrador.CreatedAt,
                UpdateAt = administrador.UpdateAt,
            };

            return CreatedAtAction("Mostrar", new { id = administrador.Id }, administradorModel);
        }

        // PUT: api/Administradores/Activar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar(int id)
        {
            return await CambiarEstado(id, true).ConfigureAwait(false);
        }

        // PUT: api/Administradores/Desactivar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar(int id)
        {
            return await CambiarEstado(id, false).ConfigureAwait(false);
        }

        private async Task<IActionResult> CambiarEstado(int id, bool estado)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var administrador = await _context.Administradores.FindAsync(id).ConfigureAwait(false);

            if (administrador == null)
            {
                return NotFound();
            }

            administrador.Estado = estado;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Hubo un error al guardar sus datos.");
            }

            return NoContent();
        }

        private bool AdministradorExists(int id)
        {
            return _context.Administradores.Any(e => e.Id == id);
        }
    }
}
