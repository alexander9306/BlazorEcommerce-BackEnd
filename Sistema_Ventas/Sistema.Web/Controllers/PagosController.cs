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
    using Sistema.Web.Models.Ordenes.Pago;

    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public PagosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Pagos/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<PagoViewModel>>> Listar()
        {
            var Pagos = await _context.Pagos.
                Include(Pago => Pago.OrdenId)
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);

            return Ok(Pagos.Select(Pago => new PagoViewModel
            {
                Id = Pago.Id,
                OrdenId = Pago.OrdenId,
                Monto = Pago.Monto,
                Estado = Pago.Estado,
                CreatedAt = Pago.CreatedAt,
            }));
        }

        // GET: api/Pagos/ListarPorOrden/OrdenId
        [HttpGet("[action]/{OrdenId}")]
        public async Task<ActionResult<IEnumerable<Pago>>> ListarPorOrden(int OrdenId)
        {
            var Pagos = await _context.Pagos.Where(a => a.OrdenId == OrdenId)
                .AsNoTracking().ToListAsync()
                .ConfigureAwait(false);

            return Ok(Pagos.Select(Pago => new PagoViewModel
            {
                Id = Pago.Id,
                OrdenId = Pago.OrdenId,
                Monto = Pago.Monto,
                Estado = Pago.Estado,
                CreatedAt = Pago.CreatedAt,
            }));
        }

        // GET: api/Pagos/Mostrar/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<PagoViewModel>> Mostrar(int id)
        {
            var Pago = await _context.Pagos
                .Include(p => p.OrdenId)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            if (Pago == null)
            {
                return NotFound();
            }

            return new PagoViewModel
            {
                Id = Pago.Id,
                OrdenId = Pago.OrdenId,
                Monto = Pago.Monto,
                Estado = Pago.Estado,
                CreatedAt = Pago.CreatedAt,
            };
        }

        // POST: api/Pagos/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<PagoViewModel>> Crear([FromForm] CrearViewModel model)
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

            var Pago = new Pago
            {
                OrdenId = model.OrdenId,
                Monto = model.Monto,
                CreatedAt = fecha,
            };

            await _context.Pagos.AddAsync(Pago).ConfigureAwait(false);

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Hubo un error al guardar sus datos.");
            }

            var PagoModel = new PagoViewModel
            {
                Id = Pago.Id,
                OrdenId = Pago.OrdenId,
                Monto = Pago.Monto,
                Estado = Pago.Estado,
                CreatedAt = Pago.CreatedAt,
            };

            return CreatedAtAction("Mostrar", new { id = Pago.Id }, PagoModel);
        }

        private bool PagoExists(int id)
        {
            return _context.Pagos.Any(e => e.Id == id);
        }
    }
}
