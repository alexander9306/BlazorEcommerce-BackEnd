namespace Sistema.Admin.Pages.Almacen.Productos
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.AspNetCore.Components;
    using Sistema.Admin.Components;
    using NProducto = Sistema.Shared.Entidades.Almacen.Producto;
    using Sistema.Shared.Entidades.Almacen.Categoria;
    using Sistema.Shared.Services.Almacen.Producto;
    using Sistema.Shared.Services.Almacen.ProductoFoto;
    using Sistema.Shared.Services.Almacen.Categoria ;

    public partial class EditProductos
    {

        [Inject] private NavigationManager NavigationManager { get; set; }

        [Inject] private IProductoDataService ProductoDataService { get; set; }

        [Inject] private ICategoriaDataService CategoriaDataService { get; set; }
      
        [Inject] private IProductoFotoDataService ProductoFotoDataService { get; set; }

        [Parameter] public string ProductoId { get; set; }

        protected ShowAlert.Alert Alert { get; set; }

        public List<CategoriaViewModel> Categorias { get; set; } = new List<CategoriaViewModel>();

        private string CategoriaId { get; set; } = string.Empty;

        private bool Saved { get; set; }

        private NProducto.CrearViewModel Producto { get; set; } = new NProducto.CrearViewModel();

        protected override async Task OnInitializedAsync()
        {
            this.Saved = false;
            this.Categorias = (await this.CategoriaDataService.Listar().ConfigureAwait(false)).ToList();

            if (int.TryParse(ProductoId, NumberStyles.Integer, CultureInfo.InvariantCulture, out var productoId))
            {
                var producto = await this.ProductoDataService.Mostrar(productoId).ConfigureAwait(false);

                this.Producto = new NProducto.CrearViewModel
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
                this.Producto = new NProducto.CrearViewModel();
            }
        }

        protected async Task HandleValidSubmit()
        {
            bool resultado;
            this.Producto.CategoriaId = int.Parse(this.CategoriaId, NumberStyles.Integer, CultureInfo.InvariantCulture);

            if (int.TryParse(ProductoId, NumberStyles.Integer, CultureInfo.InvariantCulture, out var productoId))
            {
                var producto = new NProducto.ActualizarViewModel
                {
                    Id = productoId,
                    Nombre = this.Producto.Nombre,
                    Precio = this.Producto.Precio,
                    Marca = this.Producto.Marca,
                    Stock = this.Producto.Stock,
                    Descripcion = this.Producto.Descripcion,
                };
                resultado = await this.ProductoDataService.Actualizar(producto).ConfigureAwait(false);
            }
            else
            {
                resultado = await this.ProductoDataService.Crear(this.Producto).ConfigureAwait(false);
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
