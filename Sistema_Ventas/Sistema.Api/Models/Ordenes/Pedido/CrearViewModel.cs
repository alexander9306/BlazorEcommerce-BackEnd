namespace Sistema.Api.Models.Ordenes.Pedido
{
    using System.ComponentModel.DataAnnotations;

    public class CrearViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int OrdenId { get; set; }
    }
}
