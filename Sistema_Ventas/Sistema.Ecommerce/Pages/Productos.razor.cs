namespace Sistema.Ecommerce.Pages
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Sistema.Ecommerce.Helpers;
    using Sistema.Ecommerce.Services;
    using Sistema.Shared.Entidades.Almacen;

    public partial class Productos
    {
        [Parameter]
        protected string ProductoId { get; set; }

        protected string errorMessage { get; set; }

        [Inject]
        public IProductoDataService ProductoDataService { get; set; }

        [Inject]
        public IProductoHelper ProductoHelper { get; set; }

        public Producto Producto { get; set; }

        public List<Producto> RelProductos { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if(int.TryParse(this.ProductoId, NumberStyles.Integer, CultureInfo.InvariantCulture, out var productoId) && productoId > 0)
            {
                this.Producto = await this.ProductoDataService.Mostrar(productoId)
                .ConfigureAwait(false);

                if(this.Producto == null){
                    this.errorMessage = "Producto no encontrado.";
                }else{
                    this.RelProductos = (await this.ProductoDataService.ListarRelacionados(this.Producto.Id, 4)
                    .ConfigureAwait(false)).ToList();
                }
            }
            else{
                this.errorMessage = "Hubo un error con su solicitud.";
            }
        }
    }
}
