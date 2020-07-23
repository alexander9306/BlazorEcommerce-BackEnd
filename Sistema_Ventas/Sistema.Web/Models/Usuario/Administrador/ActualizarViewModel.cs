namespace Sistema.Web.Models.Usuario.Administrador
{
    using System.ComponentModel.DataAnnotations;

    public class ActualizarViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Id { get; set; }

        public int RolId { get; set; } 

        [StringLength(30, MinimumLength = 10, ErrorMessage = "El campo RolId no debe de tener más de 30 caracteres, ni menos de 10 caracteres.")]
        public string Email { get; set; }

        [StringLength(15, MinimumLength = 8, ErrorMessage = "El campo Email no debe de tener más de 15 caracteres, ni menos de 8 caracteres.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Password { get; set; }

        public bool ActPassword { get; set; }
    }
}