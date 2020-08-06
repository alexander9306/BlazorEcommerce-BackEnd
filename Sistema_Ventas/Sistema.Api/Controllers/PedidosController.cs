namespace Sistema.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Sistema.Api.Datos;
    using Sistema.Api.Entidades.Ordenes;
    using Sistema.Shared.Entidades.Ordenes.Pedido;

    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public PedidosController(DbContextSistema context)
        {
            this._context = context;
        }

        // GET: api/Pedidos/Listar/limit/before
        [HttpGet("[action]/{limit}/{before}")]
        public async Task<ActionResult<IEnumerable<PedidoViewModel>>> Listar(int limit, string before)
        {
            var hasCursor = DateTime.TryParse(before, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var cursor);

            var pedidos = await this._context.Pedidos
                .Include(p => p.Orden)
                .Where(p => hasCursor ? p.UpdatedAt < cursor : p.Id > 0)
                .Take(limit)
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);

            return this.Ok(pedidos.Select(pedido => new PedidoViewModel
            {
                Id = pedido.Id,
                OrdenId = pedido.OrdenId,
                CreatedAt = pedido.CreatedAt,
                UpdatedAt = pedido.UpdatedAt,
            }));
        }

        // GET: api/Pedidos/ListarPorOrden/limit/before
        [HttpGet("[action]/{OrdenId}/{limit}/{before}")]
        public async Task<ActionResult<IEnumerable<Pedido>>> ListarPorOrden(int ordenId, int limit, string before)
        {
            var pedido = await this._context.Pedidos
                .FindAsync(ordenId)
                .ConfigureAwait(false);

            if (pedido == null)
            {
                return this.NotFound();
            }

            var hasCursor = DateTime.TryParse(before, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var cursor);

            var pedidos = await this._context.Pedidos
                .Include(p => p.Orden)
                .Where(p => p.OrdenId == pedido.OrdenId)
                .Where(p => hasCursor ? p.UpdatedAt < cursor : p.Id > 0)
                .Take(limit)
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);

            return this.Ok(pedidos.Select(pedido => new PedidoViewModel
            {
                Id = pedido.Id,
                OrdenId = pedido.OrdenId,
                CreatedAt = pedido.CreatedAt,
                UpdatedAt = pedido.UpdatedAt,
            }));
        }

        // GET: api/Pedidos/Mostrar/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<PedidoViewModel>> Mostrar(int id)
        {
            var pedido = await this._context.Pedidos
                .Include(p => p.Orden)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            if (pedido == null)
            {
                return this.NotFound();
            }

            return new PedidoViewModel
            {
                Id = pedido.Id,
                OrdenId = pedido.OrdenId,
                CreatedAt = pedido.CreatedAt,
                UpdatedAt = pedido.UpdatedAt,
            };
        }

        // POST: api/Pedidos/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<PedidoViewModel>> Crear([FromForm] CrearViewModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var fecha = DateTime.Now;

            var pedido = new Pedido
            {
                OrdenId = model.OrdenId,
                CreatedAt = fecha,
                UpdatedAt = fecha,
            };

            await this._context.Pedidos.AddAsync(pedido).ConfigureAwait(false);

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return this.BadRequest("Hubo un error al guardar sus datos.");
            }

            var pedidoModel = new PedidoViewModel
            {
                Id = pedido.Id,
                OrdenId = pedido.OrdenId,
                CreatedAt = pedido.CreatedAt,
                UpdatedAt = pedido.UpdatedAt,
            };

            return this.CreatedAtAction("Mostrar", new { id = pedido.Id }, pedidoModel);
        }

        private bool PedidoExists(int id)
        {
            return this._context.Pedidos.Any(e => e.Id == id);
        }
    }
}
