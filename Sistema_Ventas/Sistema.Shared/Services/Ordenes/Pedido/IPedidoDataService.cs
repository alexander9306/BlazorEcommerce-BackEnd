namespace Sistema.Shared.Services.Ordenes.Pedido
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Ordenes.Pedido;

    public interface IPedidoDataService
    {
        Task<IEnumerable<PedidoViewModel>> Listar(int limit, DateTime? before = null);

        Task<PedidoViewModel> Mostrar(int id);

        Task<IEnumerable<PedidoViewModel>> ListarPorOrden(int ordenId, int limit, DateTime? before = null);
        Task Activar(int id);
        Task Desactivar(int id);
    }
}
