namespace Sistema.Admin.Services.Usuario
{
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Usuario;

    public interface ILoginDataService
    {
        Task<bool> Login(AdminLogin model);

        Task Logout();

        Task<bool> Registrar(AdminRegister model);
    }
}