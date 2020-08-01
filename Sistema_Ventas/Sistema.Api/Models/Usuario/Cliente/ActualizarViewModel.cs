namespace Sistema.Api.Models.Usuario.Cliente
{
    using System.ComponentModel.DataAnnotations;

    public class ActualizarViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "El campo {0} debe ser un {0} valido.")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 8, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres, ni menos de {2} caracteres.")]
        public string Password { get; set; }

        public bool ActPassword { get; set; }
    }
}
