namespace Sistema.Shared.Entidades.Ordenes.Pago
{
    using System.ComponentModel.DataAnnotations;

    public class CrearViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int OrdenId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public decimal Monto { get; set; }
    }
}
