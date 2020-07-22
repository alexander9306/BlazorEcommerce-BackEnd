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
    using Sistema.Web.Models.Usuario.Rol;
    using System.IO;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;

    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public RolesController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Roles/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Rol>>> Listar()
        {
            return await _context.Roles.ToListAsync().ConfigureAwait(false);
        }

        // GET: api/Roles/ListarRoles/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<Rol>>> ListarRoles(int id)
        {
            return await _context.Roles.Where(a => a.RolId == id).ToListAsync();
        }

        // PUT: api/Roles/Actualizar/id

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

            var rol = new Rol
            {
                Id = model.Id,
                Nombre = model.Nombre,
                Estado = true,
                Descripcion = model.Descripcion,
            };

            _context.Entry(rol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(id))
                {
                    return NotFound();
                }

                return BadRequest("Hubo un error al guardar sus datos.");
            }

            return NoContent();
        }

        // POST: api/Roles/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<RolViewModel>> Crear([FromForm] CrearViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rol = new Rol
            {
                Nombre = model.Nombre,
                Estado = true,
                Descripcion = model.Descripcion,
            };

            await _context.Roles.AddAsync(rol).ConfigureAwait(false);

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Hubo un error al guardar sus datos.");
            }

            var rolModel = new RolViewModel
            {
                Id = rol.Id,
                Nombre = rol.Nombre,
                Estado = rol.Estado,
                Descripcion = rol.Descripcion,
            };

            return CreatedAtAction("Mostrar", new { id = rol.Id }, rolModel);
        }

        // PUT: api/Roles/Activar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar(int id)
        {
            return await CambiarEstado(id, true).ConfigureAwait(false);
        }

        // PUT: api/Roles/Desactivar/id
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

            var rol = await _context.Roles.FindAsync(id).ConfigureAwait(false);

            if (rol == null)
            {
                return NotFound();
            }

            rol.Estado = estado;

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

        private bool RolExists(int id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }
    }
}
