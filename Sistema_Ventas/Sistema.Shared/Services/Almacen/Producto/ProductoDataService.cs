namespace Sistema.Shared.Services.Almacen.Producto
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.WebUtilities;
    using Sistema.Shared.Entidades.Almacen.Producto;

    public class ProductoDataService : IProductoDataService
    {
        private readonly HttpClient _httpClient;

        public ProductoDataService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductoViewModel>> Listar(int limit, DateTime? before = null)
        {
            var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";

            return await JsonSerializer.DeserializeAsync<IEnumerable<ProductoViewModel>>(
                    await _httpClient.GetStreamAsync($"listar/{limit}/{cursor}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<ProductoViewModel>> ListarRelacionados(int productoId, int limit, DateTime? before = null)
        {
            var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";

            return await JsonSerializer.DeserializeAsync<IEnumerable<ProductoViewModel>>(
                    await _httpClient.GetStreamAsync($"listarRelacionados/{productoId}/{limit}/{cursor}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }

        public async Task<ProductoViewModel> Mostrar(int id)
        {
            return await JsonSerializer.DeserializeAsync<ProductoViewModel>(
                    await this._httpClient.GetStreamAsync($"mostrar/{id}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).ConfigureAwait(false);
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
