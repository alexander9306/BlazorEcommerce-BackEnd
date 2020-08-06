namespace Sistema.Shared.Entidades.Usuario.Cliente
{
    using System.ComponentModel.DataAnnotations;

    public class ClienteLogin
    {
        [EmailAddress(ErrorMessage = "El campo {0} debe ser un email valido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Password { get; set; }
    }
}