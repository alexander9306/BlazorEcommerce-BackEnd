namespace Sistema.Ecommerce.Services.Usuario
{
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Usuario;
    using Sistema.Shared.Entidades.Usuario.Cliente;

    public interface ILoginDataService
    {
        Task<bool> Login(ClienteLogin model);

        Task Logout();

        Task<bool> Registrar(CrearViewModel model);
    }
}