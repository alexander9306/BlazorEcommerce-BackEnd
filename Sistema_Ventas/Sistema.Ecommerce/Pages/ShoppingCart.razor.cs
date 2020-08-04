namespace Sistema.Ecommerce.Pages
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Sistema.Shared.Entidades.Ordenes.Carrito;
    using Sistema.Shared.Helpers.Producto;
    using Sistema.Shared.Services.Ordenes.Carrito;

    public partial class ShoppingCart
    {
        public CarritoViewModel Carrito { get; set; }

        [Inject]
        public ICarritoDataService CarritoDataService { get; set; }

        [Inject]
        public IProductoHelper ProductoHelper { get; set; }

        private bool ShowMessage;

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