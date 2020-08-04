using System;

namespace Sistema.Admin.Pages
{
    using System.Globalization;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Sistema.Admin.Components;
    using Sistema.Shared.Entidades.Almacen.Categoria;
    using Sistema.Shared.Services.Almacen.Categoria;

    public partial class EditCategorias
    {

        [Inject] private NavigationManager NavigationManager { get; set; }

        [Inject] private ICategoriaDataService CategoriaDataService { get; set; }

        [Parameter] public string CategoriaId { get; set; }

        protected ShowAlert.Alert Alert { get; set; }

        private bool Saved { get; set; }

        private CrearViewModel Categoria { get; set; } = new CrearViewModel();

        protected override async Task OnInitializedAsync()
        {
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
