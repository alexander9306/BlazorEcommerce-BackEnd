namespace Sistema.Shared.Entidades.Usuario.Administrador
{
    using System.ComponentModel.DataAnnotations;

    public class CrearViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int RolId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [EmailAddress(ErrorMessage = "El campo {0} debe ser un email valido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "El {0} no debe de tener más de {15} caracteres, ni menos de {8} caracteres.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Password { get; set; }
    }
}
