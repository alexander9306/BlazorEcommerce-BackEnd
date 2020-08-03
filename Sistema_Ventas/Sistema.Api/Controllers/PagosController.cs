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
    using Sistema.Api.Models.Ordenes.Pago;

    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public PagosController(DbContextSistema context)
        {
            this._context = context;
        }

        // GET: api/Pagos/Listar/limit/before
        [HttpGet("[action]/{limit}/{before}")]
        public async Task<ActionResult<IEnumerable<PagoViewModel>>> Listar(int limit, string before)
        {
            var hasCursor = DateTime.TryParse(before, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var cursor);

            var pagos = await this._context.Pagos
                .Include(p => p.Orden)
                .Where(p => hasCursor ? p.UpdatedAt < cursor : p.Id > 0)
                .Take(limit)
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);

            return this.Ok(pagos.Select(pago => new PagoViewModel
            {
                Id = pago.Id,
                OrdenId = pago.OrdenId,
                Monto = pago.Monto,
                Estado = pago.Estado,
                CreatedAt = pago.CreatedAt,
                UpdatedAt = pago.UpdatedAt,
            }));
        }

        // GET: api/Pagos/ListarPorOrden/OrdenId/limit/before
        [HttpGet("[action]/{OrdenId}/{limit}/{before}")]
        public async Task<ActionResult<IEnumerable<Pago>>> ListarPorOrden(int ordenId, int limit, string before)
        {
            var pago = await this._context.Pedidos
                .FindAsync(ordenId)
                .ConfigureAwait(false);

            if (pago == null)
            {
                return this.NotFound();
            }

            var hasCursor = DateTime.TryParse(before, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var cursor);

            var pagos = await this._context.Pagos
                .Include(p => p.Orden)
                .Where(p => p.OrdenId == pago.OrdenId)
                .Where(p => hasCursor ? p.UpdatedAt < cursor : p.Id > 0)
                .Take(limit)
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);

            return this.Ok(pagos.Select(pago => new PagoViewModel
            {
                Id = pago.Id,
                OrdenId = pago.OrdenId,
                Monto = pago.Monto,
                Estado = pago.Estado,
                CreatedAt = pago.CreatedAt,
                UpdatedAt = pago.UpdatedAt,
            }));
        }

        // GET: api/Pagos/Mostrar/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<PagoViewModel>> Mostrar(int id)
        {
            var pago = await this._context.Pagos
                .Include(p => p.Orden)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            if (pago == null)
            {
                return this.NotFound();
            }

            return new PagoViewModel
            {
                Id = pago.Id,
                OrdenId = pago.OrdenId,
                Monto = pago.Monto,
                Estado = pago.Estado,
                CreatedAt = pago.CreatedAt,
                UpdatedAt = pago.UpdatedAt,
            };
        }

        // POST: api/Pagos/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<PagoViewModel>> Crear([FromForm] CrearViewModel model)
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

            var pago = new Pago
            {
                OrdenId = model.OrdenId,
                Monto = model.Monto,
                CreatedAt = fecha,
                UpdatedAt = fecha,
            };

            await this._context.Pagos.AddAsync(pago).ConfigureAwait(false);

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return this.BadRequest("Hubo un error al guardar sus datos.");
            }

            var pagoModel = new PagoViewModel
            {
                Id = pago.Id,
                OrdenId = pago.OrdenId,
                Monto = pago.Monto,
                Estado = pago.Estado,
                CreatedAt = pago.CreatedAt,
                UpdatedAt = pago.UpdatedAt,
            };

            return this.CreatedAtAction("Mostrar", new { id = pago.Id }, pagoModel);
        }

        private bool PagoExists(int id)
        {
            return this._context.Pagos.Any(e => e.Id == id);
        }
    }
}
