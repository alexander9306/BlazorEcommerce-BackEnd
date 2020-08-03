namespace Sistema.Shared.Entidades.Ordenes
{
    using System;
    using System.Collections.Generic;

    public class Carrito
    {
        public int Id { get; set; }

        public string Cliente { get; set; }

        public int? ClienteId { get; set; }

        public decimal Total { get; set; }

        public bool Estado { get; set; }

        public IEnumerable<Detalle> Detalles { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
