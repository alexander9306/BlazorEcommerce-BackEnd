namespace Sistema.Shared.Services.Almacen.Categoria
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Almacen.Categoria;

    public class CategoriaDataService: ICategoriaDataService
    {
        private readonly HttpClient _httpClient;

        public CategoriaDataService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoriaViewModel>> Listar()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<CategoriaViewModel>>(
                    await _httpClient.GetStreamAsync($"listar").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }

    }
}
