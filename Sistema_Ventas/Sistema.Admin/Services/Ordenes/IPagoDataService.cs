namespace Sistema.Admin.Services.Ordenes
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Ordenes;

    interface IPagoDataService
    {
        Task<IEnumerable<Pago>> Listar(int limit, DateTime? before = null);

        Task<Pago> Mostrar(int id);

        Task<IEnumerable<Pago>> ListarPorOrden(int ordenId, int limit, DateTime? before = null);
    }
}
