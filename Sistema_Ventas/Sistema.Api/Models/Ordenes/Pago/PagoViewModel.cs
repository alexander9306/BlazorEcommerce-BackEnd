namespace Sistema.Api.Models.Ordenes.Pago
{
    using System;

    public class PagoViewModel
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public int OrdenId { get; set; }

        public decimal Monto { get; set; }

        public bool Estado { get; set; }
    }
}
