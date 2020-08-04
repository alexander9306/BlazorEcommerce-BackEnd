namespace Sistema.Shared.Services.Usuario.Administrador
{
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Usuario.Administrador;

    public interface IAdminDataService
    {
        Task<bool> Login(AdminLogin model);

        Task Logout();

        Task<bool> Registrar(CrearViewModel model);
    }
}