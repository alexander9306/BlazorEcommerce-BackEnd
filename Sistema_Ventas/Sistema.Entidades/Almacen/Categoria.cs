namespace Sistema.Entidades.Almacen
{
    using System;
    using System.Collections.Generic;

    public class Categoria
    {
        public Categoria(int id, string nombre, string? descripcion, bool estado, DateTime createdAt, DateTime updateAt, ICollection<Producto> productos)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Estado = estado;
            CreatedAt = createdAt;
            UpdateAt = updateAt;
            Productos = productos;
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string? Descripcion { get; set; }

        public bool Estado { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}
