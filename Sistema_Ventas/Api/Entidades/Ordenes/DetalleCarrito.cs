namespace Api.Entidades.Ordenes
{
    using Api.Entidades.Almacen;

    public class DetalleCarrito
    {
        public int Id { get; set; }

        public int CarritoId { get; set; }

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public Producto Producto { get; set; }

        public Carrito Carrito { get; set; }
    }
}
