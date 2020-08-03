namespace Sistema.Admin.Services.Almacen
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Almacen;

    public interface IProductoDataService
    {
        Task<IEnumerable<Producto>> Listar(int limit, DateTime? before = null);

        Task<Producto> Mostrar(int id);

        Task<IEnumerable<Producto>> ListarPorFiltro(List<int> categoriaIds, List<int> marcaIds, int limit, DateTime? before = null);

        Task<IEnumerable<Producto>> ListarRelacionados(int productoId, int limit, DateTime? before = null);
    }
}
