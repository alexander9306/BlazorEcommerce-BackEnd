namespace Sistema.Ecommerce.Services.Ordenes
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Ordenes;
    using Sistema.Shared.Entidades.Ordenes.Pago;

    interface IPagoDataService
    {
        Task<IEnumerable<PagoViewModel>> Listar(int limit, DateTime? before = null);

        Task<PagoViewModel> Mostrar(int id);

        Task<IEnumerable<PagoViewModel>> ListarPorOrden(int ordenId, int limit, DateTime? before = null);
    }
}
