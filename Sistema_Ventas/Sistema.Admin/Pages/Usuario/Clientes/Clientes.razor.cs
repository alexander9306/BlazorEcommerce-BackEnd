namespace Sistema.Admin.Pages.Usuario.Clientes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.JSInterop;
    using Sistema.Shared.Entidades.Usuario.Cliente;
    using Sistema.Shared.Helpers.General;
    using Sistema.Shared.Services.Usuario.Cliente;

    public partial class Clientes
    {
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Inject] private IJSRuntime JsRuntime { get; set; }

        [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject] private IClienteDataService ClienteDataService { get; set; }

        [Inject] private IStringHelper StringHelper { get; set; } = new StringHelper();

        private List<ClienteViewModel> LClientes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
            {
                this.NavigationManager.NavigateTo("/login");
            }

            this.LClientes = (await this.ClienteDataService.Listar().ConfigureAwait(false)).ToList();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (this.LClientes != null)
            {
                await this.JsRuntime.InvokeVoidAsync("BlazorMethods.getTable").ConfigureAwait(false);
            }
        }
    }
}
