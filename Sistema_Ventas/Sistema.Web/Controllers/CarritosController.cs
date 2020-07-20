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
    using Sistema.Web.Models.Ordenes.Carrito;

    [Route("api/[controller]")]
    [ApiController]
    public class CarritosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public CarritosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Carritos/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<CarritoViewModel>>> Listar()
        {
            var carritos = await _context.Carritos
                .Include(c => c.Detalles)
                .ThenInclude(d => d.Producto)
                .Include(c => c.Cliente)
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);

            return Ok(carritos.Select(c =>
            {
                var detalles = c.Detalles.Select(d => new DetalleViewModel
                {
                    ProductoId = d.ProductoId,
                    Producto = d.Producto.Nombre,
                    Total = d.Producto.Precio * d.Cantidad,
                    Precio = d.Producto.Precio,
                    Cantidad = d.Cantidad,
                });

                var carrito = new CarritoViewModel
                {
                    Id = c.Id,
                    Cliente = c.Cliente.Email,
                    ClienteId = c.ClienteId,
                    Total = detalles.Sum(d => d.Total),
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt,
                    Detalles = detalles,
                };
                return carrito;
            }));
        }

        // GET: api/Carritos/Mostrar/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<CarritoViewModel>> Mostrar(int id)
        {
            var carrito = await _context.Carritos
                .Include(c => c.Detalles)
                .ThenInclude(d => d.Producto)
                .Include(c => c.Cliente)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);

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

        // GET: api/Carritos/Mostrar/id
        [HttpGet("[action]/{clienteId}")]
        public async Task<ActionResult<CarritoViewModel>> MostrarPorCliente(int clienteId)
        {
            var carrito = await _context.Carritos
                .Include(c => c.Detalles)
                .ThenInclude(d => d.Producto)
                .Include(c => c.Cliente)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClienteId == clienteId && c.Estado).ConfigureAwait(false);

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

        // PUT: api/Carritos/Actualizar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Actualizar(int id, ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model == null || id != model.Id)
            {
                return BadRequest();
            }

            var carrito = new Carrito
            {
                Id = model.Id,
                ClienteId = model.ClienteId,
                UpdatedAt = DateTime.Now,
            };
            _context.Entry(carrito).State = EntityState.Modified;

            model.Detalles.Select(d =>
            {
                var detalle = new DetalleCarrito
                {
                    CarritoId = carrito.Id,
                    ProductoId = d.ProductoId,
                    Cantidad = d.Cantidad,
                };
                _context.Entry(detalle).State = EntityState.Modified;

                return detalle;
            });

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

        // POST: api/Carritos/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<Carrito>> Crear(CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fecha = DateTime.Now;

            var carrito = new Carrito
            {
                ClienteId = model.ClienteId,
                Estado = true,
                CreatedAt = fecha,
                UpdatedAt = fecha,
            };

            await _context.Carritos.AddAsync(carrito).ConfigureAwait(false);

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);

                model.Detalles.Select(d =>
                {
                    var detalle = new DetalleCarrito
                    {
                        CarritoId = carrito.Id,
                        ProductoId = d.ProductoId,
                        Cantidad = d.Cantidad,
                    };
                    _context.DetalleCarritos.Add(detalle);

                    return detalle;
                });

                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Hubo un error al guardar sus datos.");
            }

            return CreatedAtAction("Mostrar", new { id = carrito.Id }, carrito);
        }

        private bool CarritoExists(int id)
        {
            return _context.Carritos.Any(e => e.Id == id);
        }
    }
}
