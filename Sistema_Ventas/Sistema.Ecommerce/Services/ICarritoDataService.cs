namespace Sistema.Ecommerce.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Ordenes;

    public interface ICarritoDataService
    {
        Task<Carrito> Mostrar();

        Task<bool> Agregar(int productoId, int cantidad);

        Task<bool> Remover(int productoId);
    }
}
