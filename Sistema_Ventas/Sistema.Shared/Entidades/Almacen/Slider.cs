namespace Sistema.Shared.Entidades.Almacen
{
    using System;

    public class Slider
    {
        public int ClienteId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? ImagenPublicId { get; set; }

        public Uri? ImagenUrl { get; set; }
    }
}
