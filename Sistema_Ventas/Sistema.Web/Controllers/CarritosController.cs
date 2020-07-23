namespace Sistema.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Sistema.Web.Datos;
    using Sistema.Web.Entidades.Ordenes;
    using Sistema.Web.Helpers;
    using Sistema.Web.Models.Ordenes.Carrito;
    using Sistema.Web.Models.Ordenes.Carrito.Detalle;

    [Route("api/[controller]")]
    [ApiController]
    public class CarritosController : ControllerBase
    {
        private readonly DbContextSistema _context;
        private readonly CookieHelper cookieHelper;

        public CarritosController(DbContextSistema context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            cookieHelper = new CookieHelper(httpContextAccessor.HttpContext.Response, httpContextAccessor.HttpContext.Request, this.User);
        }

        // GET: api/Carritos/Mostrar
        [HttpGet("[action]")]
        public async Task<ActionResult<CarritoViewModel>> Mostrar()
        {

            var carrito = await VerificarCarrito(true).ConfigureAwait(false);

            if (carrito == null)
            {
                return NotFound();
            }

            var detalles = carrito.Detalles.Select(d => new DetalleViewModel
            {
                ProductoId = d.ProductoId,
                Producto = d.Producto.Nombre,
                Total = d.Producto.Precio * d.Cantidad,
                Precio = d.Producto.Precio,
                Cantidad = d.Cantidad,
            });
            var detalleViewModels = detalles.ToList();
            return new CarritoViewModel
            {
                Id = carrito.Id,
                Cliente = carrito.Cliente.Email,
                ClienteId = carrito.ClienteId,
                Total = detalleViewModels.Sum(d => d.Total),
                CreatedAt = carrito.CreatedAt,
                UpdatedAt = carrito.UpdatedAt,
                Detalles = detalleViewModels,
            };
        }

        // PUT: api/Carritos/Agregar/id
        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> Agregar(int id, [FromBody] ActualizarDetalleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model == null || id != model.ProductoId)
            {
                return BadRequest();
            }

            var carrito = await VerificarCarrito(false).ConfigureAwait(false);
            var userId = this.cookieHelper.GetUserId();
            var guId = this.cookieHelper.Get("UID");
            var fecha = DateTime.Now;

            if (carrito == null)
            {
                carrito = new Carrito
                {
                    ClienteId = userId,
                    ClienteGuid = guId,
                    Estado = true,
                    CreatedAt = fecha,
                    UpdatedAt = fecha,
                };

                await _context.Carritos.AddAsync(carrito).ConfigureAwait(false);

                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);

                    var detalle = new DetalleCarrito
                    {
                        CarritoId = carrito.Id,
                        ProductoId = model.ProductoId,
                        Cantidad = model.Cantidad,
                    };

                    await _context.DetalleCarritos.AddAsync(detalle).ConfigureAwait(false);

                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return BadRequest("Hubo un error al guardar sus datos.");
                }

                return CreatedAtAction("Mostrar", new { id = carrito.Id }, carrito);
            }

            carrito.ClienteId = userId;
            carrito.UpdatedAt = fecha;

            if (carrito.Detalles.Any(d => d.ProductoId == model.ProductoId))
            {
                foreach (var detalle in carrito.Detalles)
                {
                    if (detalle.ProductoId == model.ProductoId)
                    {
                        detalle.Cantidad = model.Cantidad;
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
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarritoExists(id))
                {
                    return NotFound();
                }

                return BadRequest("Hubo un error al guardar sus datos.");
            }

            return NoContent();
        }

        private async Task<Carrito?> VerificarCarrito(bool? AsNoTracking)
        {
            var userId = this.cookieHelper.GetUserId();
            var guId = this.cookieHelper.Get("UID");

            if (string.IsNullOrEmpty(guId) && userId == null)
            {
                return null;
            }

            if (AsNoTracking == true)
            {
                return await this._context.Carritos
                    .Include(c => c.Detalles)
                    .ThenInclude(d => d.Producto)
                    .Include(c => c.Cliente)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c =>
                        (userId != null) ? c.Estado && c.ClienteId == userId : c.Estado && c.ClienteGuid == guId)
                    .ConfigureAwait(false);
            }

            return await this._context.Carritos
                .Include(c => c.Detalles)
                .ThenInclude(d => d.Producto)
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(c =>
                    (userId != null) ? c.Estado && c.ClienteId == userId : c.Estado && c.ClienteGuid == guId)
                .ConfigureAwait(false);
        }

        private bool CarritoExists(int id)
        {
            return _context.Carritos.Any(e => e.Id == id);
        }
    }
}
