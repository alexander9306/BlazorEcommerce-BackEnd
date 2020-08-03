namespace Sistema.Ecommerce.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Sistema.Ecommerce.Services.Ordenes;
    using Sistema.Shared.Entidades.Ordenes.Orden;

    public partial class Ordenes
    {
        [Inject] private IOrdenDataService OrdenDataService { get; set; }

        protected List<OrdenViewModel> ListaOrdenes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.ListaOrdenes = (await OrdenDataService.Listar(8).ConfigureAwait(false)).ToList();
        }
    }
}
