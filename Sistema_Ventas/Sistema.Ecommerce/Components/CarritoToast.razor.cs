namespace Sistema.Ecommerce.Components
{
    using Microsoft.AspNetCore.Components;

    public partial class CarritoToast
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Message { get; set; }
    }
}