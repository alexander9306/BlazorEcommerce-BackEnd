namespace Sistema.Ecommerce.Pages
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Sistema.Ecommerce.Helpers;
    using Sistema.Ecommerce.Services;
    using Sistema.Ecommerce.Services.Ordenes;
    using Sistema.Shared.Entidades.Ordenes;
    using Sistema.Shared.Entidades.Ordenes.Carrito;

    public partial class ShoppingCart
    {
        public CarritoViewModel Carrito { get; set; }

        [Inject]
        public ICarritoDataService CarritoDataService { get; set; }

        [Inject]
        public IProductoHelper ProductoHelper { get; set; }

        protected bool ShowMessage;

        protected override async Task OnInitializedAsync()
        {
            this.Carrito = await this.CarritoDataService.Mostrar()
                .ConfigureAwait(false);

            if (this.Carrito == null)
            {
                this.ShowMessage = true;
            }
        }
    }
}