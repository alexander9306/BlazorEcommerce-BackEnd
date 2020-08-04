namespace Sistema.Shared.Entidades.Ordenes.Orden
{
    using System.ComponentModel.DataAnnotations;

    public class ActualizarViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Id { get; set; }

        public string Estado { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public double Latitud { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public double Longitud { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Telefono { get; set; }
    }
}
