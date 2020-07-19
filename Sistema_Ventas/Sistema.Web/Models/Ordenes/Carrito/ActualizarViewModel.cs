namespace Sistema.Web.Models.Ordenes.Carrito
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Sistema.Web.Models.Ordenes.Carrito.Detalle;

    public class ActualizarViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public List<ActualizarDetalleViewModel> Detalles { get; }
    }
}
