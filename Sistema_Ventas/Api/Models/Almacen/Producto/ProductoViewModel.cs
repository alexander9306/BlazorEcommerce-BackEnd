namespace Api.Models.Almacen.Producto
{
    using System;

    public class ProductoViewModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Categoria { get; set; }

        public decimal Precio { get; set; }

        public bool Estado { get; set; }

        public string? Marca { get; set; }

        public int Stock { get; set; }

        public string? Descripcion { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
