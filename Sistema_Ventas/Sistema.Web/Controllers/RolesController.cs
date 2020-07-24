/*reynaldo yunior*/

namespace Sistema.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Sistema.Web.Datos;
    using Sistema.Web.Entidades.Usuario;

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
