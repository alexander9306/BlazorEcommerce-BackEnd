namespace Sistema.Api.Models.Almacen.Slider
{
    using System;

    public class SliderViewModel
    {
        public int ClienteId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? ImagenPublicId { get; set; }

        public Uri? ImagenUrl { get; set; }
    }
}
