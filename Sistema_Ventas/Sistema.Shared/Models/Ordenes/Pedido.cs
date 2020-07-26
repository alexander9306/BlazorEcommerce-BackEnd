namespace Sistema.Shared.Models.Ordenes
{
    using System;

    public class Pedido
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public int OrdenId { get; set; }

        public bool Estado { get; set; }
    }
}
