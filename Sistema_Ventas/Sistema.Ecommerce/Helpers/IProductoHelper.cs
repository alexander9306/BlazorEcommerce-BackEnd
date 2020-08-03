namespace Sistema.Ecommerce.Helpers
{
    using System;
    using Sistema.Shared.Entidades.Almacen;

    public interface IProductoHelper
    {
<<<<<<< HEAD
        public string GetFotoUrl(ProductoFoto? foto, int width = 338, int height = 250);
=======
        public Uri GetFotoUrl(ProductoFoto? foto, int width = 338, int height = 250);

        public Uri GetFotoUrl(string? fotoPublicId, int width = 338, int height = 250);
>>>>>>> master

        public string GetDescripcion(string descripcion);
    }
}
