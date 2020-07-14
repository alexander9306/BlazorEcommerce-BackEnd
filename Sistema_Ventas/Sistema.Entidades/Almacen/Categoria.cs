namespace Sistema.Entidades.Almacen
{
    using System;
    using System.Collections.Generic;

    public class Categoria
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string? Descripcion { get; set; }

        public bool Estado { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}
