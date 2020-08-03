<<<<<<< HEAD
namespace Sistema.Ecommerce
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Sistema.Ecommerce.Helpers;
    using Sistema.Ecommerce.Services;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            var baseAddress = "https://localhost:44303/api";

            builder.Services.AddHttpClient<IProductoDataService, ProductoDataService>(client =>
                client.BaseAddress = new Uri(baseAddress + "/productos/"));

            builder.Services.AddHttpClient<ICategoriaDataService, CategoriaDataService>(client =>
                client.BaseAddress = new Uri(baseAddress + "/categorias/"));

            builder.Services.AddHttpClient<IMarcaDataService, MarcaDataService>(client =>
                client.BaseAddress = new Uri(baseAddress + "/marcas/"));

            builder.Services.AddSingleton<IProductoHelper, ProductoHelper>();

            await builder.Build().RunAsync();
        }
    }
}
=======
namespace Sistema.Ecommerce
{
    using System;
    using System.Threading.Tasks;
    using Blazored.LocalStorage;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Sistema.Ecommerce.Helpers;
    using Sistema.Ecommerce.Providers;
    using Sistema.Ecommerce.Services.Almacen;
    using Sistema.Ecommerce.Services.Ordenes;
    using Sistema.Ecommerce.Services.Usuario;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            var baseAddress = "https://localhost:44303/api";

            // Authorization Services //
            builder.Services.AddAuthorizationCore();
            builder.Services.AddHttpClient<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

            // Local Storage Handler
            builder.Services.AddBlazoredLocalStorage();

            // Http Client Providers //
            builder.Services.AddHttpClient<ILoginDataService, LoginDataService>(client =>
                client.BaseAddress = new Uri(baseAddress + "/clientes/"));


            builder.Services.AddHttpClient<IProductoDataService, ProductoDataService>(client =>
                client.BaseAddress = new Uri(baseAddress + "/productos/"));

            builder.Services.AddHttpClient<ICategoriaDataService, CategoriaDataService>(client =>
                client.BaseAddress = new Uri(baseAddress + "/categorias/"));

            builder.Services.AddHttpClient<IMarcaDataService, MarcaDataService>(client =>
                client.BaseAddress = new Uri(baseAddress + "/marcas/"));

            builder.Services.AddHttpClient<ICarritoDataService, CarritoDataService>(client =>
                client.BaseAddress = new Uri(baseAddress + "/carritos/"));

            builder.Services.AddHttpClient<IOrdenDataService, OrdenDataService>(client =>
                client.BaseAddress = new Uri(baseAddress + "/ordenes/"));

            builder.Services.AddHttpClient<IPedidoDataService, PedidoDataService>(client =>
                client.BaseAddress = new Uri(baseAddress + "/pedidos/"));

            builder.Services.AddHttpClient<IPagoDataService, PagoDataService>(client =>
                client.BaseAddress = new Uri(baseAddress + "/pagos/"));

            // Helper Classes //
            builder.Services.AddSingleton<IProductoHelper, ProductoHelper>();

            await builder.Build().RunAsync().ConfigureAwait(false);
        }
    }
}
>>>>>>> master
