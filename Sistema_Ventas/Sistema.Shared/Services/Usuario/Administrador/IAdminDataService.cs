namespace Sistema.Shared.Services.Usuario.Administrador
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Usuario.Administrador;

    public interface IAdminDataService
    {
        Task<bool> Login(AdminLogin model);

        Task Logout();

        Task<IEnumerable<AdministradorViewModel>> Listar();

        Task<AdministradorViewModel> Mostrar(int id);

        Task<bool> Activar(int id);

        Task<bool> Desactivar(int id);

        Task<bool> Crear(CrearViewModel model);

        Task<bool> Actualizar(ActualizarViewModel model);
    }
}