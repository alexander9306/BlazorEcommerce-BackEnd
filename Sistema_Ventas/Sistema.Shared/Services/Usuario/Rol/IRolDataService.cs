namespace Sistema.Shared.Services.Usuario.Rol
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Usuario.Rol;

    public interface IRolDataService
    {
        Task<IEnumerable<RolViewModel>> Listar();

        Task<RolViewModel> Mostrar(int id);
    }
}
