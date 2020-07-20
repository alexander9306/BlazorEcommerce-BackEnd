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
    //using Sistema.Web.Models.Usuario.Administrador;

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

        // POST: api/Administradores/Crear


        private bool AdministradorExists(int id)
        {
            return _context.Administradores.Any(e => e.Id == id);
        }
    }
}
