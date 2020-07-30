namespace Sistema.Ecommerce.Helpers
{
    using Sistema.Shared.Entidades.Almacen;

    public interface IProductoHelper
    {
        public string GetFotoUrl(ProductoFoto? foto, int width = 338, int height = 250);

        public string GetDescripcion(string descripcion);
    }
}
