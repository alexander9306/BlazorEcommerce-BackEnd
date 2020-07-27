namespace Sistema.Shared.Entidades.Almacen
{
    using System;

    public class Categoria
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string? Descripcion { get; set; }

        public bool Estado { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
