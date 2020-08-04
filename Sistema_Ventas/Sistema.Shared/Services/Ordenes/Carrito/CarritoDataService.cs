namespace Sistema.Shared.Services.Ordenes.Carrito
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Blazored.LocalStorage;
    using Sistema.Shared.Entidades.Ordenes.Carrito;

    public class CarritoDataService : ICarritoDataService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public CarritoDataService(HttpClient httpClient,
            ILocalStorageService localStorage)
        {
            this._httpClient = httpClient;
            this._localStorage = localStorage;
        }

        public async Task<CarritoViewModel> Mostrar()
        {
            await this.AgregarToken().ConfigureAwait(false);
            try
            {
                return await JsonSerializer.DeserializeAsync<CarritoViewModel>(
                        await this._httpClient.GetStreamAsync($"mostrar").ConfigureAwait(false),
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                    .ConfigureAwait(false);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Agregar(int productoId, int cantidad)
        {
            var carritoJson =
#pragma warning disable CA2000 // Dispose objects before losing scope
                new StringContent(JsonSerializer.Serialize(new { ProductoId = productoId, Cantidad = cantidad }), Encoding.UTF8, "application/json");
#pragma warning restore CA2000 // Dispose objects before losing scope

            await this.AgregarToken().ConfigureAwait(false);

            var response = await this._httpClient.PostAsync("agregar", carritoJson).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }

            return false;
        }

        private async Task AgregarToken()
        {
            var token = await this._localStorage.GetItemAsync<string>("authToken").ConfigureAwait(false);

            if (!string.IsNullOrEmpty(token))
            {
                this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        Task<bool> ICarritoDataService.Remover(int productoId)
        {
            throw new System.NotImplementedException();
        }
    }
}