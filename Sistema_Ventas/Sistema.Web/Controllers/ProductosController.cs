namespace Sistema.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Sistema.Web.Datos;
    using Sistema.Web.Entidades.Almacen;
    using Sistema.Web.Models.Almacen.Producto;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly DbContextSistema _context;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ProductosController(DbContextSistema context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: api/Productos/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<ProductoViewModel>>> Listar()
        {
             var productos = await _context.Productos.
                 Include(p => p.Categoria)
                 .AsNoTracking()
                 .ToListAsync().ConfigureAwait(false);

             return Ok(productos.Select(p => new ProductoViewModel
                 {
                     Id = p.Id,
                     Nombre = p.Nombre,
                     Categoria = p.Categoria.Nombre,
                     Precio = p.Precio,
                     Estado = p.Estado,
                     Marca = p.Marca,
                     Stock = p.Stock,
                     FotoUrl = p.FotoUrl,
                     Descripcion = p.Descripcion,
                     CreatedAt = p.CreatedAt,
                     UpdatedAt = p.UpdatedAt,
                 }));
        }

        // GET: api/Productos/ListarPorCategoria/categoriaId
        [HttpGet("[action]/{categoriaId}")]
        public async Task<ActionResult<IEnumerable<Producto>>> ListarPorCategoria(int categoriaId)
        {
            var productos = await _context.Productos.Where(a => a.CategoriaId == categoriaId)
                .AsNoTracking().ToListAsync()
                .ConfigureAwait(false);

            return Ok(productos.Select(p => new ProductoViewModel
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Categoria = p.Categoria.Nombre,
                Precio = p.Precio,
                Estado = p.Estado,
                Marca = p.Marca,
                Stock = p.Stock,
                FotoUrl = p.FotoUrl,
                Descripcion = p.Descripcion,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
            }));
        }

        // GET: api/Productos/Mostrar/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ProductoViewModel>> Mostrar(int id)
        {
            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            if (producto == null)
            {
                return NotFound();
            }

            return new ProductoViewModel
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Categoria = producto.Categoria.Nombre,
                Precio = producto.Precio,
                Estado = producto.Estado,
                Marca = producto.Marca,
                Stock = producto.Stock,
                FotoUrl = producto.FotoUrl,
                Descripcion = producto.Descripcion,
                CreatedAt = producto.CreatedAt,
                UpdatedAt = producto.UpdatedAt,
            };
        }

        // PUT: api/Productos/Actualizar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromForm] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model == null || id != model.Id)
            {
                return BadRequest();
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

            if (model.Foto != null)
            {
               await CrearFoto(producto, model.Foto) !.ConfigureAwait(false);
            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    return NotFound();
                }

                return BadRequest("Hubo un error al guardar sus datos.");
            }

            return NoContent();
        }

        // POST: api/Productos/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<ProductoViewModel>> Crear([FromForm] CrearViewModel model)
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

            if (model.Foto != null)
            {
                await CrearFoto(producto, model.Foto).ConfigureAwait(false);
            }

            await _context.Productos.AddAsync(producto).ConfigureAwait(false);

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Hubo un error al guardar sus datos.");
            }

            var productoModel = new ProductoViewModel
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Categoria = producto.Categoria.Nombre,
                Precio = producto.Precio,
                Estado = producto.Estado,
                Marca = producto.Marca,
                Stock = producto.Stock,
                FotoUrl = producto.FotoUrl,
                Descripcion = producto.Descripcion,
                CreatedAt = producto.CreatedAt,
                UpdatedAt = producto.UpdatedAt,
            };

            return CreatedAtAction("Mostrar", new { id = producto.Id }, productoModel);
        }

        // PUT: api/Productos/Activar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar(int id)
        {
            return await CambiarEstado(id, true).ConfigureAwait(false);
        }

        // PUT: api/Productos/Desactivar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar(int id)
        {
            return await CambiarEstado(id, false).ConfigureAwait(false);
        }

        private async Task<IActionResult> CambiarEstado(int id, bool estado)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var producto = await _context.Productos.FindAsync(id).ConfigureAwait(false);

            if (producto == null)
            {
                return NotFound();
            }

            producto.Estado = estado;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Hubo un error al guardar sus datos.");
            }

            return NoContent();
        }

        private async Task CrearFoto(Producto model, IFormFile foto)
        {
            var uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
            var uniqueFileName = Guid.NewGuid() + "." + foto.ContentType.Replace("image/", string.Empty, StringComparison.InvariantCulture);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            await using var stream = System.IO.File.Create(filePath);
            await foto.CopyToAsync(stream).ConfigureAwait(false);

            Account account = new Account(
                "alexander-damaso-26857",
                "782676321813482",
                "qLEL5oYEYE1rjbnFpzVriyX7mTE");

            Cloudinary cloudinary = new Cloudinary(account);

            var uploadParams = new ImageUploadParams
            {

                File = new FileDescription(filePath),
            };
            await stream.DisposeAsync().ConfigureAwait(false);
            var uploadResult = cloudinary.Upload(uploadParams);

            model.FotoUrl = uploadResult.SecureUrl;
            model.FotoPublicId = uploadResult.PublicId;

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
