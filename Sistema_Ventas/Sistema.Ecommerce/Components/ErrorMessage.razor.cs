namespace Sistema.Ecommerce.Components
{
    using Microsoft.AspNetCore.Components;

    public partial class ErrorMessage
    {
        [Parameter]
        public string Message { get; set; }
    }
}
