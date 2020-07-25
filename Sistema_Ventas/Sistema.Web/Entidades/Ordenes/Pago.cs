namespace Api.Entidades.Ordenes
{
    using System;

    public class Pago
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public int OrdenId { get; set; }

        public decimal Monto { get; set; }

        public bool Estado { get; set; }

        public Orden Orden { get; set; }
    }
}
