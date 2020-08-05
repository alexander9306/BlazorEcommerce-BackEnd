namespace Sistema.Shared.Entidades.Almacen.ProductoFoto
{
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using Sistema.Shared.Helpers.Validators;

    public class CrearProductofotoViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int ProductoId { get; set; }

        public bool IsPrincipal { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [AllowedExtensions(ErrorMessage = "Solo se permiten archivos de tipo: jpg, jpeg, gif, png.")]
        [MaxFileSize(5 * 1024 * 1024, ErrorMessage = "El tamaño máximo permitido es: {1}")]
        public Stream Foto { get; set; }

        public string Nombre { get; set; }
    }
}