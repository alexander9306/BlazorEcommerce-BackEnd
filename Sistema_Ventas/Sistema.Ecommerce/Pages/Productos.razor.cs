using System;

namespace Sistema.Ecommerce.Pages
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;
    using Sistema.Ecommerce.Helpers;
    using Sistema.Ecommerce.Services;
    using Sistema.Shared.Entidades.Almacen;

    public partial class Productos
    {
        [Parameter]
        public string ProductoId { get; set; }

        protected string errorMessage { get; set; }

        [Inject]
        public IProductoDataService ProductoDataService { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public IProductoHelper ProductoHelper { get; set; }

        public Producto Producto { get; set; }

        public List<Producto> RelProductos { get; set; }

        protected override async Task OnInitializedAsync()
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

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if (firstRender)
        //    {
        //        await JSRuntime.InvokeVoidAsync("LoadProductsGallery").ConfigureAwait(false);
        //    }
        //}
    }
}
