namespace Sistema.Ecommerce.Services.Ordenes
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Ordenes;

    public interface IOrdenDataService
    {
        Task<IEnumerable<Orden>> Listar(int limit, DateTime? before = null);

        Task<Orden> Mostrar(int id);

        Task<IEnumerable<Orden>> ListarPorCliente(int clienteId, int limit, DateTime? before = null);
    }
}
