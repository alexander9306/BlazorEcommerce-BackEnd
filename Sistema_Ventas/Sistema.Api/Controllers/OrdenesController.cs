namespace Sistema.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Sistema.Api.Datos;
    using Sistema.Api.Entidades.Ordenes;
    using Sistema.Api.Models.Ordenes.Orden;

    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public OrdenesController(DbContextSistema context)
        {
            this._context = context;
        }

        // GET: api/Ordenes/Listar/limit/before
        [HttpGet("[action]/{limit}/{before}")]
        public async Task<ActionResult<IEnumerable<OrdenViewModel>>> Listar(int limit, string before)
        {
            var hasCursor = DateTime.TryParse(before, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var cursor);

            var ordenes = await this._context.Ordenes
                .Include(o => o.Pedido)
                .Include(o => o.Pago)
                .Where(o => hasCursor ? o.UpdatedAt < cursor : o.Id > 0)
                .Take(limit)
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);

            return this.Ok(ordenes.Select(orden => new OrdenViewModel
            {
                     Id = orden.Id,
                     ClienteId = orden.ClienteId,
                     CarritoId = orden.CarritoId,
                     Latitud = orden.Latitud,
                     Longitud = orden.Longitud,
                     Email = orden.Email,
                     Direccion = orden.Direccion,
                     Telefono = orden.Telefono,
                     CreatedAt = orden.CreatedAt,
                     UpdatedAt = orden.UpdatedAt,
            }));
        }

        // GET: api/Ordenes/Listar/limit/before
        [HttpGet("[action]/{ClienteId}/{limit}/{before}")]
        public async Task<ActionResult<IEnumerable<Orden>>> ListarPorCliente(int clienteId, int limit, string before)
        {
            var orden = await this._context.Ordenes.FindAsync(clienteId).ConfigureAwait(false);

            if (orden == null)
            {
                return this.NotFound();
            }

            var hasCursor = DateTime.TryParse(before, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var cursor);

            var ordenes = await this._context.Ordenes
                .Include(o => o.Pedido)
                .Include(o => o.Pago)
                .Where(o => o.CarritoId == orden.CarritoId)
                .Where(o => hasCursor ? o.UpdatedAt < cursor : o.Id > 0)
                .Take(limit)
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);

            return this.Ok(ordenes.Select(o => new OrdenViewModel
            {
                Id = o.Id,
                ClienteId = o.ClienteId,
                CarritoId = o.CarritoId,
                Latitud = o.Latitud,
                Longitud = o.Longitud,
                Email = o.Email,
                Direccion = o.Direccion,
                Telefono = o.Telefono,
                CreatedAt = o.CreatedAt,
                UpdatedAt = o.UpdatedAt,
            }));
        }

        // GET: api/Ordenes/Mostrar/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<OrdenViewModel>> Mostrar(int id)
        {
            var orden = await this._context.Ordenes
                .Include(o => o.Pedido)
                .Include(o => o.Pago)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == id).ConfigureAwait(false);

            if (orden == null)
            {
                return this.NotFound();
            }

            return new OrdenViewModel
            {
                Id = orden.Id,
                ClienteId = orden.ClienteId,
                CarritoId = orden.CarritoId,
                Latitud = orden.Latitud,
                Longitud = orden.Longitud,
                Email = orden.Email,
                Direccion = orden.Direccion,
                Telefono = orden.Telefono,
                CreatedAt = orden.CreatedAt,
                UpdatedAt = orden.UpdatedAt,
            };
        }

        // PUT: api/Ordenes/Actualizar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] ActualizarViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null || id != model.Id)
            {
                return this.BadRequest();
            }

            var orden = new Orden
            {
                Id = model.Id,
                ClienteId = model.ClienteId,
                CarritoId = model.CarritoId,
                Latitud = model.Latitud,
                Longitud = model.Longitud,
                Email = model.Email,
                Direccion = model.Direccion,
                Telefono = model.Telefono,
                UpdatedAt = DateTime.Now,
            };

            this._context.Entry(orden).State = EntityState.Modified;

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.OrdenExists(id))
                {
                    return this.NotFound();
                }

                return this.BadRequest("Hubo un error al guardar sus datos.");
            }

            return this.NoContent();
        }

        // POST: api/Ordenes/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<OrdenViewModel>> Crear([FromBody] CrearViewModel model)
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

            var orden = new Orden
            {
                ClienteId = model.ClienteId,
                CarritoId = model.CarritoId,
                Latitud = model.Latitud,
                Longitud = model.Longitud,
                Email = model.Email,
                Direccion = model.Direccion,
                Telefono = model.Telefono,
                CreatedAt = fecha,
                UpdatedAt = fecha,
            };

            await this._context.Ordenes.AddAsync(orden).ConfigureAwait(false);

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return this.BadRequest("Hubo un error al guardar sus datos.");
            }

            var ordenModel = new OrdenViewModel
            {
                Id = orden.Id,
                ClienteId = orden.ClienteId,
                CarritoId = orden.CarritoId,
                Latitud = orden.Latitud,
                Longitud = orden.Longitud,
                Email = orden.Email,
                Direccion = orden.Direccion,
                Telefono = orden.Telefono,
                CreatedAt = orden.CreatedAt,
                UpdatedAt = orden.UpdatedAt,
            };

            return this.CreatedAtAction("Mostrar", new { id = orden.Id }, ordenModel);
        }

        private bool OrdenExists(int id)
        {
            return this._context.Ordenes.Any(e => e.Id == id);
        }
    }
}
