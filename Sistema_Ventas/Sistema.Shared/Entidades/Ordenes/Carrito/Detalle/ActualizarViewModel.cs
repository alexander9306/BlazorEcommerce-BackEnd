namespace Sistema.Shared.Entidades.Ordenes.Carrito.Detalle
{
    using System.ComponentModel.DataAnnotations;

    public class ActualizarDetalleViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Range(0, int.MaxValue, ErrorMessage = "El campo {0} debe ser mayor a {1}.")]
        public int Cantidad { get; set; }
    }
}
