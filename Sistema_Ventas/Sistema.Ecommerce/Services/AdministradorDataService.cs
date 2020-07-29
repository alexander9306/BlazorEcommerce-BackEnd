namespace Sistema.Ecommerce.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Usuario;

    public class AdministradorDataService : IAdministradorDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;

        public AdministradorDataService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            this._baseAddress = "api/administradores";
        }

        public async Task<IEnumerable<Administrador>> Listar()
        {

            var res = await JsonSerializer.DeserializeAsync<IEnumerable<Administrador>>(
                    await _httpClient.GetStreamAsync($"{_baseAddress}/listar").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
            return res;
        }

        public async Task<Administrador> Mostrar(int id)
        {
            return await JsonSerializer.DeserializeAsync<Administrador>(
                    await this._httpClient.GetStreamAsync($"{_baseAddress}/mostrar/{id}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).ConfigureAwait(false);
        }

    }
}
