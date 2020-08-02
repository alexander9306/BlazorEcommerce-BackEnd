namespace Sistema.Ecommerce.Helpers
{
    using System;
    using Sistema.Shared.Entidades.Almacen;

    public interface IProductoHelper
    {
        public Uri GetFotoUrl(ProductoFoto? foto, int width = 338, int height = 250);

        public Uri GetFotoUrl(string? fotoPublicId, int width = 338, int height = 250);

        public string GetDescripcion(string descripcion);
    }
}
