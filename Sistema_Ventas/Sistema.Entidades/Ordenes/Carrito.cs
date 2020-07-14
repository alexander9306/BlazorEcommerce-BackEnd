using Sistema.Entidades.Usuario;

namespace Sistema.Entidades.Ordenes
{
    using System;
    using System.Collections.Generic;

    public class Carrito
    {
        public Carrito(int id, int clienteId, DateTime createdAt, DateTime updateAt, ICollection<DetalleCarrito> detalles, Orden orden, Cliente cliente)
        {
            Id = id;
            ClienteId = clienteId;
            CreatedAt = createdAt;
            UpdateAt = updateAt;
            Detalles = detalles;
            Orden = orden;
            Cliente = cliente;
        }

        public int Id { get; set; }

        public int ClienteId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public ICollection<DetalleCarrito> Detalles { get; set; }

        public Orden Orden { get; set; }

        public Cliente Cliente { get; set; }
    }
}
