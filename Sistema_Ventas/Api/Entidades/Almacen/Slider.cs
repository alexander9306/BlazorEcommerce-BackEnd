﻿using System;

namespace Api.Entidades.Almacen
{
    public class Slider
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? ImagenPublicId { get; set; }

        public Uri? ImagenUrl { get; set; }
    }
}