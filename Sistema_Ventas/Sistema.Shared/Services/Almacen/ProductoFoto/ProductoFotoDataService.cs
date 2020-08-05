using System;

namespace Sistema.Shared.Services.Almacen.ProductoFoto
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Blazored.LocalStorage;
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

        public async Task<bool> Crear(CrearProductofotoViewModel model, long length, string filename)
        {
            await this.AgregarToken().ConfigureAwait(false);

            var ms = new MemoryStream();
            await model.Foto.CopyToAsync(ms);

            var content = new MultipartFormDataContent();
            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
            content.Add(new StreamContent(model.Foto, (int)length), "foto", filename);

            var response = await this._httpClient.PostAsync($"crear/{model.ProductoId}", content).ConfigureAwait(false);
            Console.WriteLine(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            content.Dispose();

            return response.StatusCode == HttpStatusCode.Created;
        }

        public async Task<bool> Eliminar(int fotoId)
        {
            await this.AgregarToken().ConfigureAwait(false);

            var response = await this._httpClient.DeleteAsync($"eliminar/{fotoId}").ConfigureAwait(false);

            return response.StatusCode == HttpStatusCode.NoContent;
        }
    }
}
