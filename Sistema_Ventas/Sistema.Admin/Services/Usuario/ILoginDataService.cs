namespace Sistema.Admin.Services.Usuario
{
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Usuario;

    public interface ILoginDataService
    {
        Task<bool> Login(ClienteLogin model);

        Task Logout();

        Task<bool> Registrar(ClienteRegister model);
    }
}