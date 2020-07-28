namespace Sistema.Api.Models.Ordenes.Orden
{
    using System.ComponentModel.DataAnnotations;

    public class ActualizarViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int CarritoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public double Latitud { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public double Longitud { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(50, MinimumLength = 15, ErrorMessage = "El email no debe de tener más de 50 caracteres, ni menos de 15 caracteres.")]
        public string Email { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Telefono { get; set; }
    }
}
