namespace Sistema.Ecommerce.Services.Ordenes
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Ordenes;

    public class PedidoDataService : IPedidoDataService
    {
        private readonly HttpClient _httpClient;

        public PedidoDataService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<Pedido>> Listar(int limit, DateTime? before = null)
        {
            var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";

            return await JsonSerializer.DeserializeAsync<IEnumerable<Pedido>>(
                    await _httpClient.GetStreamAsync($"listar/{limit}/{cursor}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Pedido>> ListarPorOrden(int ordenId, int limit, DateTime? before = null)
        {
            var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";

            return await JsonSerializer.DeserializeAsync<IEnumerable<Pedido>>(
                    await _httpClient.GetStreamAsync($"listarPorOrden/{ordenId}/{limit}/{cursor}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }

        public async Task<Pedido> Mostrar(int id)
        {
            return await JsonSerializer.DeserializeAsync<Pedido>(
                    await this._httpClient.GetStreamAsync($"mostrar/{id}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).ConfigureAwait(false);
        }
    }
}
