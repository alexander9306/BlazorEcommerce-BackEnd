namespace Sistema.Web.Models.Usuario.Rol
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using Sistema.Web.Helpers.Validators;

    public class ActualizarViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres, ni menos de {2} caracteres.")]
        public string Nombre { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres.")]
        public string? Descripcion { get; set; }
    }
}
