namespace Sistema.Shared.Entidades.Usuario.Administrador
{
    using System.ComponentModel.DataAnnotations;

    public class ActualizarViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Id { get; set; }

        public int RolId { get; set; }

        [EmailAddress(ErrorMessage = "El campo {0} debe ser un email valido.")]
        public string Email { get; set; }

        [StringLength(15, MinimumLength = 5, ErrorMessage = "El campo {0} no debe de tener más de 15 caracteres, ni menos de 8 caracteres.")]
        public string Username { get; set; }

        public string Password { get; set; }

        public bool ActPassword { get; set; }
    }
}