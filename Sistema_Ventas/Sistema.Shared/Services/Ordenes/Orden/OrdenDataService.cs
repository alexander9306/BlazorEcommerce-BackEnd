namespace Sistema.Shared.Services.Ordenes.Orden
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
    using Sistema.Shared.Entidades.Ordenes.Orden;

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

        public async Task<IEnumerable<OrdenViewModel>> Listar(int limit, DateTime? before = null)
        {
            await this.AgregarToken().ConfigureAwait(false);

            var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";

            return await JsonSerializer.DeserializeAsync<IEnumerable<OrdenViewModel>>(
                    await _httpClient.GetStreamAsync($"listar/{limit}/{cursor}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<OrdenViewModel>> ListarPorCliente(int clienteId, int limit, DateTime? before = null)
        {
            await this.AgregarToken().ConfigureAwait(false);

            var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";

            return await JsonSerializer.DeserializeAsync<IEnumerable<OrdenViewModel>>(
                    await _httpClient.GetStreamAsync($"listarporcliente/{clienteId}/{limit}/{cursor}").ConfigureAwait(false),
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

        public async Task<OrdenViewModel> Mostrar(int id)
        {
            await this.AgregarToken().ConfigureAwait(false);

            return await JsonSerializer.DeserializeAsync<OrdenViewModel>(
                    await this._httpClient.GetStreamAsync($"mostrar/{id}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).ConfigureAwait(false);
        }

        public Task<bool> Activar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Desactivar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Actualizar(ActualizarViewModel orden)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Crear(CrearViewModel orden)
        {
            throw new NotImplementedException();
        }
    }
}
