namespace Sistema.Web.Models.Usuario.Administrador
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using Sistema.Web.Helpers.Validators;

    public class CrearViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int RolId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "El {0} no debe de tener más de {50} caracteres, ni menos de {10} caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "El {0} no debe de tener más de {15} caracteres, ni menos de {8} caracteres.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public byte[] PasswordHash { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public byte[] PasswordSalt { get; set; }
    }
}
