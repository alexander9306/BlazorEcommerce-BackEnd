namespace Sistema.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Sistema.Api.Datos;
    using Sistema.Api.Entidades.Usuario;
    using Sistema.Api.Helpers;
    using Sistema.Api.Helpers.Validators;
    using Sistema.Shared.Entidades.Usuario.Administrador;

    [Route("api/[controller]")]
    [Authorize(Roles = "Administrador,Organizador")]
    [ApiController]
    public class AdministradoresController : ControllerBase
    {
        private readonly DbContextSistema _context;
        private readonly PasswordHelper _passwordHelper;
        private readonly TokenHelper _tokenHelper;

        public AdministradoresController(DbContextSistema context, IConfiguration config)
        {
            this._context = context;
            this._passwordHelper = new PasswordHelper(config);
            this._tokenHelper = new TokenHelper(config);
        }

        // POST: api/Administradores/login
        [HttpPost("[action]")]
        [AllowAnonymous]
<<<<<<< HEAD
        public async Task<IActionResult> Login([FromBody] AdminLogin model)
=======
        public async Task<IActionResult> Login(AdminLogin model)
>>>>>>> b0ca543f7e4d1263ed170364b7ad431906ce0b72
        {
            var username = model.Usuario.ToUpperInvariant().Trim();

            var usuario = await this._context.Administradores.Where(a => a.Estado)
                .Include(a => a.Rol)
                .FirstOrDefaultAsync(a => a.Estado && EmailVerifier.IsValid(username) ? a.Email == username : a.Username == username)
                .ConfigureAwait(false);

            if (usuario == null)
            {
                return this.NotFound();
            }

            if (!this._passwordHelper.VerificarPasswordHash(model.Password, usuario.PasswordHash))
            {
                return this.NotFound();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString(CultureInfo.InvariantCulture)),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Rol.Nombre),
                new Claim("Id", usuario.Id.ToString(CultureInfo.InvariantCulture)),
                new Claim("Rol", usuario.Rol.Nombre ),
                new Claim("Username", usuario.Username),
            };

            return this.Ok(
                new { token = this._tokenHelper.GenerarToken(claims, 60 * 24 * 4) }
            );
        }

        // GET: api/Administradores/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Administrador>>> Listar()
        {
            var administradores = await this._context.Administradores
            .Include(a => a.Rol)
            .AsNoTracking()
            .ToListAsync()
            .ConfigureAwait(false);

            return this.Ok(administradores.Select(a => new AdministradorViewModel
            {
                Id = a.Id,
                Username = a.Username,
                Rol = a.Rol.Nombre,
                Email = a.Email,
                Estado = a.Estado,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt,
            }));
        }

        // GET: api/Administradores/Mostrar/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<AdministradorViewModel>> Mostrar(int id)
        {
            var administrador = await this._context.Administradores
            .Include(a => a.Rol)
            .FirstOrDefaultAsync(a => a.Id == id)
            .ConfigureAwait(false);

            if (administrador == null)
            {
                return this.NotFound();
            }

            return new AdministradorViewModel
            {
                Id = administrador.Id,
                Rol = administrador.Rol.Nombre,
                Email = administrador.Email,
                Username = administrador.Username,
                Estado = administrador.Estado,
                CreatedAt = administrador.CreatedAt,
                UpdatedAt = administrador.UpdatedAt,
            };
        }

        // PUT: api/Administradores/Actualizar/id
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

            var administrador = await this._context.Administradores.FindAsync(id).ConfigureAwait(false);

            if (administrador == null)
            {
                return this.NotFound();
            }

            administrador.RolId = model.RolId;
            administrador.Email = model.Email.Trim().ToUpperInvariant();
            administrador.Username = model.Username.Trim().ToUpperInvariant();
            administrador.UpdatedAt = DateTime.Now;

            if (model.ActPassword)
            {
                this._passwordHelper.CrearPasswordHash(model.Password, out byte[] passwordHash);
                administrador.PasswordHash = passwordHash;
            }

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.AdministradorExists(id))
                {
                    return this.NotFound();
                }

                return this.BadRequest("Hubo un error al guardar sus datos.");
            }

            return this.NoContent();
        }

        // POST: api/Administradores/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<AdministradorViewModel>> Crear(CrearViewModel model)
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

            var administrador = new Administrador
            {
                RolId = model.RolId,
                Email = model.Email.Trim().ToUpperInvariant(),
                Username = model.Username.Trim().ToUpperInvariant(),
                PasswordHash = passwordHash,
                Estado = true,
                CreatedAt = fecha,
                UpdatedAt = fecha,
            };

            await this._context.Administradores.AddAsync(administrador).ConfigureAwait(false);

            try
            {
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return this.BadRequest("Hubo un error al guardar sus datos.");
            }

            var administradorModel = new AdministradorViewModel
            {
                Id = administrador.Id,
                Email = model.Email,
                Username = model.Username,
                CreatedAt = administrador.CreatedAt,
                UpdatedAt = administrador.UpdatedAt,
            };

            return this.CreatedAtAction("Mostrar", new { id = administrador.Id }, administradorModel);
        }

        // PUT: api/Administradores/Activar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar(int id)
        {
            return await this.CambiarEstado(id, true).ConfigureAwait(false);
        }

        // PUT: api/Administradores/Desactivar/id
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

            var administrador = await this._context.Administradores.FindAsync(id).ConfigureAwait(false);

            if (administrador == null)
            {
                return this.NotFound();
            }

            administrador.Estado = estado;

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

        private bool AdministradorExists(int id)
        {
            return this._context.Administradores.Any(e => e.Id == id);
        }
    }
}
