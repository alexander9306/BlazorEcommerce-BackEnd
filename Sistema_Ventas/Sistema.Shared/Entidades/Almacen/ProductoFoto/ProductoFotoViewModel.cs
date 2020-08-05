namespace Sistema.Shared.Entidades.Almacen.ProductoFoto
{
    using System;

    public class ProductoFotoViewModel
    {
        public int Id { get; set; }

        public int ProductoId { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool? IsPrincipal { get; set; }

        public Uri? FotoUrl { get; set; }

        public string? FotoPublicId { get; set; }
    }
}
