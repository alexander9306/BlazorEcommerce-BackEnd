namespace Sistema.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Sistema.Api.Datos;
    using Sistema.Api.Entidades.Almacen;

    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public MarcasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Marcas/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Marca>>> Listar()
        {
            return await this._context.Marcas
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        private bool MarcaExists(int id)
        {
            return _context.Marcas.Any(e => e.Id == id);
        }
    }
}
