namespace Sistema.Ecommerce.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Sistema.Shared.Entidades.Almacen.Categoria;
    using Sistema.Shared.Entidades.Almacen.Marca;
    using Sistema.Shared.Entidades.Almacen.Producto;
    using Sistema.Shared.Helpers.Producto;
    using Sistema.Shared.Services.Almacen.Categoria;
    using Sistema.Shared.Services.Almacen.Marca;
    using Sistema.Shared.Services.Almacen.Producto;

    public partial class Catalogo
    {
        [Inject] public IProductoDataService ProductoDataService { get; set; }

        [Inject] public ICategoriaDataService CategoriaDataService { get; set; }

        [Inject] public IMarcaDataService MarcaDataService { get; set; }

        [Inject] public IProductoHelper ProductoHelper { get; set; }

        private bool HasMoreData;

        public List<ProductoViewModel> Productos { get; set; }

        public List<CategoriaViewModel> Categorias { get; set; }

        public List<MarcaViewModel> Marcas { get; set; }

        private List<int> _categoriaIds { get; set; } = new List<int>();

        private List<int> _marcaIds { get; set; } = new List<int>();

        protected override async Task OnInitializedAsync()
        {
            this.Categorias = (await this.CategoriaDataService.Listar()
            .ConfigureAwait(false)).ToList();

            this.Marcas = (await this.MarcaDataService.Listar()
                .ConfigureAwait(false)).ToList();

            this.GetPaginationInfo(
                (await this.ProductoDataService.Listar(10)
                    .ConfigureAwait(false)).ToList());
        }

        protected async void GetMoreData()
        {
            var before = this.Productos[^1].UpdatedAt;

            if (this._marcaIds.Count > 0 || this._categoriaIds.Count > 0)
            {
                this.GetPaginationInfo(
                    (await this.ProductoDataService.ListarPorFiltro(this._categoriaIds, this._marcaIds, 10, before)
                        .ConfigureAwait(false)).ToList(), true);
            }
            else
            {
                this.GetPaginationInfo(
                    (await this.ProductoDataService.Listar(10, before)
                    .ConfigureAwait(false)).ToList(), true);
            }
        }

        protected void FiltrarCategorias(int cateoriaId, object checkedValue)
        {
            if ((bool)checkedValue)
            {
                this._categoriaIds.Add(cateoriaId);
            }
            else
            {
                this._categoriaIds.Remove(cateoriaId);
            }

            this.BuscarFiltro();
        }

        protected void FiltrarMarcas(int marcaId, object checkedValue)
        {
            if ((bool)checkedValue)
            {
                this._marcaIds.Add(marcaId);
            }
            else
            {
                this._marcaIds.Remove(marcaId);
            }

            this.BuscarFiltro();
        }

        private async void BuscarFiltro()
        {
            this.GetPaginationInfo(
                (await this.ProductoDataService.ListarPorFiltro(this._categoriaIds, this._marcaIds, 10)
                    .ConfigureAwait(false)).ToList());
        }

        private void GetPaginationInfo(List<ProductoViewModel> productos, bool add = false)
        {
            if (productos != null && productos.Count == 10)
            {
                this.HasMoreData = true;
                productos.RemoveAt(productos.Count - 1);
                if (add)
                {
                    this.Productos.AddRange(productos);
                }
                else
                {
                    this.Productos = productos;
                }
            }
            else
            {
                this.HasMoreData = false;
                if (add)
                {
                    this.Productos.AddRange(productos);
                }
                else
                {
                    this.Productos = productos;
                }
            }

            this.StateHasChanged();
        }
    }
}
