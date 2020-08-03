namespace Sistema.Shared.Entidades.Ordenes.Pedido
{
    using System.ComponentModel.DataAnnotations;

    public class CrearViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int OrdenId { get; set; }
    }
}
