namespace Sistema.Ecommerce.Pages
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Sistema.Ecommerce.Services.Ordenes;
    using Sistema.Shared.Entidades.Ordenes;

    public partial class CrearOrden
    {
        [Inject] private IOrdenDataService OrdenDataService { get; set; }

        [Inject] private NavigationManager NavigationManager { get; set; }

        [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

        private OrdenCrear Orden = new OrdenCrear();

        public Alert Alert { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
            {
                this.NavigationManager.NavigateTo("/login");
            }
        }

        private async Task HandleSubmit()
        {
            var result = await this.OrdenDataService.Crear(this.Orden)
                .ConfigureAwait(false);

            if (result)
            {
                this.NavigationManager.NavigateTo("/ordenes");
            }
            else
            {
                this.Alert = new Alert
                {
                    Type = "danger",
                };
            }
        }

    }
}
