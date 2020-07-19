namespace Sistema.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Sistema.Web.Datos;
    using Sistema.Web.Entidades.Almacen;
    using Sistema.Web.Models.Almacen.Categoria;

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public CategoriasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Categorias/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Categoria>>> Listar()
        {
            return await _context.Categorias
                .AsNoTracking().ToListAsync()
                .ConfigureAwait(false);
        }

        // GET: api/Categorias/Mostrar/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Categoria>> Mostrar(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id).ConfigureAwait(false);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // PUT: api/Categorias/Actualizar/id
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

            var categoria = new Categoria
            {
                Id = model.Id,
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,
                UpdatedAt = DateTime.Now,
            };

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
                {
                    return NotFound();
                }

                return BadRequest("Hubo un error al guardar sus datos.");
            }

            return NoContent();
        }

        // POST: api/Categorias/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<Categoria>> Crear(CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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

            await _context.Categorias.AddAsync(categoria).ConfigureAwait(false);

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Hubo un error al guardar sus datos.");
            }

            return CreatedAtAction("Mostrar", new { id = categoria.Id }, categoria);
        }

        // PUT: api/Categorias/Activar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar(int id)
        {
            return await CambiarEstado(id, true).ConfigureAwait(false);
        }

        // PUT: api/Categorias/Desactivar/id
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

            var categoria = await _context.Categorias.FindAsync(id).ConfigureAwait(false);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.Estado = estado;

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

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}
