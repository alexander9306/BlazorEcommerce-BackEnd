namespace Sistema.Api.Entidades.Almacen
{
    using System;
    using System.Collections.Generic;

    public class Marca
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public DateTime CreatedAt { get; set; }

        public IEnumerable<Producto> Productos { get; set; }
    }
}