namespace Sistema.Ecommerce.Pages
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Sistema.Shared.Entidades.Usuario.Cliente;
    using Sistema.Shared.Services.Usuario.Cliente;

    public partial class SignUp
    {
        [Inject] private IClienteDataService LoginDataService { get; set; }

        [Inject] private NavigationManager NavigationManager { get; set; }

        private CrearViewModel Cliente = new CrearViewModel();

        public Alert Alert { get; set; }

        private async Task HandleRegistration()
        {
            var result = await this.LoginDataService.Registrar(this.Cliente)
                .ConfigureAwait(false);

            if (result)
            {
                this.Alert = new Alert
                {
                    Type = "info",
                };

                this.StateHasChanged();
                await Task.Delay(1300).ConfigureAwait(true);

                this.NavigationManager.NavigateTo("/login");
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

    public class Alert
    {
        public string Type { get; set; }

        public string Message { get => (this.Type == "danger") ? "Hubo un problema con su solicitud." : "Usuario creado de forma correcta."; }
    }
}
