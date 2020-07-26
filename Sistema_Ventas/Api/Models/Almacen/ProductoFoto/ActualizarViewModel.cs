﻿namespace Api.Models.Almacen.ProductoFoto
{
    using System.ComponentModel.DataAnnotations;
    using Api.Helpers.Validators;
    using Microsoft.AspNetCore.Http;

    public class ActualizarViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [AllowedExtensions(ErrorMessage = "Solo se permiten archivos de tipo: jpg, jpeg, gif, png.")]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = "El tamaño máximo permitido es: {1}")]
        public IFormFile Foto { get; set; }
    }
}