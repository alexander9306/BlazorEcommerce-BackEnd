namespace Sistema.Admin.Pages.Ordenes.Ordenes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.JSInterop;
    using Sistema.Shared.Entidades.Ordenes.Orden;
    using Sistema.Shared.Helpers.General;
    using Sistema.Shared.Services.Ordenes.Orden;

    public partial class Ordenes
    {
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Inject] private IJSRuntime JsRuntime { get; set; }

        [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject] private IOrdenDataService OrdenDataService { get; set; }

        [Inject] private IStringHelper StringHelper { get; set; } = new StringHelper();

        private List<OrdenViewModel> LOrdenes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
            {
                this.NavigationManager.NavigateTo("/login");
            }

            this.LOrdenes = (await this.OrdenDataService.Listar(100).ConfigureAwait(false)).ToList();
        }

        private async Task CambiarEstado(OrdenViewModel ordenes)
        {
            if (ordenes.Estado)
            {
                await this.OrdenDataService.Desactivar(ordenes.Id).ConfigureAwait(false);
            }
            else
            {
                await this.OrdenDataService.Activar(ordenes.Id).ConfigureAwait(false);
            }

            this.LOrdenes = (await this.OrdenDataService.Listar(100).ConfigureAwait(false)).ToList();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (this.LOrdenes != null)
            {
                await this.JsRuntime.InvokeVoidAsync("BlazorMethods.getTable").ConfigureAwait(false);
            }
        }
    }
}
