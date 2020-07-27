namespace Sistema.Ecommerce.Pages
{
    using Microsoft.AspNetCore.Components;

    public class ProductoBase : ComponentBase
    {
        [Parameter]
        public string ProductoId { get; set; }
    }
}
