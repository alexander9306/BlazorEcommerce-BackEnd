namespace Sistema.Admin.Pages.Almacen.Productos
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.JSInterop;
    using Sistema.Shared.Entidades.Almacen.Producto;
    using Sistema.Shared.Helpers.General;
    using Sistema.Shared.Services.Almacen.Producto;

    public partial class Productos
    {
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Inject] private IJSRuntime JsRuntime { get; set; }

        [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject] private IProductoDataService ProductoDataService { get; set; }

        [Inject] private IStringHelper StringHelper { get; set; } = new StringHelper();

        private List<ProductoViewModel> LProductos { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
            {
                this.NavigationManager.NavigateTo("/login");
            }

            this.LProductos = (await this.ProductoDataService.Listar(100).ConfigureAwait(false)).ToList();
        }

        private async Task CambiarEstado(ProductoViewModel producto)
        {
            if (producto.Estado)
            {
                await this.ProductoDataService.Desactivar(producto.Id).ConfigureAwait(false);
            }
            else
            {
                await this.ProductoDataService.Activar(producto.Id).ConfigureAwait(false);
            }

            this.LProductos = (await this.ProductoDataService.Listar(100).ConfigureAwait(false)).ToList();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (this.LProductos != null)
            {
                await this.JsRuntime.InvokeVoidAsync("BlazorMethods.getTable").ConfigureAwait(false);
            }
        }
    }
}
