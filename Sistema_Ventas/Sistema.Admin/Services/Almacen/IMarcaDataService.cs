namespace Sistema.Admin.Services.Almacen
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Almacen;

    public interface IMarcaDataService
    {
        Task<IEnumerable<Marca>> Listar();
    }
}
