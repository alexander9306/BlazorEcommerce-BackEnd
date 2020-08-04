namespace Sistema.Shared.Helpers.Producto
{
    using System;
    using Sistema.Shared.Entidades.Almacen.ProductoFoto;

    public interface IProductoHelper
    {
        public Uri GetFotoUrl(ProductoFotoViewModel? foto, int width = 338, int height = 250);

        public Uri GetFotoUrl(string? fotoPublicId, int width = 338, int height = 250);

        public string GetDescripcion(string descripcion);
    }
}
