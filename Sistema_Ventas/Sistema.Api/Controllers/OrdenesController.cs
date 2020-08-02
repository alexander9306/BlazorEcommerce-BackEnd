namespace Sistema.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Sistema.Api.Datos;
    using Sistema.Api.Entidades.Ordenes;
    using Sistema.Api.Helpers;
    using Sistema.Api.Models.Ordenes.Orden;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly DbContextSistema _context;
        private readonly CookieHelper _cookieHelper;

        public OrdenesController(DbContextSistema context, IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
            this._cookieHelper = new CookieHelper(httpContextAccessor.HttpContext.Response, httpContextAccessor.HttpContext.Request, httpContextAccessor.HttpContext.User);
        }

        // GET: api/Ordenes/Listar/limit/before
        [HttpGet("[action]/{limit}/{before}")]
        [Authorize(Roles = "Cliente")]
        public async Task<ActionResult<IEnumerable<OrdenViewModel>>> Listar(int limit, string before)
        {
            var userId = this._cookieHelper.GetUserId();

            if (!userId.HasValue)
            {
                return this.Unauthorized();
            }

            var hasCursor = DateTime.TryParse(before, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var cursor);

            var ordenes = await this._context.Ordenes
                .Include(o => o.Pedido)
                .Include(o => o.Pago)
                .Where(o => o.ClienteId == userId)
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
                     Direccion = orden.Direccion,
                     Telefono = orden.Telefono,
                     CreatedAt = orden.CreatedAt,
                     UpdatedAt = orden.UpdatedAt,
            }));
        }

        // GET: api/Ordenes/ListarPorCliente/limit/before
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

            var userId = this._cookieHelper.GetUserId();

            if (!userId.HasValue)
            {
                return this.Unauthorized();
            }

            var orden = await this._context.Ordenes
                .FirstOrDefaultAsync(o => o.Id == id)
                .ConfigureAwait(false);

            orden.Direccion = model.Direccion;
            orden.Latitud = model.Latitud;
            orden.Direccion = model.Direccion;
            orden.Longitud = model.Longitud;
            orden.Telefono = model.Telefono;
            orden.UpdatedAt = DateTime.Now;

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
        [Authorize(Roles = "Cliente")]
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

            var userId = this._cookieHelper.GetUserId();

            if (!userId.HasValue)
            {
                return this.Unauthorized();
            }

            var fecha = DateTime.Now;

            var carrito = await this._context.Carritos
                .FirstOrDefaultAsync(c => c.Estado && c.ClienteId == userId)
                .ConfigureAwait(false);

            var orden = new Orden
            {
                ClienteId = userId.Value,
                CarritoId = carrito.Id,
                Latitud = model.Latitud,
                Longitud = model.Longitud,
                Direccion = model.Direccion,
                Telefono = model.Telefono,
                CreatedAt = fecha,
                UpdatedAt = fecha,
            };


            await this._context.Ordenes.AddAsync(orden).ConfigureAwait(false);

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);

                carrito.Estado = false;
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
