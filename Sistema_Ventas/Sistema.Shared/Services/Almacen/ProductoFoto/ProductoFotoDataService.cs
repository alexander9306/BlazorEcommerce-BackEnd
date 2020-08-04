namespace Sistema.Shared.Services.Almacen.ProductoFoto
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
    using Microsoft.AspNetCore.WebUtilities;
    using Sistema.Shared.Entidades.Almacen.ProductoFoto;

    public class ProductoFotoDataService : IProductoFotoDataService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public ProductoFotoDataService(HttpClient httpClient, ILocalStorageService localStorage)
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

        public async Task<IEnumerable<ProductoFotoViewModel>> Listar(int productoId)
        {
            await this.AgregarToken().ConfigureAwait(false);

            return await JsonSerializer.DeserializeAsync<IEnumerable<ProductoFotoViewModel>>(
                    await _httpClient.GetStreamAsync($"listar/{productoId}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }

        public async Task<bool> Crear(CrearProductofotoViewModel model)
        {
            await this.AgregarToken().ConfigureAwait(false);

            var modelJson =
                new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await this._httpClient.PostAsync($"crear", modelJson).ConfigureAwait(false);

            modelJson.Dispose();

            return response.StatusCode == HttpStatusCode.Created;
        }

        public async Task<bool> Actualizar(ActualizarProductoFotoViewModel model)
        {
            await this.AgregarToken().ConfigureAwait(false);

            var modelJson =
                new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await this._httpClient.PutAsync($"actualizar/{model.Id}", modelJson).ConfigureAwait(false);

            modelJson.Dispose();

            return response.StatusCode == HttpStatusCode.NoContent;
        }
    }
}
