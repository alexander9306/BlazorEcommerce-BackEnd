namespace Sistema.Ecommerce.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Usuario;

    public class RolDataService : IRolDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;

        public RolDataService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            this._baseAddress = "api/roles";
        }

        public async Task<IEnumerable<Rol>> Listar()
        {

            var res = await JsonSerializer.DeserializeAsync<IEnumerable<Rol>>(
                    await _httpClient.GetStreamAsync($"{_baseAddress}/listar").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
            return res;
        }

    }
}
