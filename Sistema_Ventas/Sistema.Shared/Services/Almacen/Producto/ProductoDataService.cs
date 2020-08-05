namespace Sistema.Shared.Services.Almacen.Producto
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
    using Sistema.Shared.Entidades.Almacen.Producto;

    public class ProductoDataService : IProductoDataService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public ProductoDataService(HttpClient httpClient, ILocalStorageService localStorage)
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

        public async Task<IEnumerable<ProductoViewModel>> Listar(int limit, DateTime? before = null)
        {
            await this.AgregarToken().ConfigureAwait(false);

            var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";

            return await JsonSerializer.DeserializeAsync<IEnumerable<ProductoViewModel>>(
                    await _httpClient.GetStreamAsync($"listar/{limit}/{cursor}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<ProductoViewModel>> ListarRelacionados(int productoId, int limit, DateTime? before = null)
        {
            await this.AgregarToken().ConfigureAwait(false);

            var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";

            return await JsonSerializer.DeserializeAsync<IEnumerable<ProductoViewModel>>(
                    await _httpClient.GetStreamAsync($"listarRelacionados/{productoId}/{limit}/{cursor}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }


        public async Task<ProductoViewModel> Mostrar(int id)
        {
            await this.AgregarToken().ConfigureAwait(false);

            return await JsonSerializer.DeserializeAsync<ProductoViewModel>(
                await this._httpClient.GetStreamAsync($"mostrar/{id}").ConfigureAwait(false),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).ConfigureAwait(false);
        }

        public async Task<bool> Activar(int id)
        {
            await this.AgregarToken().ConfigureAwait(false);

            var response = await this._httpClient.PutAsync($"activar/{id}", null).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Desactivar(int id)
        {
            await this.AgregarToken().ConfigureAwait(false);

            var response = await this._httpClient.PutAsync($"desactivar/{id}", null).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Crear(CrearViewModel model)
        {
            await this.AgregarToken().ConfigureAwait(false);

            var modelJson =
                new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await this._httpClient.PostAsync($"crear", modelJson).ConfigureAwait(false);

            modelJson.Dispose();

            return response.StatusCode == HttpStatusCode.Created;
        }

        public async Task<bool> Actualizar(ActualizarViewModel model)
        {
            await this.AgregarToken().ConfigureAwait(false);

            var modelJson =
                new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            Console.WriteLine(modelJson.ToString());
            var response = await this._httpClient.PutAsync($"actualizar/{model.Id}", modelJson).ConfigureAwait(false);

            modelJson.Dispose();

            return response.StatusCode == HttpStatusCode.NoContent;
        }


        public async Task<IEnumerable<ProductoViewModel>> ListarPorFiltro(List<int> categoriaIds, List<int> marcaIds, int limit, DateTime? before = null)
        {
            var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";
            var filtro = "filtro";

            foreach (var value in categoriaIds)
            {
                filtro = QueryHelpers.AddQueryString(filtro, "categoriaId", value.ToString());
            }

            foreach (var value in marcaIds)
            {
                filtro = QueryHelpers.AddQueryString(filtro, "marcaId", value.ToString());
            }

            return await JsonSerializer.DeserializeAsync<IEnumerable<ProductoViewModel>>(
                    await _httpClient.GetStreamAsync($"ListarPorFiltro/{limit}/{cursor}/{filtro}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }
    }
}
