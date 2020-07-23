using System.Security.Claims;
using Sistema.Web.Models.Usuario.Administrador;

namespace Sistema.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Sistema.Web.Datos;
    using Sistema.Web.Entidades.Usuario;
    using Sistema.Web.Helpers;

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DbContextSistema _context;
        private readonly PasswordHelper passwordHelper;

        public LoginController(DbContextSistema context, IConfiguration config)
        {
            _context = context;
            passwordHelper = new PasswordHelper(config);
        }

        [HttpPost("admin/[action]")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var email = model.email.ToLower();

            var usuario = await _context.Usuarios.Where(u => u.condicion == true).Include(u => u.rol).FirstOrDefaultAsync(u => u.email == email);

            if (usuario == null)
            {
                return NotFound();
            }

            if (!VerificarPasswordHash(model.password, usuario.password_hash, usuario.password_salt))
            {
                return NotFound();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.idusuario.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, usuario.rol.nombre ),
                new Claim("idusuario", usuario.idusuario.ToString() ),
                new Claim("rol", usuario.rol.nombre ),
                new Claim("nombre", usuario.nombre )
            };

            return Ok(
                new { token = GenerarToken(claims) }
            );
        }

        // GET: api/Administradores/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Administrador>>> Listar()
        {
            return await _context.Administradores.ToListAsync().ConfigureAwait(false);
        }

    }
}
