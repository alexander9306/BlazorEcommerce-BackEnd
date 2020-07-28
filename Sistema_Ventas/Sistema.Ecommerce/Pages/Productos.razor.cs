namespace Sistema.Ecommerce.Pages
{
    using Microsoft.AspNetCore.Components;

    public partial class Productos : ComponentBase
    {
        [Parameter]
        public string ProductoId { get; set; }
    }
}
