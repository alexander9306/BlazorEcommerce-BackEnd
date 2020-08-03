namespace Sistema.Shared.Entidades.Usuario.Cliente
{
    using System.ComponentModel.DataAnnotations;

    public class ClienteLogin
    {
        [EmailAddress(ErrorMessage = "El campo {0} debe ser un email valido.")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 8, ErrorMessage = "El campo Contraseña no debe de tener más de 20 caracteres, ni menos de 8 caracteres.")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Las contraseñas deben ser iguales.")]
        public string MatchPassword { get; set; }
    }
}