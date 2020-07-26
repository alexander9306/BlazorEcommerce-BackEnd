namespace Sistema.Ecommerce.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Almacen;

    public interface IProductoDataService
    {
        Task<IEnumerable<Producto>> Listar(int limit, string after);

        Task<Producto> Mostrar(int id);

        Task<IEnumerable<Producto>> MostrarPorCategoria(int categoriId);
    }
}
