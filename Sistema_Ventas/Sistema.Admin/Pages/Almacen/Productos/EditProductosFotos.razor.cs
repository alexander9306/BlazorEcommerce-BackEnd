namespace Sistema.Admin.Pages.Almacen.ProductoFotos
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using System.Linq;
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

        [Inject] private ICategoriaDataService CategoriaDataService { get; set; }
      
        [Parameter] public string ProductoFotoId { get; set; }

        protected ShowAlert.Alert Alert { get; set; }

        public List<CategoriaViewModel> Categorias { get; set; } = new List<CategoriaViewModel>();
        
        private string CategoriaId { get; set; } = string.Empty;

        private bool Saved { get; set; }

        private NProductoFoto.CrearViewModel ProductoFoto { get; set; } = new NProductoFoto.CrearViewModel();

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
            {
                this.NavigationManager.NavigateTo("/login");
            }
            this.Saved = false;
            this.Categorias = (await this.CategoriaDataService.Listar().ConfigureAwait(false)).ToList();

            if (int.TryParse(ProductoFotoId, NumberStyles.Integer, CultureInfo.InvariantCulture, out var productoId))
            {
                var producto = await this.ProductoFotoDataService.Mostrar(productoId).ConfigureAwait(false);
                
                if(producto == null){
                    this.Alert = new ShowAlert.Alert
                    {
                        Type = "danger",
                    };
                    return;
                }

                this.ProductoFoto = new NProductoFoto.CrearViewModel
                {
                    CategoriaId = this.Categorias.Find(c => c.Nombre == producto.Categoria).Id,
                    Nombre = producto.Nombre,
                    Precio = producto.Precio,
                    Marca = producto.Marca,
                    Stock = producto.Stock,
                    Descripcion = producto.Descripcion,
                };
            }
            else
            {
                this.ProductoFoto = new NProductoFoto.CrearViewModel();
            }
        }

        protected async Task HandleValidSubmit()
        {
            bool resultado;
            this.ProductoFoto.CategoriaId = int.Parse(this.CategoriaId, NumberStyles.Integer, CultureInfo.InvariantCulture);

            if (int.TryParse(ProductoFotoId, NumberStyles.Integer, CultureInfo.InvariantCulture, out var productoId))
            {
                var producto = new NProductoFoto.ActualizarViewModel
                {
                    Id = productoId,
                    Nombre = this.ProductoFoto.Nombre,
                    Precio = this.ProductoFoto.Precio,
                    Marca = this.ProductoFoto.Marca,
                    Stock = this.ProductoFoto.Stock,
                    Descripcion = this.ProductoFoto.Descripcion,
                };
                resultado = await this.ProductoFotoDataService.Actualizar(producto).ConfigureAwait(false);
            }
            else
            {
                resultado = await this.ProductoFotoDataService.Crear(this.ProductoFoto).ConfigureAwait(false);
            }

            this.Alert = new ShowAlert.Alert
            {
                Type = resultado ? "info" : "danger",
            };

            this.Saved = resultado;
        }

        protected void NavigateToInfo()
        {
            this.NavigationManager.NavigateTo("/productos");
        }
    }
}
