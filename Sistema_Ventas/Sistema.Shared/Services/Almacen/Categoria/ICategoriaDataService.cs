namespace Sistema.Shared.Services.Almacen.Categoria
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Almacen.Categoria;

    public interface ICategoriaDataService
    {
        Task<IEnumerable<CategoriaViewModel>> Listar();

        Task<CategoriaViewModel> Mostrar(int id);

        Task<bool> Activar(int id);

        Task<bool> Desactivar(int id);

        Task<bool> Crear(CrearViewModel model);

        Task<bool> Actualizar(ActualizarViewModel model);
    }
}
