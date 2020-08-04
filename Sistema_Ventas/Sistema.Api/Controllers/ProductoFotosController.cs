namespace Sistema.Api.Controllers
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
    using Microsoft.Extensions.Configuration;
    using Sistema.Api.Datos;
    using Sistema.Api.Entidades.Almacen;
    using Sistema.Shared.Entidades.Almacen.ProductoFoto;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductoFotosController : ControllerBase
    {
        private readonly DbContextSistema _context;
        private readonly Cloudinary _cloudinary;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProductoFotosController(DbContextSistema context, IConfiguration config, IWebHostEnvironment hostingEnvironment)
        {
            this._context = context;
            this._hostingEnvironment = hostingEnvironment;
            var account = new Account(config.GetValue<string>("Cloudinary:CLOUDINARY_URL"));
            this._cloudinary = new Cloudinary(account);
        }

        // GET: api/ProductoFotos/Listar/productoId
        [HttpGet("[action]/{productoId}")]
        public async Task<ActionResult<IEnumerable<ProductoFoto>>> Listar(int productoId)
        {
            return await this._context.ProductoFotos
                .Where(f => f.ProductoId == productoId)
                .AsNoTracking().ToListAsync()
                .ConfigureAwait(false);
        }

        // Post: api/ProductoFotos/Eliminar/id
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
             var foto = await this._context.ProductoFotos
                 .FindAsync(id)
                .ConfigureAwait(false);

             if (foto == null)
             {
                 return this.NotFound();
             }

             var deletionResult = await BorrarFoto(foto.FotoPublicId).ConfigureAwait(false);
             if (deletionResult.Result != "ok")
             {
                 return this.BadRequest("Hubo un error con su petición.");
             }

             this._context.ProductoFotos.Remove(foto);

             try
             {
                 await this._context.SaveChangesAsync().ConfigureAwait(false);
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!this.ProductoFotoExists(id))
                 {
                     return this.NotFound();
                 }

                 return this.BadRequest("Hubo un error al guardar sus cambios.");
             }

             return this.NoContent();
        }

        // PUT: api/ProductoFotos/Actualizar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Actualizar(int id, ActualizarProductoFotoViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null || id != model.Id)
            {
                return this.BadRequest();
            }

            var foto = await this._context.ProductoFotos
                .FindAsync(id)
                .ConfigureAwait(false);

            var deletionResult = await this.BorrarFoto(foto.FotoPublicId).ConfigureAwait(false);

            if (deletionResult.Result != "ok")
            {
                return this.BadRequest("Hubo un error con su petición.");
            }

            await this.CrearFoto(foto, model.Foto).ConfigureAwait(false);

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.ProductoFotoExists(id))
                {
                    return this.NotFound();
                }

                return this.BadRequest("Hubo un error al guardar sus datos.");
            }

            return this.NoContent();
        }

        // POST: api/ProductoFotos/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<ProductoFoto>> Crear(CrearProductofotoViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var foto = new ProductoFoto
            {
                ProductoId = model.ProductoId,
                IsPrincipal = model.IsPrincipal,
                CreatedAt = DateTime.Now,
            };

            await this.CrearFoto(foto, model.Foto).ConfigureAwait(false);

            await this._context.ProductoFotos.AddAsync(foto).ConfigureAwait(false);

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return this.BadRequest("Hubo un error al guardar sus datos.");
            }

            return this.CreatedAtAction("Listar", new { foto.ProductoId });
        }

        private async Task<DeletionResult> BorrarFoto(string publicId)
        {
            var deletionParams = new DeletionParams(publicId);
            return await this._cloudinary.DestroyAsync(deletionParams).ConfigureAwait(false);
        }

        private async Task CrearFoto(ProductoFoto model, IFormFile foto)
        {
            var uploadsFolder = Path.Combine(this._hostingEnvironment.WebRootPath, "images");
            var uniqueFileName = Guid.NewGuid() + "." + foto.ContentType.Replace("image/", string.Empty, StringComparison.InvariantCulture);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            await using var stream = System.IO.File.Create(filePath);
            await foto.CopyToAsync(stream).ConfigureAwait(false);

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(filePath),
            };
            await stream.DisposeAsync().ConfigureAwait(false);
            var uploadResult = await this._cloudinary.UploadAsync(uploadParams).ConfigureAwait(false);

            model.FotoUrl = uploadResult.SecureUrl;
            model.FotoPublicId = uploadResult.PublicId;

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        private bool ProductoFotoExists(int id)
        {
            return this._context.ProductoFotos.Any(e => e.Id == id);
        }
    }
}
