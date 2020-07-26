namespace Sistema.Ecommerce.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Almacen;

    public interface IProductoDataService
    {
        Task<IEnumerable<Producto>> Listar();
    }
}
