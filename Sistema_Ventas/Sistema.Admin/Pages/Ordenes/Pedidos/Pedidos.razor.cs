namespace Sistema.Admin.Pages.Ordenes.Pedidos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.JSInterop;
    using Sistema.Shared.Entidades.Ordenes.Pedido;
    using Sistema.Shared.Helpers.General;
    using Sistema.Shared.Services.Ordenes.Pedido;

    public partial class Pedidos
    {
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Inject] private IJSRuntime JsRuntime { get; set; }

        [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject] private IPedidoDataService PedidoDataService { get; set; }

        [Inject] private IStringHelper StringHelper { get; set; } = new StringHelper();

        private List<PedidoViewModel> LPedidos { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
            {
                this.NavigationManager.NavigateTo("/login");
            }

            this.LPedidos = (await this.PedidoDataService.Listar(100).ConfigureAwait(false)).ToList();
        }

        private async Task CambiarEstado(PedidoViewModel pedidos)
        {
            if (pedidos.Estado)
            {
                await this.PedidoDataService.Desactivar(pedidos.Id).ConfigureAwait(false);
            }
            else
            {
                await this.PedidoDataService.Activar(pedidos.Id).ConfigureAwait(false);
            }

            this.LPedidos = (await this.PedidoDataService.Listar(100).ConfigureAwait(false)).ToList();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (this.LPedidos != null)
            {
                await this.JsRuntime.InvokeVoidAsync("BlazorMethods.getTable").ConfigureAwait(false);
            }
        }
    }
}
