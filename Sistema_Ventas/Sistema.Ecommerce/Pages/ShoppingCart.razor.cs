namespace Sistema.Ecommerce.Pages
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Sistema.Ecommerce.Helpers;
    using Sistema.Ecommerce.Services;
    using Sistema.Shared.Entidades.Ordenes;

    public partial class ShoppingCart
    {
        public Carrito Carrito { get; set; }

        [Inject]
        public ICarritoDataService CarritoDataService { get; set; }

        [Inject]
        public IProductoHelper ProductoHelper { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.Carrito = await this.CarritoDataService.Mostrar()
                .ConfigureAwait(false);
        }
    }
}