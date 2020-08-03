<<<<<<< HEAD:Sistema_Ventas/Sistema.Ecommerce/Services/ProductoDataService.cs
﻿namespace Sistema.Ecommerce.Services
=======
﻿namespace Sistema.Admin.Services.Almacen
>>>>>>> master:Sistema_Ventas/Sistema.Admin/Services/Almacen/ProductoDataService.cs
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.WebUtilities;
    using Sistema.Shared.Entidades.Almacen;

    public class ProductoDataService : IProductoDataService
    {
        private readonly HttpClient _httpClient;

        public ProductoDataService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<Producto>> Listar(int limit, DateTime? before = null)
        {
            var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";

            return await JsonSerializer.DeserializeAsync<IEnumerable<Producto>>(
                    await _httpClient.GetStreamAsync($"listar/{limit}/{cursor}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }

<<<<<<< HEAD:Sistema_Ventas/Sistema.Ecommerce/Services/ProductoDataService.cs
=======
        public async Task<IEnumerable<Producto>> ListarRelacionados(int productoId, int limit, DateTime? before = null)
        {
            var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";

            return await JsonSerializer.DeserializeAsync<IEnumerable<Producto>>(
                    await _httpClient.GetStreamAsync($"listarRelacionados/{productoId}/{limit}/{cursor}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }

>>>>>>> master:Sistema_Ventas/Sistema.Admin/Services/Almacen/ProductoDataService.cs
        public async Task<Producto> Mostrar(int id)
        {
            return await JsonSerializer.DeserializeAsync<Producto>(
                    await this._httpClient.GetStreamAsync($"mostrar/{id}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).ConfigureAwait(false);
        }

<<<<<<< HEAD:Sistema_Ventas/Sistema.Ecommerce/Services/ProductoDataService.cs
        //public async Task<IEnumerable<Producto>> ListarPorCategoria(int categoriId, int limit, DateTime? before)
        //{
        //    var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";

        //    return await JsonSerializer.DeserializeAsync<IEnumerable<Producto>>(
        //            await _httpClient.GetStreamAsync($"ListarPorCategoria/{categoriId}/{limit}/{cursor}").ConfigureAwait(false),
        //            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
        //        .ConfigureAwait(false);
        //}

        //public async Task<IEnumerable<Producto>> ListarPorMarca(string marca, int limit, DateTime? before)
        //{
        //    var cursor = before.HasValue ? before.Value.ToString("O", CultureInfo.InvariantCulture) : "null";

        //    return await JsonSerializer.DeserializeAsync<IEnumerable<Producto>>(
        //            await _httpClient.GetStreamAsync($"ListarPorMarca/{marca}/{limit}/{cursor}").ConfigureAwait(false),
        //            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
        //        .ConfigureAwait(false);
        //}

=======
>>>>>>> master:Sistema_Ventas/Sistema.Admin/Services/Almacen/ProductoDataService.cs
        public async Task<IEnumerable<Producto>> ListarPorFiltro(List<int> categoriaIds, List<int> marcaIds, int limit, DateTime? before = null)
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

            return await JsonSerializer.DeserializeAsync<IEnumerable<Producto>>(
                    await _httpClient.GetStreamAsync($"ListarPorFiltro/{limit}/{cursor}/{filtro}").ConfigureAwait(false),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                .ConfigureAwait(false);
        }
    }
}
