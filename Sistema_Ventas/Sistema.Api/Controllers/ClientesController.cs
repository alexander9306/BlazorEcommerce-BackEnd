namespace Sistema.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Sistema.Api.Datos;
    using Sistema.Api.Entidades.Usuario;
    using Sistema.Api.Helpers;
    using Sistema.Shared.Entidades.Usuario.Cliente;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly DbContextSistema _context;
        private readonly PasswordHelper _passwordHelper;
        private readonly TokenHelper _tokenHelper;
        private readonly CookieHelper _cookieHelper;

        public ClientesController(DbContextSistema context, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
            this._passwordHelper = new PasswordHelper(config);
            this._tokenHelper = new TokenHelper(config);

            this._cookieHelper = new CookieHelper(httpContextAccessor.HttpContext.Response, httpContextAccessor.HttpContext.Request, httpContextAccessor.HttpContext.User);
        }

        // POST: api/clientes/login
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(ClienteLogin model)
        {
            var email = model.Email.Trim().ToUpperInvariant();

            var cliente = await this._context.Clientes
                .FirstOrDefaultAsync(a => a.Email == email)
                .ConfigureAwait(false);

            if (cliente == null)
            {
                return this.NotFound();
            }

            if (!this._passwordHelper.VerificarPasswordHash(model.Password, cliente.PasswordHash))
            {
                return this.NotFound();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, cliente.Id.ToString(CultureInfo.InvariantCulture)),
                new Claim(ClaimTypes.Email, cliente.Email),
                new Claim(ClaimTypes.Role, "Cliente"),
                new Claim("Id", cliente.Id.ToString(CultureInfo.InvariantCulture)),
                new Claim("Rol", "Cliente" ),
                new Claim("Username", cliente.Email),
            };

            var carrito = await this._context.Carritos
                .Where(c => c.Estado && c.ClienteGuid == this._cookieHelper.GetRequestIP())
                .FirstOrDefaultAsync().ConfigureAwait(false);

            if (carrito != null)
            {
                carrito.ClienteGuid = null;
                carrito.ClienteId = cliente.Id;
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }

            return this.Ok(
                new { token = this._tokenHelper.GenerarToken(claims, 60 * 24 * 5) }
            );
        }

        // GET: api/Clientes/Listar
        //[Authorize(Roles = "Administrador, Organizador")]
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<ClienteViewModel>>> Listar()
        {
            var clientes = await this._context.Clientes
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);

            return this.Ok(clientes.Select(c => new ClienteViewModel
            {
                Id = c.Id,
                Email = c.Email,
                FechaNac = c.FechaNac,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.CreatedAt,
            })
            );
        }

        // GET: api/Clientes/Mostrar/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ClienteViewModel>> Mostrar(int id)
        {
            var cliente = await this._context.Clientes.FindAsync(id).ConfigureAwait(false);

            if (cliente == null)
            {
                return this.NotFound();
            }

            return new ClienteViewModel
            {
                Id = cliente.Id,
                Email = cliente.Email,
                FechaNac = cliente.FechaNac,
                CreatedAt = cliente.CreatedAt,
                UpdatedAt = cliente.UpdatedAt,
            };
        }

        // PUT: api/Clientes/Actualizar/id
        [Authorize(Roles = "Cliente")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] ActualizarViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null || id != model.Id)
            {
                return this.BadRequest();
            }

            var cliente = await this._context.Clientes.FindAsync(id).ConfigureAwait(false);
            cliente.UpdatedAt = DateTime.Now;

            if (model.ActPassword)
            {
                this._passwordHelper.CrearPasswordHash(model.Password, out byte[] passwordHash);
                cliente.PasswordHash = passwordHash;
            }

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.ClienteExists(id))
                {
                    return this.NotFound();
                }

                return this.BadRequest("Hubo un error al guardar sus datos.");
            }

            return this.NoContent();
        }

        // POST: api/Clientes/Crear
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<ClienteViewModel>> Crear([FromBody] CrearViewModel model)
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
            this._passwordHelper.CrearPasswordHash(model.Password, out byte[] passwordHash);

            var cliente = new Cliente
            {
                Email = model.Email.ToUpperInvariant().Trim(),
                PasswordHash = passwordHash,
                FechaNac = fecha,
                CreatedAt = fecha,
                UpdatedAt = fecha,
            };

            await this._context.Clientes.AddAsync(cliente).ConfigureAwait(false);

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return this.BadRequest("Hubo un error al guardar sus datos.");
            }

            var clienteModel = new ClienteViewModel
            {
                Id = cliente.Id,
                Email = cliente.Email,
                FechaNac = cliente.FechaNac,
                CreatedAt = cliente.CreatedAt,
                UpdatedAt = cliente.UpdatedAt,
            };

            return this.CreatedAtAction("Mostrar", new { id = cliente.Id }, clienteModel);
        }

        private bool ClienteExists(int id)
        {
            return this._context.Clientes.Any(e => e.Id == id);
        }
    }
}
