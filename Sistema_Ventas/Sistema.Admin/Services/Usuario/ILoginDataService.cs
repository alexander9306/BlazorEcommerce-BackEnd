namespace Sistema.Admin.Services.Usuario
{
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Usuario.Administrador;

    public interface ILoginDataService
    {
        Task<bool> Login(AdminLogin model);

        Task Logout();

        Task<bool> Registrar(CrearViewModel model);
    }
}