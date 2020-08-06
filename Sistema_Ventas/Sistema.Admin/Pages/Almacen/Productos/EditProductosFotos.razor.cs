using Sistema.Shared.Helpers.Producto;

namespace Sistema.Admin.Pages.Almacen.Productos
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using BlazorInputFile;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Sistema.Admin.Components;
    using Sistema.Shared.Entidades.Almacen.ProductoFoto;
    using Sistema.Shared.Services.Almacen.ProductoFoto;

    public partial class EditProductosFotos
    {
        [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject] private NavigationManager NavigationManager { get; set; }

        [Inject] private IProductoFotoDataService ProductoFotoDataService { get; set; }

        [Inject] private IProductoHelper PoductoHelper { get; set; } = new ProductoHelper();

        [Parameter] public string ProductoId { get; set; }

        protected ShowAlert.Alert Alert { get; set; }

        public List<ProductoFotoViewModel> Fotos { get; set; }

        public IFileListEntry File { get; set; }

        private int maxFileSize { get; set; } = 5 * 1024 * 1024;

        protected bool Saved { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
            {
                this.NavigationManager.NavigateTo("/login");
            }

            this.Saved = false;

            if (int.TryParse(ProductoId, NumberStyles.Integer, CultureInfo.InvariantCulture, out var productoId))
            {
                this.Fotos = (await this.ProductoFotoDataService.Listar(productoId).ConfigureAwait(false)).ToList();
            }
            else
            {
                this.Alert = new ShowAlert.Alert
                {
                    Type = "danger",
                };
            }
        }

        private async Task BorrarFoto(int fotoId)
        {
            Console.WriteLine(fotoId);
            var response = await this.ProductoFotoDataService.Eliminar(fotoId).ConfigureAwait(false);
            if (response)
            {
                this.Fotos = (await this.ProductoFotoDataService.Listar(int.Parse(this.ProductoId, NumberStyles.Integer, CultureInfo.InvariantCulture)).ConfigureAwait(false)).ToList();
            }
            else
            {
                this.Alert = new ShowAlert.Alert
                {
                    Type = "danger",
                };
            }

            this.StateHasChanged();
        }
        
        private async void SubirImagen(){
        
        var foto = new CrearProductofotoViewModel
                {
                    Foto = this.File.Data,
                    Nombre = this.File.Name,
                    ProductoId = int.Parse(this.ProductoId, NumberStyles.Integer, CultureInfo.InvariantCulture),
                };
                
        var resultado = await this.ProductoFotoDataService.Crear(foto, file.Size, file.Name).ConfigureAwait(false);
        
        if(resultado){
         this.Alert = new ShowAlert.Alert
                {
                    Type = "info",
                };
        }
        else{
         this.Alert = new ShowAlert.Alert
                {
                    Type = "danger",
                };
        }	
        }

        private async Task HandleSelection(IFileListEntry[] files)
        {
            var file = files.FirstOrDefault();
            if (file != null && file.Size < this.maxFileSize)
            {
                this.File = file;
            }
        }

        protected void NavigateToInfo()
        {
            this.NavigationManager.NavigateTo("/productos");
        }
    }
}
