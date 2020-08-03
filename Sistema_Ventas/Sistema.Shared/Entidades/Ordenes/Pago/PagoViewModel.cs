namespace Sistema.Shared.Entidades.Ordenes.Pago
{
    using System;

    public class PagoViewModel
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int OrdenId { get; set; }

        public decimal Monto { get; set; }

        public bool Estado { get; set; }
    }
}
