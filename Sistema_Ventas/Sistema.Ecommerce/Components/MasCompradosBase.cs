namespace Sistema.Ecommerce.Components
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Sistema.Ecommerce.Services;
    using Sistema.Shared.Entidades.Almacen;

    public class MasCompradosBase : ComponentBase
    {
        [Inject]
        public IProductoDataService ProductoDataService { get; set; }

        public List<Producto> Productos { get; set; }

        public int Counter { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.Productos = (await this.ProductoDataService.Listar(2, "2")
                .ConfigureAwait(false)).ToList();
        }
    }
}
