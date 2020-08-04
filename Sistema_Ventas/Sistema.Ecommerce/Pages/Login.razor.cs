namespace Sistema.Ecommerce.Pages
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Sistema.Shared.Entidades.Usuario.Cliente;
    using Sistema.Shared.Services.Usuario.Cliente;

    public partial class Login
    {
        [Inject] private IClienteDataService LoginDataService { get; set; }

        [Inject] private NavigationManager NavigationManager { get; set; }

        private ClienteLogin Cliente = new ClienteLogin();
        private bool ShowErrors;
        private string Error;

        private async Task HandleLogin()
        {
            this.ShowErrors = false;

            var result = await this.LoginDataService.Login(this.Cliente)
                .ConfigureAwait(false);

            if (result)
            {
                this.NavigationManager.NavigateTo("#", true);
            }
            else
            {
                this.Error = "Inválido usuario o contraseña.";
                this.ShowErrors = true;
            }
        }
    }
}
