namespace Sistema.Ecommerce.Services
{
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Ordenes;

    public class CarritoDataService : ICarritoDataService
    {
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

        public async Task<Carrito> Agregar(int productoId, int cantidad)
        {
            var carritoJson =
                new StringContent(JsonSerializer.Serialize((ProductoId: productoId, Cantidad: cantidad)), Encoding.UTF8, "application/json");

            var response = await this._httpClient.PostAsync("agregar", carritoJson).ConfigureAwait(false);

            if (response != null && response.StatusCode == HttpStatusCode.Created)
            {

            }
            throw new System.NotImplementedException();
        }

        Task<Carrito> ICarritoDataService.Remover(int productoId)
        {
            throw new System.NotImplementedException();
        }
    }
}