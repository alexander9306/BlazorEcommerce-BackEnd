namespace Sistema.Shared.Services.Ordenes.Pago
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Ordenes.Pago;

    public interface IPagoDataService
    {
        Task<IEnumerable<PagoViewModel>> Listar(int limit, DateTime? before = null);

        Task<PagoViewModel> Mostrar(int id);

        Task<IEnumerable<PagoViewModel>> ListarPorOrden(int ordenId, int limit, DateTime? before = null);

        Task<bool> Desactivar(int id);

        Task<bool> Activar(int id);

        Task<bool> Actualizar(object pago);

        Task<bool> Crear(CrearViewModel pago);
    }
}
