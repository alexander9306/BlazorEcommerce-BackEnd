namespace Sistema.Shared.Services.Ordenes.Pago
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Blazored.LocalStorage;
    using Sistema.Shared.Entidades.Ordenes.Pago;

    public class PagoDataService : IPagoDataService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public PagoDataService(HttpClient httpClient, ILocalStorageService localStorage)
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

        public async Task<IEnumerable<PagoViewModel>> Listar(int limit, DateTime? before = null)
        {
            await this.AgregarToken().ConfigureAwait(false);

            var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";

            return await JsonSerializer.DeserializeAsync<IEnumerable<PagoViewModel>>(
                    await _httpClient.GetStreamAsync($"listar/{limit}/{cursor}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<PagoViewModel>> ListarPorOrden(int ordenId, int limit, DateTime? before = null)
        {
            await this.AgregarToken().ConfigureAwait(false);

            var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";

            return await JsonSerializer.DeserializeAsync<IEnumerable<PagoViewModel>>(
                    await _httpClient.GetStreamAsync($"listarPorOrden/{ordenId}/{limit}/{cursor}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }

        public async Task<PagoViewModel> Mostrar(int id)
        {
            await this.AgregarToken().ConfigureAwait(false);

            return await JsonSerializer.DeserializeAsync<PagoViewModel>(
                    await this._httpClient.GetStreamAsync($"mostrar/{id}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).ConfigureAwait(false);
        }

        public Task<bool> Desactivar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Activar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Actualizar(object pago)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Crear(CrearViewModel pago)
        {
            throw new NotImplementedException();
        }
    }
}
