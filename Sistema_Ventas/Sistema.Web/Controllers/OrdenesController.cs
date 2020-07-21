namespace Sistema.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Sistema.Web.Datos;
    using Sistema.Web.Entidades.Ordenes;
    using Sistema.Web.Models.Ordenes.Orden;

    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly DbContextSistema _context;
        private readonly IWebHostEnvironment hostingEnvironment;

        public OrdenesController(DbContextSistema context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: api/Ordenes/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<OrdenViewModel>>> Listar()
        {
             var Ordenes = await _context.Ordenes.
                 Include(orden => orden.ClienteId)
                 .AsNoTracking()
                 .ToListAsync().ConfigureAwait(false);

             return Ok(Ordenes.Select(orden => new OrdenViewModel
             {
                     Id = orden.Id,
                     ClienteId = orden.ClienteId,
                     CarritoId = orden.CarritoId,
                     Latitud = orden.Latitud,
                     Longitud = orden.Longitud,
                     Email = orden.Email,
                     Direccion = orden.Direccion,
                     Telefono = orden.Telefono,
                     CreatedAt = orden.CreatedAt,
                     UpdatedAt = orden.UpdatedAt,
             }));
        }

        // GET: api/Ordenes/ListarPorCliente/ClienteId
        [HttpGet("[action]/{ClienteId}")]
        public async Task<ActionResult<IEnumerable<Orden>>> ListarPorCliente(int ClienteId)
        {
            var Ordenes = await _context.Ordenes.Where(a => a.ClienteId == ClienteId)
                .AsNoTracking().ToListAsync()
                .ConfigureAwait(false);

            return Ok(Ordenes.Select(orden => new OrdenViewModel
            {
                Id = orden.Id,
                ClienteId = orden.ClienteId,
                CarritoId = orden.CarritoId,
                Latitud = orden.Latitud,
                Longitud = orden.Longitud,
                Email = orden.Email,
                Direccion = orden.Direccion,
                Telefono = orden.Telefono,
                CreatedAt = orden.CreatedAt,
                UpdatedAt = orden.UpdatedAt,
            }));
        }

        // GET: api/Ordenes/Mostrar/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<OrdenViewModel>> Mostrar(int id)
        {
            var Orden = await _context.Ordenes
                .Include(o => o.CarritoId)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == id).ConfigureAwait(false);

            if (Orden == null)
            {
                return NotFound();
            }

            return new OrdenViewModel
            {
                Id = Orden.Id,
                ClienteId = Orden.ClienteId,
                CarritoId = Orden.CarritoId,
                Latitud = Orden.Latitud,
                Longitud = Orden.Longitud,
                Email = Orden.Email,
                Direccion = Orden.Direccion,
                Telefono = Orden.Telefono,
                CreatedAt = Orden.CreatedAt,
                UpdatedAt = Orden.UpdatedAt,
            };
        }

        // PUT: api/Ordenes/Actualizar/id
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

            var Orden = new Orden
            {
                Id = model.Id,
                ClienteId = model.ClienteId,
                CarritoId = model.CarritoId,
                Latitud = model.Latitud,
                Longitud = model.Longitud,
                Email = model.Email,
                Direccion = model.Direccion,
                Telefono = model.Telefono,
                UpdatedAt = DateTime.Now,
            };

            _context.Entry(Orden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenExists(id))
                {
                    return NotFound();
                }

                return BadRequest("Hubo un error al guardar sus datos.");
            }

            return NoContent();
        }

        // POST: api/Ordenes/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<OrdenViewModel>> Crear([FromForm] CrearViewModel model)
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

            var Orden = new Orden
            {
                ClienteId = model.ClienteId,
                CarritoId = model.CarritoId,
                Latitud = model.Latitud,
                Longitud = model.Longitud,
                Email = model.Email,
                Direccion = model.Direccion,
                Telefono = model.Telefono,
                CreatedAt = fecha,
                UpdatedAt = fecha,
            };

            await _context.Ordenes.AddAsync(Orden).ConfigureAwait(false);

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Hubo un error al guardar sus datos.");
            }

            var OrdenModel = new OrdenViewModel
            {
                Id = Orden.Id,
                ClienteId = Orden.ClienteId,
                CarritoId = Orden.CarritoId,
                Latitud = Orden.Latitud,
                Longitud = Orden.Longitud,
                Email = Orden.Email,
                Direccion = Orden.Direccion,
                Telefono = Orden.Telefono,
                CreatedAt = Orden.CreatedAt,
                UpdatedAt = Orden.UpdatedAt,
            };

            return CreatedAtAction("Mostrar", new { id = Orden.Id }, OrdenModel);
        }

        private bool OrdenExists(int id)
        {
            return _context.Ordenes.Any(e => e.Id == id);
        }
    }
}
