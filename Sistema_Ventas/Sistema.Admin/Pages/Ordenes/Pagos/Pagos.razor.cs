namespace Sistema.Admin.Pages.Ordenes.Pagos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.JSInterop;
    using Sistema.Shared.Entidades.Ordenes.Pago;
    using Sistema.Shared.Helpers.General;
    using Sistema.Shared.Services.Ordenes.Pago;

    public partial class Pagos
    {
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Inject] private IJSRuntime JsRuntime { get; set; }

        [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject] private IPagoDataService PagoDataService { get; set; }

        [Inject] private IStringHelper StringHelper { get; set; } = new StringHelper();

        private List<PagoViewModel> LPagos { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
            {
                this.NavigationManager.NavigateTo("/login");
            }

            this.LPagos = (await this.PagoDataService.Listar(100).ConfigureAwait(false)).ToList();
        }

        private async Task CambiarEstado(PagoViewModel pagos)
        {
            if (pagos.Estado)
            {
                await this.PagoDataService.Desactivar(pagos.Id).ConfigureAwait(false);
            }
            else
            {
                await this.PagoDataService.Activar(pagos.Id).ConfigureAwait(false);
            }

            this.LPagos = (await this.PagoDataService.Listar(100).ConfigureAwait(false)).ToList();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (this.LPagos != null)
            {
                await this.JsRuntime.InvokeVoidAsync("BlazorMethods.getTable").ConfigureAwait(false);
            }
        }
    }
}
