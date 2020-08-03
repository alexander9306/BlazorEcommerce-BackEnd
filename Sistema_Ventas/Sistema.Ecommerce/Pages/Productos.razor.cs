namespace Sistema.Ecommerce.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;
    using Sistema.Ecommerce.Helpers;
    using Sistema.Ecommerce.Services.Almacen;
    using Sistema.Ecommerce.Services.Ordenes;
    using Sistema.Shared.Entidades.Almacen;
    using Sistema.Shared.Entidades.Almacen.Producto;

    public partial class Productos
    {
        [Parameter] public string ProductoId { get; set; }

        protected string errorMessage { get; set; }

        protected string CarritoToastMessage { get; set; }

        protected string CarritoToastTitle { get; set; }

        [Inject] protected IJSRuntime JSRuntime { get; set; }

        [Inject] public IProductoDataService ProductoDataService { get; set; }

        [Inject] public ICarritoDataService CarritoDataService { get; set; }

        [Inject] public IProductoHelper ProductoHelper { get; set; }

        public ProductoViewModel Producto { get; set; }

        public List<ProductoViewModel> RelProductos { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetProducto().ConfigureAwait(false);
        }

        protected async void AgregarCarrito()
        {
            var resultado = await this.CarritoDataService.Agregar(this.Producto.Id, 1).ConfigureAwait(false);

            if (resultado)
            {
                this.CarritoToastMessage = "Agregado satisfactoriamente";
                this.CarritoToastTitle = "Bien";
            }
            else
            {
                this.CarritoToastMessage = "Hubo un problema para agregar al carrito";
                this.CarritoToastTitle = "Error";
            }

            await this.MostrarToast().ConfigureAwait(false);
        }

        private async Task MostrarToast()
        {
            this.StateHasChanged();
            await this.JSRuntime.InvokeVoidAsync("CarritoToaster").ConfigureAwait(false);

        }

        private async Task GetProducto()
        {
            try
            {
                var productoId = int.Parse(this.ProductoId, NumberStyles.Integer, CultureInfo.InvariantCulture);
                if (productoId > 0)
                {
                    this.Producto = await this.ProductoDataService.Mostrar(productoId)
                        .ConfigureAwait(false);

                    if (this.Producto == null)
                    {
                        this.errorMessage = "Producto no encontrado.";
                    }
                    else
                    {
                        this.RelProductos = (await this.ProductoDataService.ListarRelacionados(this.Producto.Id, 3)
                            .ConfigureAwait(false)).ToList();
                    }
                }
                else
                {
                    this.errorMessage = "Hubo un error con su solicitud.";
                }
            }
            catch (Exception e)
            {
                this.errorMessage = "Hubo un error con su solicitud.";
            }
        }

        protected override async Task OnParametersSetAsync()
        {
            await GetProducto().ConfigureAwait(false);
        }
    }
}
