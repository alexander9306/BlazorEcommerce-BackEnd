namespace Sistema.Entidades.Ordenes
{
    using System;
    using System.Collections.Generic;
    using Sistema.Entidades.Usuario;

    public class Carrito
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public ICollection<DetalleCarrito> Detalles { get; set; }

        public Orden Orden { get; set; }

        public Cliente Cliente { get; set; }
    }
}
