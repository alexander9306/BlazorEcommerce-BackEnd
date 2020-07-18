namespace Sistema.Web.Models.Almacen.Categoria
{
    using System.ComponentModel.DataAnnotations;

    public class ActualizarViewModel
    {
        [Required(ErrorMessage = "El id es requerido.")]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string Nombre { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "La descripción no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string? Descripcion { get; set; }

        public bool Estado { get; set; }
    }
}
