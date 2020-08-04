namespace Sistema.Ecommerce.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Sistema.Shared.Entidades.Ordenes.Orden;
    using Sistema.Shared.Services.Ordenes.Orden;

    public partial class Ordenes
    {
        protected List<OrdenViewModel> ListaOrdenes { get; set; }

        [Inject] private IOrdenDataService OrdenDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.ListaOrdenes = (await OrdenDataService.Listar(8).ConfigureAwait(false)).ToList();
        }
    }
}
