namespace Sistema.Shared.Entidades.Ordenes.Pedido
{
    using System;

    public class PedidoViewModel
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int OrdenId { get; set; }

        public bool Estado { get; set; }
    }
}
