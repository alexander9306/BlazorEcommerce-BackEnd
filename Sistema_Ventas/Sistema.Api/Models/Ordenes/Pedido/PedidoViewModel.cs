namespace Sistema.Api.Models.Ordenes.Pedido
{
    using System;

    public class PedidoViewModel
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public int OrdenId { get; set; }

        public bool Estado { get; set; }
    }
}
