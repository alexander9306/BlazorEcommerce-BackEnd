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
    using Sistema.Shared.Entidades.Almacen.Categoria;

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public CategoriasController(DbContextSistema context)
        {
            this._context = context;
        }

        // GET: api/Categorias/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Categoria>>> Listar()
        {
            return await this._context.Categorias
                .AsNoTracking().ToListAsync()
                .ConfigureAwait(false);
        }

        // GET: api/Categorias/Mostrar/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Categoria>> Mostrar(int id)
        {
            var categoria = await this._context.Categorias.FindAsync(id).ConfigureAwait(false);

            if (categoria == null)
            {
                return this.NotFound();
            }

            return categoria;
        }

        // PUT: api/Categorias/Actualizar/id
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

            var categoria = await this._context.Categorias.FindAsync(id).ConfigureAwait(false);

            if (categoria == null)
            {
                return this.NotFound();
            }

            categoria.Nombre = model.Nombre;
            categoria.Descripcion = model.Descripcion;
            categoria.UpdatedAt = DateTime.Now;

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.CategoriaExists(id))
                {
                    return this.NotFound();
                }

                return this.BadRequest("Hubo un error al guardar sus datos.");
            }

            return this.NoContent();
        }

        // POST: api/Categorias/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<Categoria>> Crear(CrearViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var fecha = DateTime.Now;

            var categoria = new Categoria
            {
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,
                Estado = true,
                CreatedAt = fecha,
                UpdatedAt = fecha,
            };

            await this._context.Categorias.AddAsync(categoria).ConfigureAwait(false);

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return this.BadRequest("Hubo un error al guardar sus datos.");
            }

            return this.CreatedAtAction("Mostrar", new { id = categoria.Id }, categoria);
        }

        // PUT: api/Categorias/Activar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar(int id)
        {
            return await this.CambiarEstado(id, true).ConfigureAwait(false);
        }

        // PUT: api/Categorias/Desactivar/id
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

            var categoria = await this._context.Categorias.FindAsync(id).ConfigureAwait(false);

            if (categoria == null)
            {
                return this.NotFound();
            }

            categoria.Estado = estado;

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

        private bool CategoriaExists(int id)
        {
            return this._context.Categorias.Any(e => e.Id == id);
        }
    }
}
