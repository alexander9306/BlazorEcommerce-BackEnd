namespace Sistema.Ecommerce.Helpers
{
    using Sistema.Shared.Entidades.Almacen;

    public interface IProductoHelper
    {
        public string GetFotoUrl(ProductoFoto? foto);

        public string GetDescripcion(string descripcion);
    }
}
