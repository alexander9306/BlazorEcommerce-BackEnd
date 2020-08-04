namespace Sistema.Shared.Entidades.Ordenes.Carrito.Detalle
{
    public class DetalleViewModel
    {
        public int ProductoId { get; set; }

        public string Producto { get; set; }

        public string FotoPublicId { get; set; }

        public string Marca { get; set; }

        public decimal Total { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }
    }
}
