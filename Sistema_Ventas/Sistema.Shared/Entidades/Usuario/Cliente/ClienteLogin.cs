namespace Sistema.Shared.Entidades.Usuario.Cliente
{
    using System.ComponentModel.DataAnnotations;

    public class ClienteLogin
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [EmailAddress(ErrorMessage = "El campo {0} debe ser un email valido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es requerido.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "El campo Contraseña no debe de tener más de 20 caracteres, ni menos de 8 caracteres.")]
        public string Password { get; set; }
    }
}