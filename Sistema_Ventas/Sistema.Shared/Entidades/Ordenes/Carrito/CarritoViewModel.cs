namespace Sistema.Shared.Entidades.Ordenes.Carrito
{
    using System;
    using System.Collections.Generic;
    using Sistema.Shared.Entidades.Ordenes.Carrito.Detalle;

    public class CarritoViewModel
    {
        public int Id { get; set; }

        public string Cliente { get; set; }

        public int? ClienteId { get; set; }

        public decimal Total { get; set; }

        public bool Estado { get; set; }

        public IEnumerable<DetalleViewModel> Detalles { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
