namespace Api.Entidades.Ordenes
{
    using System;
    using System.Collections.Generic;
    using Api.Entidades.Usuario;

    public class Carrito
    {
        public int Id { get; set; }

        public int? ClienteId { get; set; }

        public string? ClienteGuid { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool Estado { get; set; }

        public ICollection<DetalleCarrito> Detalles { get; }

        public Orden Orden { get; set; }

        public Cliente Cliente { get; set; }
    }
}
