namespace Sistema.Api.Entidades.Almacen
{
    using System;

    public class Slider
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? ImagenPublicId { get; set; }

        public Uri? ImagenUrl { get; set; }
    }
}
