namespace Sistema.Shared.Entidades.Ordenes
{
    public class Detalle
    {
        public int ProductoId { get; set; }

        public string Producto { get; set; }

        public decimal Total { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }
    }
}
