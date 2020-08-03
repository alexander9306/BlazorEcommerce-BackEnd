namespace Sistema.Ecommerce.Services.Almacen
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Almacen;
    using Sistema.Shared.Entidades.Almacen.Categoria;

    public interface ICategoriaDataService
    {
        Task<IEnumerable<CategoriaViewModel>> Listar();
    }
}
