namespace Sistema.Shared.Services.Ordenes.Pedido
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Blazored.LocalStorage;
    using Sistema.Shared.Entidades.Ordenes.Pedido;

    public class PedidoDataService : IPedidoDataService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public PedidoDataService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            this._httpClient = httpClient;
            this._localStorage = localStorage;
        }

        private async Task AgregarToken()
        {
            var token = await this._localStorage.GetItemAsync<string>("authToken").ConfigureAwait(false);

            if (!string.IsNullOrEmpty(token))
            {
                this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<IEnumerable<PedidoViewModel>> Listar(int limit, DateTime? before = null)
        {
            await this.AgregarToken().ConfigureAwait(false);

            var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";

            return await JsonSerializer.DeserializeAsync<IEnumerable<PedidoViewModel>>(
                    await _httpClient.GetStreamAsync($"listar/{limit}/{cursor}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<PedidoViewModel>> ListarPorOrden(int ordenId, int limit, DateTime? before = null)
        {
            await this.AgregarToken().ConfigureAwait(false);

            var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";

            return await JsonSerializer.DeserializeAsync<IEnumerable<PedidoViewModel>>(
                    await _httpClient.GetStreamAsync($"listarPorOrden/{ordenId}/{limit}/{cursor}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }

        //public async Task<bool> Actualizar(ActualizarViewModel model)
        //{
        //    await this.AgregarToken().ConfigureAwait(false);

        //    var modelJson =
        //        new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
        //    var response = await this._httpClient.PutAsync($"actualizar/{model.Id}", modelJson).ConfigureAwait(false);

        //    modelJson.Dispose();

        //    return response.StatusCode == HttpStatusCode.NoContent;
        //}

        public async Task<PedidoViewModel> Mostrar(int id)
        {
            await this.AgregarToken().ConfigureAwait(false);

            return await JsonSerializer.DeserializeAsync<PedidoViewModel>(
                    await this._httpClient.GetStreamAsync($"mostrar/{id}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).ConfigureAwait(false);
        }
    }
}
