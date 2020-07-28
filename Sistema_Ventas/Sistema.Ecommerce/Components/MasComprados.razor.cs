namespace Sistema.Ecommerce.Components
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Sistema.Ecommerce.Helpers;
    using Sistema.Ecommerce.Services;
    using Sistema.Shared.Entidades.Almacen;

    public partial class MasComprados
    {
        [Inject]
        public IProductoDataService ProductoDataService { get; set; }

        [Inject]
        public IProductoHelper PoductoHelper { get; set; }

        public List<Producto> Productos { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.Productos = (await this.ProductoDataService.Listar(6, null)
                .ConfigureAwait(false)).ToList();
        }
    }
}
