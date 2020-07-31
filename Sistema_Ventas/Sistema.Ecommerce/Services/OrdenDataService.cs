namespace Sistema.Ecommerce.Services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Almacen;
    using Sistema.Shared.Entidades.Ordenes;

    public class OrdenDataService : IOrdenDataService
    {
        private readonly HttpClient _httpClient;

        public OrdenDataService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<Orden>> Listar(int limit, DateTime? before = null)
        {
            var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";

            return await JsonSerializer.DeserializeAsync<IEnumerable<Orden>>(
                    await _httpClient.GetStreamAsync($"listar/{limit}/{cursor}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Orden>> ListarPorCliente(int clienteId, int limit, DateTime? before = null)
        {
            var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";

            return await JsonSerializer.DeserializeAsync<IEnumerable<Orden>>(
                    await _httpClient.GetStreamAsync($"listarPorCliente/{clienteId}/{limit}/{cursor}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }

        public async Task<Orden> Mostrar(int id)
        {
            return await JsonSerializer.DeserializeAsync<Orden>(
                    await this._httpClient.GetStreamAsync($"mostrar/{id}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).ConfigureAwait(false);
        }
    }
}
