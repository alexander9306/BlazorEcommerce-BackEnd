namespace Sistema.Admin.Pages.Almacen.Categorias
{
    using System.Globalization;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
<<<<<<< HEAD
    using Microsoft.AspNetCore.Components.Authorization;
=======
>>>>>>> origin/Reynaldo
    using Sistema.Admin.Components;
    using Sistema.Shared.Entidades.Almacen.Categoria;
    using Sistema.Shared.Services.Almacen.Categoria;

    public partial class EditCategorias
    {
<<<<<<< HEAD
        [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }
=======
>>>>>>> origin/Reynaldo

        [Inject] private NavigationManager NavigationManager { get; set; }

        [Inject] private ICategoriaDataService CategoriaDataService { get; set; }

        [Parameter] public string CategoriaId { get; set; }

        protected ShowAlert.Alert Alert { get; set; }

        private bool Saved { get; set; }

        private CrearViewModel Categoria { get; set; } = new CrearViewModel();

        protected override async Task OnInitializedAsync()
        {
<<<<<<< HEAD
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
            {
                this.NavigationManager.NavigateTo("/login");
            }

=======
>>>>>>> origin/Reynaldo
            this.Saved = false;

            if (int.TryParse(CategoriaId, NumberStyles.Integer, CultureInfo.InvariantCulture, out var categoriaId))
            {
                var categoria = await this.CategoriaDataService.Mostrar(categoriaId).ConfigureAwait(false);

                this.Categoria = new CrearViewModel
                {
                    Nombre = categoria.Nombre,
                    Descripcion = categoria.Descripcion,
                };
            }
            else
            {
                this.Categoria = new CrearViewModel();
            }
        }

        protected async Task HandleValidSubmit()
        {
            bool resultado;
            if (int.TryParse(CategoriaId, NumberStyles.Integer, CultureInfo.InvariantCulture, out var categoriaId))
            {
                var categoria = new ActualizarViewModel
                {
                    Id = categoriaId,
                    Nombre = this.Categoria.Nombre,
                    Descripcion = this.Categoria.Descripcion,
                };
                resultado = await this.CategoriaDataService.Actualizar(categoria).ConfigureAwait(false);

            }
            else
            {
                resultado = await this.CategoriaDataService.Crear(this.Categoria).ConfigureAwait(false);
            }

            this.Alert = new ShowAlert.Alert
            {
                Type = resultado ? "info" : "danger",
            };

            this.Saved = resultado;
        }

        protected void NavigateToInfo()
        {
            this.NavigationManager.NavigateTo("/categorias");
        }
    }
}
