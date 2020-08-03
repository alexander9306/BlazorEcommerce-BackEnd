namespace Sistema.Admin.Services.Ordenes
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
    using Sistema.Shared.Entidades.Ordenes;

    public class OrdenDataService : IOrdenDataService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public OrdenDataService(HttpClient httpClient,
            ILocalStorageService localStorage)
        {
            this._httpClient = httpClient;
            this._localStorage = localStorage;
        }

        public async Task<bool> Crear(OrdenCrear model)
        {
            var ordenJson =
                new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            await this.AgregarToken().ConfigureAwait(false);

            var response = await this._httpClient.PostAsync("crear", ordenJson).ConfigureAwait(false);

            ordenJson.Dispose();

            if (response.StatusCode == HttpStatusCode.Created)
            {
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Orden>> Listar(int limit, DateTime? before = null)
        {
            await this.AgregarToken().ConfigureAwait(false);

            var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";

            return await JsonSerializer.DeserializeAsync<IEnumerable<Orden>>(
                    await _httpClient.GetStreamAsync($"listar/{limit}/{cursor}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }

        private async Task AgregarToken()
        {
            var token = await this._localStorage.GetItemAsync<string>("authToken").ConfigureAwait(false);

            if (!string.IsNullOrEmpty(token))
            {
                this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<Orden> Mostrar(int id)
        {
            await this.AgregarToken().ConfigureAwait(false);

            return await JsonSerializer.DeserializeAsync<Orden>(
                    await this._httpClient.GetStreamAsync($"mostrar/{id}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).ConfigureAwait(false);
        }
    }
}
