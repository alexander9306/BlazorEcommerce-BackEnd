namespace Sistema.Admin.Services.Almacen
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Almacen;

    public interface ICategoriaDataService
    {
        Task<IEnumerable<Categoria>> Listar();
    }
}
