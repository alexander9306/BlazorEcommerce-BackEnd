using Sistema.Shared.Entidades.Ordenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Ecommerce.Services
{
    interface IPagoDataService
    {
        Task<IEnumerable<Pago>> Listar(int limit, DateTime? before = null);

        Task<Pago> Mostrar(int id);

        Task<IEnumerable<Pago>> ListarPorOrden(int ordenId, int limit, DateTime? before = null);
    }
}
