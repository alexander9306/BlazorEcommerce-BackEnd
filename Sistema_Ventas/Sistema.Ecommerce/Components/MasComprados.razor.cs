namespace Sistema.Ecommerce.Components
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Sistema.Shared.Entidades.Almacen.Producto;
    using Sistema.Shared.Helpers.Producto;
    using Sistema.Shared.Services.Almacen.Producto;

    public partial class MasComprados
    {
        [Inject]
        public IProductoDataService ProductoDataService { get; set; }

        [Inject]
        public IProductoHelper PoductoHelper { get; set; }

        public List<ProductoViewModel> Productos { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.Productos = (await this.ProductoDataService.Listar(6, null)
                .ConfigureAwait(false)).ToList();
        }
    }
}
