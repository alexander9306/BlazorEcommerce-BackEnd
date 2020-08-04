namespace Sistema.Shared.Services.Almacen.Categoria
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;
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
                    await this._httpClient.GetStreamAsync($"listar").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }

        public async Task<CategoriaViewModel> Mostrar(int id)
        {
            return await JsonSerializer.DeserializeAsync<CategoriaViewModel>(
                await this._httpClient.GetStreamAsync($"mostrar/{id}").ConfigureAwait(false),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).ConfigureAwait(false);
        }

        public async Task<bool> Activar(int id)
        {
            var response = await this._httpClient.PutAsync($"activar/{id}", null).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Desactivar(int id)
        {
            var response = await this._httpClient.PutAsync($"desactivar/{id}", null).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Crear(CrearViewModel model)
        {
            var modelJson =
                new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await this._httpClient.PostAsync($"crear", modelJson).ConfigureAwait(false);

            modelJson.Dispose();

            return response.StatusCode == HttpStatusCode.Created;
        }

        public async Task<bool> Actualizar(ActualizarViewModel model)
        {
            var modelJson =
                new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await this._httpClient.PutAsync($"actualizar/{model.Id}", modelJson).ConfigureAwait(false);

            modelJson.Dispose();

            return response.StatusCode == HttpStatusCode.NoContent;
        }
    }
}
