namespace Sistema.Ecommerce.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Usuario;

    public class ClienteDataService : IClienteDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;

        public ClienteDataService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            this._baseAddress = "api/clientes";
        }

        public async Task<IEnumerable<Cliente>> Listar()
        {

            var res = await JsonSerializer.DeserializeAsync<IEnumerable<Cliente>>(
                    await _httpClient.GetStreamAsync($"{_baseAddress}/listar").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
            return res;
        }

        public async Task<Cliente> Mostrar(int id)
        {
            return await JsonSerializer.DeserializeAsync<Cliente>(
                    await this._httpClient.GetStreamAsync($"{_baseAddress}/mostrar/{id}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).ConfigureAwait(false);
        }

    }
}
