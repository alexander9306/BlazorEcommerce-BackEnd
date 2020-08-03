namespace Sistema.Ecommerce.Services.Ordenes
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Ordenes;

    public interface IPedidoDataService
    {
        Task<IEnumerable<Pedido>> Listar(int limit, DateTime? before = null);

        Task<Pedido> Mostrar(int id);

        Task<IEnumerable<Pedido>> ListarPorOrden(int ordenId, int limit, DateTime? before = null);
    }
}
