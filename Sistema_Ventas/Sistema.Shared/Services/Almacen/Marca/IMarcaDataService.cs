namespace Sistema.Shared.Services.Almacen.Marca
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Almacen.Marca;

    public interface IMarcaDataService
    {
        Task<IEnumerable<MarcaViewModel>> Listar();
    }
}
