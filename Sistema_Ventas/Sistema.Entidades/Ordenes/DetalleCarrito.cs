namespace Sistema.Entidades.Ordenes
{
    using Sistema.Entidades.Almacen;

    public class DetalleCarrito
    {
        public int Id { get; set; }

        public int CarritoId { get; set; }

        public int ProductoId { get; set; }

        public Producto Producto { get; set; }

        public Carrito Carrito { get; set; }
    }
}
