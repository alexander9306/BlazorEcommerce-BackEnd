namespace Sistema.Shared.Services.Almacen.Marca
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Almacen.Marca;

    public class MarcaDataService : IMarcaDataService
    {
        private readonly HttpClient _httpClient;

        public MarcaDataService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<MarcaViewModel>> Listar()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<MarcaViewModel>>(
                    await _httpClient.GetStreamAsync($"listar").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }
    }
}
