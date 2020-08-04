namespace Sistema.Admin.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.JSInterop;
    using Sistema.Shared.Entidades.Usuario.Administrador;
    using Sistema.Shared.Helpers.General;
    using Sistema.Shared.Services.Usuario.Administrador;

    public partial class Administradores
    {
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Inject] private IJSRuntime JsRuntime { get; set; }

        [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject] private IAdminDataService AdministradorDataService { get; set; }

        [Inject] private IStringHelper StringHelper { get; set; } = new StringHelper();

        private List<AdministradorViewModel> LAdministradores { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
            {
                this.NavigationManager.NavigateTo("/login");
            }

            this.LAdministradores = (await this.AdministradorDataService.Listar().ConfigureAwait(false)).ToList();
        }

        private async Task CambiarEstado(AdministradorViewModel administrador)
        {
            if (administrador.Estado)
            {
                await this.AdministradorDataService.Desactivar(administrador.Id).ConfigureAwait(false);
            }
            else
            {
                await this.AdministradorDataService.Activar(administrador.Id).ConfigureAwait(false);
            }

            this.LAdministradores = (await this.AdministradorDataService.Listar().ConfigureAwait(false)).ToList();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (this.LAdministradores != null)
            {
                await this.JsRuntime.InvokeVoidAsync("BlazorMethods.getTable").ConfigureAwait(false);
            }
        }
    }
}
