namespace Sistema.Web.Models.Usuario.Cliente
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using Sistema.Web.Helpers.Validators;

    public class CrearViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(50, MinimumLength = 15, ErrorMessage = "El email no debe de tener más de 50 caracteres, ni menos de 15 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "La PasswordHash no debe de tener más de 20 caracteres, ni menos de 8 caracteres.")]
        public byte[] PasswordHash { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "La PasswordSalt no debe de tener más de 20 caracteres, ni menos de 8 caracteres.")]
        public byte[] PasswordSalt { get; set; }
    }
}
