namespace Sistema.Web.Models.Almacen.Producto
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using Sistema.Web.Helpers.Validators;

    public class CrearViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El {0} no debe de tener más de {1} caracteres, ni menos de {2} caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public decimal Precio { get; set; }

        [MaxLength(20, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres.")]
        public string? Marca { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Range(0, int.MaxValue, ErrorMessage = "El campo {0} debe ser mayor a {1}.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [AllowedExtensions(ErrorMessage = "Solo se permiten archivos de tipo: jpg, jpeg, gif, png.")]
        [MaxFileSize(2 * 1024 * 1024, ErrorMessage = "El tamaño máximo permitido es: {1}")]
        public IFormFile Foto { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres.")]
        public string? Descripcion { get; set; }
    }
}
