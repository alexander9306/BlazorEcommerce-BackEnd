using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Ecommerce.Pages
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;
    using Sistema.Ecommerce.Services.Ordenes;
    using Sistema.Shared.Entidades.Ordenes;

    public partial class Ordenes
    {
        [Inject] private IOrdenDataService OrdenDataService { get; set; }

        protected List<Orden> ListaOrdenes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.ListaOrdenes = (await OrdenDataService.Listar(8).ConfigureAwait(false)).ToList();
        }
    }
}
