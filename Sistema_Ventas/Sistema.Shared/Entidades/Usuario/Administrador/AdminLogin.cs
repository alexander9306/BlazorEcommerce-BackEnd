namespace Sistema.Shared.Entidades.Usuario.Administrador
{
    using System.ComponentModel.DataAnnotations;

    public class AdminLogin
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es requerido.")]
        public string Password { get; set; }
    }
}