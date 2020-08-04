namespace Sistema.Shared.Services.Usuario.Cliente
{
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Usuario.Cliente;

    public interface IClienteDataService
    {
        Task<bool> Login(ClienteLogin model);

        Task Logout();

        Task<bool> Registrar(CrearViewModel model);
    }
}