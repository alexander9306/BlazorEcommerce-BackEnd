namespace Sistema.Ecommerce.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Almacen;

    public interface IProductoDataService
    {
        Task<IEnumerable<Producto>> Listar(int limit, DateTime? before);

        Task<Producto> Mostrar(int id);

        Task<IEnumerable<Producto>> ListarPorCategoria(int categoriId, int limit, DateTime? before);

        Task<IEnumerable<Producto>> ListarPorMarca(string marca, int limit, DateTime? before);
    }
}
