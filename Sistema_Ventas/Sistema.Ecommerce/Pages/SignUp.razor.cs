namespace Sistema.Ecommerce.Pages
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Sistema.Ecommerce.Services.Usuario;
    using Sistema.Shared.Entidades.Usuario;

    public partial class SignUp
    {
        [Inject] private ILoginDataService LoginDataService { get; set; }

        [Inject] private NavigationManager NavigationManager { get; set; }

        private ClienteRegister Cliente = new ClienteRegister();
        private bool ShowErrors;
        private string Error = string.Empty;

        private async Task HandleRegistration()
        {
            this.ShowErrors = false;

            var result = await this.LoginDataService.Registrar(this.Cliente)
                .ConfigureAwait(false);

            if (result)
            {
                this.NavigationManager.NavigateTo("/login");
            }
            else
            {
                this.Error = "Hubo un problema con su solicitud.";
                this.ShowErrors = true;
            }
        }
    }
}
