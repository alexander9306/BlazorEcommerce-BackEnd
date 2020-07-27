
namespace Sistema.Shared.Entidades.Almacen
{
    using System;

    public class ProductoFoto
    {
        public int ProductoId { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool? IsPrincipal { get; set; }

        public Uri? FotoUrl { get; set; }

        public string? FotoPublicId { get; set; }
    }
}
