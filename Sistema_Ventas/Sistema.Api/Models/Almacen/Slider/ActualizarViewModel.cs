namespace Sistema.Api.Models.Almacen.Slider
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using Sistema.Api.Helpers.Validators;

    public class ActualizarViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [AllowedExtensions(ErrorMessage = "Solo se permiten archivos de tipo: jpg, jpeg, gif, png.")]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = "El tamaño máximo permitido es: {1}")]
        public IFormFile Imagen { get; set; }
    }
}
