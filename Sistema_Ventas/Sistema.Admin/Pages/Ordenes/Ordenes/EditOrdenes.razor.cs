namespace Sistema.Admin.Pages.Ordenes.Ordenes
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Sistema.Admin.Components;
    using Sistema.Shared.Entidades.Usuario.Cliente;
    using Sistema.Shared.Services.Ordenes.Orden;
    using Sistema.Shared.Services.Usuario.Cliente;
    using NOrden = Sistema.Shared.Entidades.Ordenes.Orden;

    public partial class EditOrdenes
    {
        [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject] private NavigationManager NavigationManager { get; set; }

        [Inject] private IOrdenDataService OrdenDataService { get; set; }

        [Inject] private IClienteDataService ClienteDataService { get; set; }

        [Parameter] public string OrdenId { get; set; }

        protected ShowAlert.Alert Alert { get; set; }

        public List<ClienteViewModel> Clientes { get; set; } = new List<ClienteViewModel>();

        private string ClienteId { get; set; } = string.Empty;

        private bool Saved { get; set; }

        private NOrden.CrearViewModel Orden { get; set; } = new NOrden.CrearViewModel();

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
            {
                this.NavigationManager.NavigateTo("/login");
            }
            this.Saved = false;
            this.Clientes = (await this.ClienteDataService.Listar().ConfigureAwait(false)).ToList();

            if (int.TryParse(OrdenId, NumberStyles.Integer, CultureInfo.InvariantCulture, out var ordenId))
            {
                var orden = await this.OrdenDataService.Mostrar(ordenId).ConfigureAwait(false);

                if (orden == null)
                {
                    this.Alert = new ShowAlert.Alert
                    {
                        Type = "danger",
                    };
                    return;
                }

                this.Orden = new NOrden.CrearViewModel
                {
                    ClienteId = this.Clientes.Find(c => c.Email == orden.Cliente).Id,
                    Latitud = orden.Latitud,
                    Longitud = orden.Longitud,
                    Direccion = orden.Direccion,
                    Telefono = orden.Telefono,
                };
            }
            else
            {
                this.Orden = new NOrden.CrearViewModel();
            }
        }

        protected async Task HandleValidSubmit()
        {
            bool resultado;
            this.Orden.ClienteId = int.Parse(this.ClienteId, NumberStyles.Integer, CultureInfo.InvariantCulture);

            if (int.TryParse(ClienteId, NumberStyles.Integer, CultureInfo.InvariantCulture, out var clienteId))
            {
                var orden = new NOrden.ActualizarViewModel
                {
                    Id = clienteId,
                    Latitud = this.Orden.Latitud,
                    Longitud = this.Orden.Longitud,
                    Direccion = this.Orden.Direccion,
                    Telefono = this.Orden.Telefono,
                };
                resultado = await this.OrdenDataService.Actualizar(orden).ConfigureAwait(false);
            }
            else
            {
                resultado = await this.OrdenDataService.Crear(this.Orden).ConfigureAwait(false);
            }

            this.Alert = new ShowAlert.Alert
            {
                Type = resultado ? "info" : "danger",
            };

            this.Saved = resultado;
        }

        protected void NavigateToInfo()
        {
            this.NavigationManager.NavigateTo("/ordenes");
        }
    }
}
