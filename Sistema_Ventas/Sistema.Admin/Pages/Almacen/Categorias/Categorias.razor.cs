namespace Sistema.Admin.Pages.Almacen.Categorias
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.JSInterop;
    using Sistema.Shared.Entidades.Almacen.Categoria;
    using Sistema.Shared.Helpers.General;
    using Sistema.Shared.Services.Almacen.Categoria;

    public partial class Categorias
    {
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Inject] private IJSRuntime JsRuntime { get; set; }

        [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject] private ICategoriaDataService CategoriaDataService { get; set; }

        [Inject] private IStringHelper StringHelper { get; set; } = new StringHelper();

        private List<CategoriaViewModel> LCategorias { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
            {
                this.NavigationManager.NavigateTo("/login");
            }

            this.LCategorias = (await this.CategoriaDataService.Listar().ConfigureAwait(false)).ToList();
        }

        private async Task CambiarEstado(CategoriaViewModel categoria)
        {
            if (categoria.Estado)
            {
                await this.CategoriaDataService.Desactivar(categoria.Id).ConfigureAwait(false);
            }
            else
            {
                await this.CategoriaDataService.Activar(categoria.Id).ConfigureAwait(false);
            }

            this.LCategorias = (await this.CategoriaDataService.Listar().ConfigureAwait(false)).ToList();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (this.LCategorias != null)
            {
                await this.JsRuntime.InvokeVoidAsync("BlazorMethods.getTable").ConfigureAwait(false);
            }
        }
    }
}
