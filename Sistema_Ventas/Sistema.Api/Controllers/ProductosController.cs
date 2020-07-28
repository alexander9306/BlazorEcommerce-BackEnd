namespace Sistema.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Sistema.Api.Datos;
    using Sistema.Api.Entidades.Almacen;
    using Sistema.Api.Models.Almacen.Producto;
    using Sistema.Api.Models.Almacen.ProductoFoto;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ProductosController(DbContextSistema context)
        {
            this._context = context;
        }

        // GET: api/Productos/Listar/limit/before
        [HttpGet("[action]/{limit}/{before}")]
        public async Task<ActionResult<IEnumerable<ProductoViewModel>>> Listar(int limit, string before)
        {
            var hasCursor = DateTime.TryParse(before, out var cursor);

            var productos = await this._context.Productos.
                 Include(p => p.Categoria)
                 .OrderByDescending(p => p.UpdatedAt)
                 .Where(p => hasCursor ? p.UpdatedAt < cursor : p.Id > 0)
                 .Take(limit)
                 .AsNoTracking()
                 .ToListAsync().ConfigureAwait(false);

            var fotos = await this._context.ProductoFotos
                .Where(f => productos.Select(p => p.Id).Contains(f.ProductoId))
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);

            return this.Ok(productos.Select(p => new ProductoViewModel
                 {
                     Id = p.Id,
                     Nombre = p.Nombre,
                     Categoria = p.Categoria.Nombre,
                     Precio = p.Precio,
                     Estado = p.Estado,
                     Marca = p.Marca,
                     Stock = p.Stock,
                     Descripcion = p.Descripcion,
                     CreatedAt = p.CreatedAt,
                     UpdatedAt = p.UpdatedAt,
                     Fotos = fotos.Where(f => f.ProductoId == p.Id).Select(f => new ProductoFotoViewModel
                     {
                         ProductoId = f.ProductoId,
                         CreatedAt = f.CreatedAt,
                         IsPrincipal = f.IsPrincipal,
                         FotoUrl = f.FotoUrl,
                         FotoPublicId = f.FotoPublicId,
                     }),
                 }));
        }

        // GET: api/Productos/ListarPorCategoria/categoriaid/limit/before
        [HttpGet("[action]/{limit}/{before}")]
        public async Task<ActionResult<IEnumerable<ProductoViewModel>>> ListarPorCategoria(int categoriaId, int limit, string before)
        {
            var hasCursor = DateTime.TryParse(before, out var cursor);

            var productos = await this._context.Productos.
                Include(p => p.Categoria)
                .OrderByDescending(p => p.UpdatedAt)
                .Where(p => hasCursor ? p.UpdatedAt < cursor : p.Id > 0 && p.CategoriaId == categoriaId)
                .Take(limit)
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);

            var fotos = await this._context.ProductoFotos
                .Where(f => productos.Select(p => p.Id).Contains(f.ProductoId))
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);

            return this.Ok(productos.Select(p => new ProductoViewModel
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Categoria = p.Categoria.Nombre,
                Precio = p.Precio,
                Estado = p.Estado,
                Marca = p.Marca,
                Stock = p.Stock,
                Descripcion = p.Descripcion,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                Fotos = fotos.Where(f => f.ProductoId == p.Id).Select(f => new ProductoFotoViewModel
                {
                    ProductoId = f.ProductoId,
                    CreatedAt = f.CreatedAt,
                    IsPrincipal = f.IsPrincipal,
                    FotoUrl = f.FotoUrl,
                    FotoPublicId = f.FotoPublicId,
                }),
            }));
        }

        // GET: api/Productos/ListarPorCategoria/marca/limit/before
        [HttpGet("[action]/{limit}/{before}")]
        public async Task<ActionResult<IEnumerable<ProductoViewModel>>> ListarPorMarca(string marca, int limit, string before)
        {
            var hasCursor = DateTime.TryParse(before, out var cursor);

            var productos = await this._context.Productos.
                Include(p => p.Categoria)
                .OrderByDescending(p => p.UpdatedAt)
                .Where(p => hasCursor ? p.UpdatedAt < cursor : p.Id > 0 && p.Marca == marca)
                .Take(limit)
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);

            var fotos = await this._context.ProductoFotos
                .Where(f => productos.Select(p => p.Id).Contains(f.ProductoId))
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);

            return this.Ok(productos.Select(p => new ProductoViewModel
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Categoria = p.Categoria.Nombre,
                Precio = p.Precio,
                Estado = p.Estado,
                Marca = p.Marca,
                Stock = p.Stock,
                Descripcion = p.Descripcion,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                Fotos = fotos.Where(f => f.ProductoId == p.Id).Select(f => new ProductoFotoViewModel
                {
                    ProductoId = f.ProductoId,
                    CreatedAt = f.CreatedAt,
                    IsPrincipal = f.IsPrincipal,
                    FotoUrl = f.FotoUrl,
                    FotoPublicId = f.FotoPublicId,
                }),
            }));
        }

        // GET: api/Productos/Mostrar/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ProductoViewModel>> Mostrar(int id)
        {
            var producto = await this._context.Productos
                .Include(p => p.Categoria)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            if (producto == null)
            {
                return this.NotFound();
            }

            var fotos = await this._context.ProductoFotos
                .Where(f => f.ProductoId == producto.Id)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);

            return new ProductoViewModel
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Categoria = producto.Categoria.Nombre,
                Precio = producto.Precio,
                Estado = producto.Estado,
                Marca = producto.Marca,
                Stock = producto.Stock,
                Descripcion = producto.Descripcion,
                CreatedAt = producto.CreatedAt,
                UpdatedAt = producto.UpdatedAt,
                Fotos = fotos.Select(f => new ProductoFotoViewModel
                {
                    ProductoId = f.ProductoId,
                    CreatedAt = f.CreatedAt,
                    IsPrincipal = f.IsPrincipal,
                    FotoUrl = f.FotoUrl,
                    FotoPublicId = f.FotoPublicId,
                }),
            };
        }

        // PUT: api/Productos/Actualizar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromForm] ActualizarViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null || id != model.Id)
            {
                return this.BadRequest();
            }

            var producto = new Producto
            {
                Id = model.Id,
                CategoriaId = model.CategoriaId,
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,
                Precio = model.Precio,
                Marca = model.Marca,
                Stock = model.Stock,
                Estado = true,
                UpdatedAt = DateTime.Now,
            };

            this._context.Entry(producto).State = EntityState.Modified;

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.ProductoExists(id))
                {
                    return this.NotFound();
                }

                return this.BadRequest("Hubo un error al guardar sus datos.");
            }

            return this.NoContent();
        }

        // POST: api/Productos/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<ProductoViewModel>> Crear([FromForm] CrearViewModel model)
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

            var producto = new Producto
            {
                Nombre = model.Nombre,
                CategoriaId = model.CategoriaId,
                Descripcion = model.Descripcion,
                Precio = model.Precio,
                Marca = model.Marca,
                Stock = model.Stock,
                CreatedAt = fecha,
                UpdatedAt = fecha,
            };

            await this._context.Productos.AddAsync(producto).ConfigureAwait(false);

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return this.BadRequest("Hubo un error al guardar sus datos.");
            }

            var productoModel = new ProductoViewModel
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Estado = producto.Estado,
                Marca = producto.Marca,
                Stock = producto.Stock,
                Descripcion = producto.Descripcion,
                CreatedAt = producto.CreatedAt,
                UpdatedAt = producto.UpdatedAt,
            };

            return this.CreatedAtAction("Mostrar", new { id = producto.Id }, productoModel);
        }

        // PUT: api/Productos/Activar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar(int id)
        {
            return await this.CambiarEstado(id, true).ConfigureAwait(false);
        }

        // PUT: api/Productos/Desactivar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar(int id)
        {
            return await this.CambiarEstado(id, false).ConfigureAwait(false);
        }

        private async Task<IActionResult> CambiarEstado(int id, bool estado)
        {
            if (id <= 0)
            {
                return this.BadRequest();
            }

            var producto = await this._context.Productos.FindAsync(id).ConfigureAwait(false);

            if (producto == null)
            {
                return this.NotFound();
            }

            producto.Estado = estado;

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return this.BadRequest("Hubo un error al guardar sus datos.");
            }

            return this.NoContent();
        }

        private bool ProductoExists(int id)
        {
            return this._context.Productos.Any(e => e.Id == id);
        }
    }
}
