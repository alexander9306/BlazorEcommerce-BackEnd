namespace Sistema.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Sistema.Web.Datos;
    using Sistema.Web.Entidades.Ordenes;
    using Sistema.Web.Models.Ordenes.Orden.Pedido;
    using Sistema.Web.Models.Ordenes.Pedido;

    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public PedidosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Pedidos/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<PedidoViewModel>>> Listar()
        {
            var Pedidos = await _context.Pedidos.
                Include(Pedido => Pedido.OrdenId)
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);

            return Ok(Pedidos.Select(Pedido => new PedidoViewModel
            {
                Id = Pedido.Id,
                OrdenId = Pedido.OrdenId,
                Estado = Pedido.Estado,
                CreatedAt = Pedido.CreatedAt,
            }));
        }

        // GET: api/Pedidos/ListarPorOrden/OrdenId
        [HttpGet("[action]/{OrdenId}")]
        public async Task<ActionResult<IEnumerable<Pedido>>> ListarPorOrden(int OrdenId)
        {
            var Pedidos = await _context.Pedidos.Where(a => a.OrdenId == OrdenId)
                .AsNoTracking().ToListAsync()
                .ConfigureAwait(false);

            return Ok(Pedidos.Select(Pedido => new PedidoViewModel
            {
                Id = Pedido.Id,
                OrdenId = Pedido.OrdenId,
                Estado = Pedido.Estado,
                CreatedAt = Pedido.CreatedAt,
            }));
        }

        // GET: api/Pedidos/Mostrar/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<PedidoViewModel>> Mostrar(int id)
        {
            var Pedido = await _context.Pedidos
                .Include(p => p.OrdenId)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            if (Pedido == null)
            {
                return NotFound();
            }

            return new PedidoViewModel
            {
                Id = Pedido.Id,
                OrdenId = Pedido.OrdenId,
                Estado = Pedido.Estado,
                CreatedAt = Pedido.CreatedAt,
            };
        }

        // POST: api/Pedidos/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<PedidoViewModel>> Crear([FromForm] CrearViewModel model)
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

            var Pedido = new Pedido
            {
                OrdenId = model.OrdenId,
                CreatedAt = fecha,
            };

            await _context.Pedidos.AddAsync(Pedido).ConfigureAwait(false);

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Hubo un error al guardar sus datos.");
            }

            var PedidoModel = new PedidoViewModel
            {
                Id = Pedido.Id,
                OrdenId = Pedido.OrdenId,
                Estado = Pedido.Estado,
                CreatedAt = Pedido.CreatedAt,
            };

            return CreatedAtAction("Mostrar", new { id = Pedido.Id }, PedidoModel);
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }
    }
}
