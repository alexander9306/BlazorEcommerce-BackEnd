namespace Sistema.Ecommerce.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Usuario;

    public interface IAdministradorDataService
    {
        Task<IEnumerable<Administrador>> Listar();

        Task<Administrador> Mostrar(int id);

    }
}
