
namespace Sistema.Api.Models.Almacen.ProductoFoto
{
    using System;

    public class ProductoFotoViewModel
    {
        public int ProductoId { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool? IsPrincipal { get; set; }

        public Uri? FotoUrl { get; set; }

        public string? FotoPublicId { get; set; }
    }
}
