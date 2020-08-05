namespace Sistema.Shared.Services.Almacen.ProductoFoto
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Almacen.ProductoFoto;

    public interface IProductoFotoDataService
    {
        Task<IEnumerable<ProductoFotoViewModel>> Listar(int productoId);

        Task<bool> Crear(CrearProductofotoViewModel model, long length, string filename);

        Task<bool> Eliminar(int fotoId);
    }
}
