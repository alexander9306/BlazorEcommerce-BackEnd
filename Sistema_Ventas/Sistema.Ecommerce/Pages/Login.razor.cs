namespace Sistema.Ecommerce.Pages
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Sistema.Ecommerce.Services.Usuario;
    using Sistema.Shared.Entidades.Usuario;

    public partial class Login
    {
        [Inject] private ILoginDataService LoginDataService { get; set; }

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
