namespace Sistema.Ecommerce.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Sistema.Ecommerce.Helpers;
    using Sistema.Ecommerce.Services;
    using Sistema.Shared.Entidades.Almacen;

    public partial class Catalogo : ComponentBase
    {
        [Inject]
        public IProductoDataService ProductoDataService { get; set; }

        [Inject]
        public ICategoriaDataService CategoriaDataService { get; set; }

        [Inject]
        public IProductoHelper PoductoHelper { get; set; }

        [Parameter]
        public string CategoriaId { get; set; }

        [Parameter]
        public string Marca { get; set; }

        public bool HasMoreData;

        public List<Producto> Productos { get; set; }

        public List<Categoria> Categorias { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.Categorias = (await this.CategoriaDataService.Listar()
            .ConfigureAwait(false)).ToList();

            if (int.TryParse(this.CategoriaId, out var categoriaId))
            {
                this.GetPaginationInfo(
                    (await this.ProductoDataService.ListarPorCategoria(categoriaId, 10, null)
                    .ConfigureAwait(false)).ToList(), false);
            }
            else if (!string.IsNullOrEmpty(this.Marca))
            {
                this.GetPaginationInfo(
                    (await this.ProductoDataService.ListarPorMarca(this.Marca, 10, null)
                    .ConfigureAwait(false)).ToList(), false);
            }
            else
            {
                this.GetPaginationInfo(
                    (await this.ProductoDataService.Listar(10, null)
                    .ConfigureAwait(false)).ToList(), false);
            }
        }

        public async void GetMoreData()
        {
            var before = Productos[^1].UpdatedAt;

            if (int.TryParse(this.CategoriaId, out var categoriaId))
            {
                this.GetPaginationInfo(
                    (await this.ProductoDataService.ListarPorCategoria(categoriaId, 10, before)
                    .ConfigureAwait(false)).ToList(), true);
            }
            else if (!string.IsNullOrEmpty(this.Marca))
            {
                this.GetPaginationInfo(
                    (await this.ProductoDataService.ListarPorMarca(this.Marca, 10, before)
                    .ConfigureAwait(false)).ToList(), true);
            }
            else
            {
                this.GetPaginationInfo(
                    (await this.ProductoDataService.Listar(10, before)
                    .ConfigureAwait(false)).ToList(), true);
            }
        }

        private void GetPaginationInfo(List<Producto> productos, bool? add)
        {
            if (productos.Count == 10)
            {
                this.HasMoreData = true;
                productos.RemoveAt(productos.Count - 1);
                if (add ?? false)
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
                if (add ?? false)
                {
                    this.Productos.AddRange(productos);
                }
                else
                {
                    this.Productos = productos;
                }
            }
        }
    }
}
