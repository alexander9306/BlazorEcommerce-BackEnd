namespace Sistema.Admin.Pages.Usuario.Administradores
{
    using System.Collections.Generic;
    using System.Globalization;
    using Microsoft.AspNetCore.Components.Authorization;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Sistema.Admin.Components;
    using Sistema.Shared.Entidades.Usuario.Administrador;
    using Sistema.Shared.Entidades.Usuario.Rol;
    using Sistema.Shared.Services.Usuario.Administrador;
    using Sistema.Shared.Services.Usuario.Rol;

    public partial class EditAdministradores
    {
        [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject] private NavigationManager NavigationManager { get; set; }

        [Inject] private IAdminDataService AdministradorDataService { get; set; }

        [Inject] private IRolDataService RolDataService { get; set; }

        [Parameter] public string AdministradorId { get; set; }

        protected ShowAlert.Alert Alert { get; set; }

        private bool Saved { get; set; }

        private string RolId { get; set; } = string.Empty;

        public List<RolViewModel> Roles { get; set; } = new List<RolViewModel>();

        private CrearViewModel Administrador { get; set; } = new CrearViewModel();

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
            {
                this.NavigationManager.NavigateTo("/login");
            }

            this.Saved = false;
            this.Roles = (await this.RolDataService.Listar().ConfigureAwait(false)).ToList();

            if (int.TryParse(AdministradorId, NumberStyles.Integer, CultureInfo.InvariantCulture, out var administradorId))
            {
                var administrador = await this.AdministradorDataService.Mostrar(administradorId).ConfigureAwait(false);

                this.Administrador = new CrearViewModel
                {
                    Email = administrador.Email,
                    Username = administrador.Username,
                    RolId = this.Roles.Find(r => r.Nombre == administrador.Rol).Id,
                    Password = "123456789",
                };
            }
            else
            {
                this.Administrador = new CrearViewModel();
            }

            this.RolId = this.Administrador.RolId.ToString(CultureInfo.InvariantCulture);
        }

        protected async Task HandleValidSubmit()
        {
            bool resultado;
            this.Administrador.RolId = int.Parse(this.RolId, NumberStyles.Integer, CultureInfo.InvariantCulture);

            if (int.TryParse(AdministradorId, NumberStyles.Integer, CultureInfo.InvariantCulture, out var administradorId))
            {
                var administrador = new ActualizarViewModel
                {
                    Id = administradorId,
                    Email = this.Administrador.Email,
                    Username = this.Administrador.Username,
                    RolId = this.Administrador.RolId,
                    Password = this.Administrador.Password,
                };

                administrador.ActPassword = administrador.Password != "123456789";

                resultado = await this.AdministradorDataService.Actualizar(administrador).ConfigureAwait(false);
            }
            else
            {
                resultado = await this.AdministradorDataService.Crear(this.Administrador).ConfigureAwait(false);
            }

            this.Alert = new ShowAlert.Alert
            {
                Type = resultado ? "info" : "danger",
            };
            this.Saved = resultado;
        }

        protected void NavigateToInfo()
        {
            this.NavigationManager.NavigateTo("/administradores");
        }
    }
}
