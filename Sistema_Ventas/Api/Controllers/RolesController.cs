/*reynaldo yunior*/

namespace Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Api.Datos;
    using Api.Entidades.Usuario;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public RolesController(DbContextSistema context)
        {
            this._context = context;
        }

        // GET: api/Roles/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Rol>>> Listar()
        {
            return await this._context.Roles.Where(r => r.Estado).ToListAsync().ConfigureAwait(false);
        }

    }
}
