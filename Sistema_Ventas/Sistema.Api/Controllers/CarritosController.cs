namespace Sistema.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Sistema.Api.Datos;
    using Sistema.Api.Entidades.Ordenes;
    using Sistema.Api.Helpers;
    using Sistema.Api.Models.Ordenes.Carrito;
    using Sistema.Api.Models.Ordenes.Carrito.Detalle;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CarritosController : ControllerBase
    {
        private readonly DbContextSistema _context;
        private readonly CookieHelper _cookieHelper;
        private string? _guid;
        private int? _userId;

        public CarritosController(DbContextSistema context, IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
            this._cookieHelper = new CookieHelper(httpContextAccessor.HttpContext.Response, httpContextAccessor.HttpContext.Request, httpContextAccessor.HttpContext.User);
        }

        // GET: api/Carritos/Mostrar
        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<ActionResult<CarritoViewModel>> Mostrar()
        {
            var carrito = await this.VerificarCarrito(true).ConfigureAwait(false);

            if (carrito == null)
            {
                return this.NotFound();
            }

            var detalles = carrito.Detalles.Select(d => new DetalleViewModel
            {
                ProductoId = d.ProductoId,
                Producto = d.Producto.Nombre,
                Marca = d.Producto.Marca.Nombre,
                FotoPublicId = d.Producto.Fotos.FirstOrDefault()?.FotoPublicId ?? string.Empty,
                Total = d.Producto.Precio * d.Cantidad,
                Precio = d.Producto.Precio,
                Cantidad = d.Cantidad,
            });
            var detalleViewModels = detalles.ToList();
            return new CarritoViewModel
            {
                Id = carrito.Id,
                Cliente = carrito.Cliente?.Email ?? null,
                Estado = carrito.Estado,
                ClienteId = carrito.ClienteId,
                Total = detalleViewModels.Sum(d => d.Total),
                CreatedAt = carrito.CreatedAt,
                UpdatedAt = carrito.UpdatedAt,
                Detalles = detalleViewModels,
            };
        }

        // POST: api/Carritos/Agregar/
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Agregar([FromBody] ActualizarDetalleViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null)
            {
                return this.BadRequest();
            }

            var carrito = await this.VerificarCarrito(false).ConfigureAwait(false);
            var userId = this._userId;
            var guId = this._guid;

            var fecha = DateTime.Now;

            if (carrito == null)
            {
                carrito = new Carrito
                {
                    ClienteId = userId,
                    Estado = true,
                    CreatedAt = fecha,
                    UpdatedAt = fecha,
                };

                if (!this._userId.HasValue)
                {
                    carrito.ClienteGuid = this._guid;
                }

                await this._context.Carritos.AddAsync(carrito).ConfigureAwait(false);

                try
                {
                    await this._context.SaveChangesAsync().ConfigureAwait(false);

                    var detalle = new DetalleCarrito
                    {
                        CarritoId = carrito.Id,
                        ProductoId = model.ProductoId,
                        Cantidad = model.Cantidad,
                    };

                    await this._context.DetalleCarritos.AddAsync(detalle).ConfigureAwait(false);

                    await this._context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return this.BadRequest("Hubo un error al guardar sus datos.");
                }

                return this.NoContent();
            }

            carrito.ClienteId = userId;
            carrito.UpdatedAt = fecha;

            if (carrito.Detalles.Any(d => d.ProductoId == model.ProductoId))
            {
                foreach (var detalle in carrito.Detalles)
                {
                    if (detalle.ProductoId == model.ProductoId)
                    {
                        detalle.Cantidad += model.Cantidad;
                    }
                }
            }
            else
            {
                carrito.Detalles.Add(new DetalleCarrito
                {
                    ProductoId = model.ProductoId,
                    Cantidad = model.Cantidad,
                });
            }

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.CarritoExists(carrito.Id))
                {
                    return this.NotFound();
                }

                return this.BadRequest("Hubo un error al guardar sus datos.");
            }

            return this.NoContent();
        }

        private async Task<Carrito?> VerificarCarrito(bool? asNoTracking)
        {
            this._userId = this._cookieHelper.GetUserId();
            this._guid = this._cookieHelper.Get("UID") ?? this._cookieHelper.GetRequestIP();

            if (asNoTracking == true)
            {
                return await this._context.Carritos
                    .Include(c => c.Detalles)
                     .ThenInclude(d => d.Producto)
                        .ThenInclude(p => p.Fotos)
                    .Include(c => c.Detalles)
                    .ThenInclude(d => d.Producto)
                    .ThenInclude(p => p.Marca)
                    .Include(c => c.Cliente)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c =>
                        (this._userId != null) ? c.Estado && c.ClienteId == this._userId : c.Estado && c.ClienteGuid == this._guid)
                    .ConfigureAwait(false);
            }

            return await this._context.Carritos
                .Include(c => c.Detalles)
                    .ThenInclude(d => d.Producto)
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(c =>
                    this._userId.HasValue ? c.Estado && c.ClienteId == this._userId : c.Estado && c.ClienteGuid == this._guid)
                .ConfigureAwait(false);
        }

        private bool CarritoExists(int id)
        {
            return this._context.Carritos.Any(e => e.Id == id);
        }
    }
}
