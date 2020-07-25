namespace Api.Entidades.Almacen
{
    using System;
    using System.Collections.Generic;

    public class Producto
    {
        public int Id { get; set; }

        public int CategoriaId { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public bool Estado { get; set; }

        public string? Marca { get; set; }

        public int Stock { get; set; }

        public string? Descripcion { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Categoria Categoria { get; set; }

        public ICollection<ProductoFoto> Fotos { get; set; }
    }
}
