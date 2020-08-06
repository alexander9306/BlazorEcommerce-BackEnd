namespace Sistema.Shared.Entidades.Usuario.Cliente
{
    using System.ComponentModel.DataAnnotations;

    public class ActualizarViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "El campo {0} debe ser un {0} valido.")]
        public string Email { get; set; }

        [MinLength(5, ErrorMessage = "El campo {0} debe de tener más de {1} caracteres.")]
        public string Password { get; set; }

        public bool ActPassword { get; set; }
    }
}
