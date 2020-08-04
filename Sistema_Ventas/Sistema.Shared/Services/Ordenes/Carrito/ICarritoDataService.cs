namespace Sistema.Shared.Services.Ordenes.Carrito
{
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Ordenes.Carrito;

    public interface ICarritoDataService
    {
        Task<CarritoViewModel> Mostrar();

        Task<bool> Agregar(int productoId, int cantidad);

        Task<bool> Remover(int productoId);
    }
}
