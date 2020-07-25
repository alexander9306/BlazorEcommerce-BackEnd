namespace Api.Models.Almacen.Slider
{
    using System.ComponentModel.DataAnnotations;
    using Api.Helpers.Validators;
    using Microsoft.AspNetCore.Http;

    public class CrearViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [AllowedExtensions(ErrorMessage = "Solo se permiten archivos de tipo: jpg, jpeg, gif, png.")]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = "El tamaño máximo permitido es: {1}")]
        public IFormFile Imagen { get; set; }
    }
}
