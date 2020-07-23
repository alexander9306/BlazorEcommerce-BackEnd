/*reynaldo yunior*/

using System.Globalization;
using System.Security.Claims;
using System.Text;

namespace Sistema.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.WebPages;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Sistema.Web.Datos;
    using Sistema.Web.Entidades.Usuario;
    using Sistema.Web.Helpers;
    using Sistema.Web.Models.Usuario.Administrador;

    [Route("api/[controller]")]
    [ApiController]
    public class AdministradoresController : ControllerBase
    {
        private readonly DbContextSistema _context;
        private readonly PasswordHelper passwordHelper;

        public AdministradoresController(DbContextSistema context, IConfiguration config)
        {
            _context = context;
            passwordHelper = new PasswordHelper(config);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var username = model.Usuario.ToLower(CultureInfo.CurrentCulture);

            var usuario = await _context.Administradores.Where(a => a.Estado)
                .Include(a => a.Rol)
                .FirstOrDefaultAsync(a => this.IsValidEmail(username) ? a.Email == username : a.Username == username)
                .ConfigureAwait(false);

            if (usuario == null)
            {
                return NotFound();
            }

            if (!passwordHelper.VerificarPasswordHash(model.Password, usuario.PasswordHash))
            {
                return NotFound();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString(CultureInfo.CurrentCulture)),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Rol.Nombre),
                new Claim("Id", usuario.Id.ToString(CultureInfo.CurrentCulture)),
                new Claim("Rol", usuario.Rol.Nombre ),
                new Claim("Username", usuario.Username),
            };

            return Ok(
                new { token = GenerarToken(claims) }
            );
        }

        private string GenerarToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds,
                claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // GET: api/Administradores/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Administrador>>> Listar()
        {
            return await _context.Administradores.ToListAsync().ConfigureAwait(false);
        }

        // GET: api/Administradores/Mostrar/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Administrador>> Mostrar(int id)
        {
            var administrador = await _context.Administradores.FindAsync(id).ConfigureAwait(false);

            if (administrador == null)
            {
                return NotFound();
            }

            return administrador;
        }

        // PUT: api/Administradores/Actualizar/id
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

            var administrador = new Administrador
            {
                Id = model.Id,
                RolId = model.RolId,
                Email = model.Email,
                Username = model.Username,
                Estado = true,
                UpdateAt = DateTime.Now,
            };

            if (model.ActPassword)
            {
                this.passwordHelper.CrearPasswordHash(model.Password, out byte[] passwordHash);
                administrador.PasswordHash = passwordHash;
            }

            _context.Entry(administrador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorExists(id))
                {
                    return NotFound();
                }

                return BadRequest("Hubo un error al guardar sus datos.");
            }

            return NoContent();
        }

        // POST: api/Administradores/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<AdministradorViewModel>> Crear([FromForm] CrearViewModel model)
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
            this.passwordHelper.CrearPasswordHash(model.Password, out byte[] passwordHash);

            var administrador = new Administrador
            {
                RolId = model.RolId,
                Email = model.Email,
                Username = model.Username,
                PasswordHash = passwordHash,
                CreatedAt = fecha,
                UpdateAt = fecha,
            };

            await _context.Administradores.AddAsync(administrador).ConfigureAwait(false);

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Hubo un error al guardar sus datos.");
            }

            var administradorModel = new AdministradorViewModel
            {
                Id = administrador.Id,
                Email = model.Email,
                Username = model.Username,
                PasswordHash = passwordHash,
                CreatedAt = administrador.CreatedAt,
                UpdateAt = administrador.UpdateAt,
            };

            return CreatedAtAction("Mostrar", new { id = administrador.Id }, administradorModel);
        }

        // PUT: api/Administradores/Activar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar(int id)
        {
            return await CambiarEstado(id, true).ConfigureAwait(false);
        }

        // PUT: api/Administradores/Desactivar/id
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

            var administrador = await _context.Administradores.FindAsync(id).ConfigureAwait(false);

            if (administrador == null)
            {
                return NotFound();
            }

            administrador.Estado = estado;

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

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool AdministradorExists(int id)
        {
            return _context.Administradores.Any(e => e.Id == id);
        }
    }
}
