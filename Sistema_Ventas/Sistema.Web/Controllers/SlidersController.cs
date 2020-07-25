namespace Api.Controllers
{
    using Api.Datos;
    using Api.Entidades.Almacen;
    using Api.Models.Almacen.Slider;

    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : Controller
    {
        private readonly DbContextSistema _context;
        private readonly Cloudinary _cloudinary;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public SlidersController(DbContextSistema context, IConfiguration config, IWebHostEnvironment hostingEnvironment)
        {
            this._context = context;
            this._hostingEnvironment = hostingEnvironment;
            var account = new Account(config.GetValue<string>("Cloudinary:CLOUDINARY_URL"));
            this._cloudinary = new Cloudinary(account);
        }

        // GET: api/Sliders/Listar/clienteId
        [HttpGet("[action]/{clienteId}")]
        public async Task<ActionResult<IEnumerable<Slider>>> Listar(int clienteId)
        {
            return await this._context.Sliders
                .Where(f => f.ClienteId == clienteId)
                .AsNoTracking().ToListAsync()
                .ConfigureAwait(false);
        }

        // Post: api/Sliders/Eliminar/id
        [HttpPost("[action]/{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            var imagen = await this._context.Sliders
                .FindAsync(id)
               .ConfigureAwait(false);

            if (imagen == null)
            {
                return this.NotFound();
            }

            var deletionResult = await BorrarImagen(imagen.ImagePublicId).ConfigureAwait(false);
            if (deletionResult.Result != "ok")
            {
                return this.BadRequest("Hubo un error con su petición.");
            }

            this._context.Sliders.Remove(imagen);

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.SliderExists(id))
                {
                    return this.NotFound();
                }

                return this.BadRequest("Hubo un error al guardar sus cambios.");
            }

            return this.NoContent();
        }

        // PUT: api/Sliders/Actualizar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Actualizar(int id, ActualizarViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null || id != model.Id)
            {
                return this.BadRequest();
            }

            var imagen = await this._context.Sliders
                .FindAsync(id)
                .ConfigureAwait(false);

            var deletionResult = await this.BorrarImagen(imagen.ImagenPublicId).ConfigureAwait(false);

            if (deletionResult.Result != "ok")
            {
                return this.BadRequest("Hubo un error con su petición.");
            }

            await this.CrearImagen(imagen, model.Imagen).ConfigureAwait(false);

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.SliderExists(id))
                {
                    return this.NotFound();
                }

                return this.BadRequest("Hubo un error al guardar sus datos.");
            }

            return this.NoContent();
        }

        // POST: api/Sliders/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<Slider>> Crear(CrearViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var imagen = new Slider
            {
                ClienteId = model.ClienteId,
                CreatedAt = DateTime.Now,
            };

            await this.CrearImagen(imagen, model.Imagen).ConfigureAwait(false);

            await this._context.Sliders.AddAsync(imagen).ConfigureAwait(false);

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return this.BadRequest("Hubo un error al guardar sus datos.");
            }

            return this.CreatedAtAction("Listar", new { Imagen.ClienteId });
        }

        private async Task<DeletionResult> BorrarImagen(string publicId)
        {
            var deletionParams = new DeletionParams(publicId);
            return await this._cloudinary.DestroyAsync(deletionParams).ConfigureAwait(false);
        }

        private async Task CrearImagen(Slider model, IFormFile imagen)
        {
            var uploadsFolder = Path.Combine(this._hostingEnvironment.WebRootPath, "images");
            var uniqueFileName = Guid.NewGuid() + "." + foto.ContentType.Replace("image/slider/", string.Empty, StringComparison.InvariantCulture);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            await using var stream = System.IO.File.Create(filePath);
            await imagen.CopyToAsync(stream).ConfigureAwait(false);

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(filePath),
            };
            await stream.DisposeAsync().ConfigureAwait(false);
            var uploadResult = await this._cloudinary.UploadAsync(uploadParams).ConfigureAwait(false);

            model.ImagenUrl = uploadResult.SecureUrl;
            model.ImagenPublicId = uploadResult.PublicId;

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        private bool SliderExists(int id)
        {
            return this._context.Sliders.Any(e => e.Id == id);
        }
    }
}
