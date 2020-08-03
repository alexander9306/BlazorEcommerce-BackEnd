﻿namespace Sistema.Ecommerce.Services.Almacen
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Almacen;
    using Sistema.Shared.Entidades.Almacen.Producto;

    public interface IProductoDataService
    {
        Task<IEnumerable<ProductoViewModel>> Listar(int limit, DateTime? before = null);

        Task<ProductoViewModel> Mostrar(int id);

        Task<IEnumerable<ProductoViewModel>> ListarPorFiltro(List<int> categoriaIds, List<int> marcaIds, int limit, DateTime? before = null);

        Task<IEnumerable<ProductoViewModel>> ListarRelacionados(int productoId, int limit, DateTime? before = null);
    }
}
