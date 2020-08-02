namespace Sistema.Ecommerce.Services.Ordenes
{
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.JSInterop;
    using Sistema.Shared.Entidades.Ordenes;

    public class CarritoDataService : ICarritoDataService
    {
        private IJSRuntime JSRuntime;

        private readonly HttpClient _httpClient;

        public CarritoDataService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<Carrito> Mostrar()
        {
            return await JsonSerializer.DeserializeAsync<Carrito>(
                    await this._httpClient.GetStreamAsync($"mostrar").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }

        public async Task<bool> Agregar(int productoId, int cantidad)
        {
            var carritoJson =
#pragma warning disable CA2000 // Dispose objects before losing scope
                new StringContent(JsonSerializer.Serialize(new { ProductoId = productoId, Cantidad = cantidad }), Encoding.UTF8, "application/json");
#pragma warning restore CA2000 // Dispose objects before losing scope

            var response = await this._httpClient.PostAsync("agregar", carritoJson).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }

            return false;
        }

        Task<bool> ICarritoDataService.Remover(int productoId)
        {
            throw new System.NotImplementedException();
        }
    }
}