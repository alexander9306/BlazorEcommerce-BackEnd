using System.Threading.Tasks;

namespace Sistema.Admin.Pages
{
    using Microsoft.AspNetCore.Components;
    using Sistema.Admin.Services.Usuario;
    using Sistema.Shared.Entidades.Usuario;

    public partial class Login
    {
        [Inject] private ILoginDataService LoginDataService { get; set; }

        [Inject] private NavigationManager NavigationManager { get; set; }

        private AdminLogin Admin = new AdminLogin();

        private bool ShowErrors;

        private string Error;

        private async Task HandleLogin()
        {
            this.ShowErrors = false;

            var result = await this.LoginDataService.Login(this.Admin)
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
