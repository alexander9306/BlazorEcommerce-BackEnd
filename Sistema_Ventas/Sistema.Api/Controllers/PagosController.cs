namespace Sistema.Api.Controllers
{
    using System;
    using System.Collections.Generic;
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

        // GET: api/Pagos/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<PagoViewModel>>> Listar()
        {
            var pagos = await this._context.Pagos.
                Include(pago => pago.OrdenId)
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);

            return this.Ok(pagos.Select(pago => new PagoViewModel
            {
                Id = pago.Id,
                OrdenId = pago.OrdenId,
                Monto = pago.Monto,
                Estado = pago.Estado,
                CreatedAt = pago.CreatedAt,
            }));
        }

        // GET: api/Pagos/ListarPorOrden/OrdenId
        [HttpGet("[action]/{OrdenId}")]
        public async Task<ActionResult<IEnumerable<Pago>>> ListarPorOrden(int ordenId)
        {
            var pagos = await this._context.Pagos.Where(a => a.OrdenId == ordenId)
                .AsNoTracking().ToListAsync()
                .ConfigureAwait(false);

            return this.Ok(pagos.Select(pago => new PagoViewModel
            {
                Id = pago.Id,
                OrdenId = pago.OrdenId,
                Monto = pago.Monto,
                Estado = pago.Estado,
                CreatedAt = pago.CreatedAt,
            }));
        }

        // GET: api/Pagos/Mostrar/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<PagoViewModel>> Mostrar(int id)
        {
            var pago = await this._context.Pagos
                .Include(p => p.OrdenId)
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
            };

            return this.CreatedAtAction("Mostrar", new { id = pago.Id }, pagoModel);
        }

        private bool PagoExists(int id)
        {
            return this._context.Pagos.Any(e => e.Id == id);
        }
    }
}
