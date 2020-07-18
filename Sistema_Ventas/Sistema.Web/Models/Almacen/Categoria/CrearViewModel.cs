namespace Sistema.Web.Models.Almacen.Categoria
{
    using System.ComponentModel.DataAnnotations;

    public class CrearViewModel
    {
        [Required(ErrorMessage = "El nombre es requerido.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string Nombre { get; set; }

        [MaxLength(255, ErrorMessage = "La descripción no debe de tener más de 255 caracteres.")]
        public string? Descripcion { get; set; }
    }
}
