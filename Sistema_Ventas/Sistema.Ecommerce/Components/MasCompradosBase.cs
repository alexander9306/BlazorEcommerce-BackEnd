namespace Sistema.Ecommerce.Components
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Components;
    using Sistema.Ecommerce.Services;
    using Sistema.Shared.Entidades.Almacen;

    public class MasCompradosBase : ComponentBase
    {
        [Inject]
        public IProductoDataService ProductoDataService { get; set; }

        private Cloudinary _cloudinary;

        public List<Producto> Productos { get; set; }


        public string GetDescripcion(string descripcion)
        {
            if (descripcion == null)
            {
                return string.Empty;
            }

            return descripcion.Length < 60 ? descripcion : descripcion.Substring(0, 60) + "...";
        }

        public string GetFotoUrl(ProductoFoto? foto)
        {
            if (foto == null)
            {
                return this._cloudinary.Api.UrlImgUp.Transform(
                    new Transformation().Width(338).Height(250)).BuildUrl("112815953-no-image-available-icon-flat-vector_a5tdo9.jpg");
            }

            return this._cloudinary.Api.UrlImgUp.Transform(
                new Transformation().Width(338).Height(250)).BuildUrl(foto.FotoPublicId);
        }

        protected override async Task OnInitializedAsync()
        {
            var account = new Account("alexander-damaso-26857");
            this._cloudinary = new Cloudinary(account);
            this.Productos = (await this.ProductoDataService.Listar(6, null)
                .ConfigureAwait(false)).ToList();
        }
    }
}
