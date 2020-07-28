<<<<<<< HEAD
using System.Net.Http.Headers;

namespace Sistema.Ecommerce
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Sistema.Ecommerce.Services;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            var baseAddress = "https://localhost:44303/";

            builder.Services.AddHttpClient<IProductoDataService, ProductoDataService>(client =>
                client.BaseAddress = new Uri(baseAddress));
            

            await builder.Build().RunAsync();
        }
    }
}
=======
namespace Sistema.Ecommerce
{
    using System;
    using System.Net.Http.Headers;
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

            var baseAddress = "https://localhost:44303/api/";

            builder.Services.AddHttpClient<IProductoDataService, ProductoDataService>(client =>
                client.BaseAddress = new Uri(baseAddress + "productos"));

            builder.Services.AddHttpClient<ICategoriaDataService, CategoriaDataService>(client =>
                client.BaseAddress = new Uri(baseAddress + "categorias"));

            builder.Services.AddSingleton<IProductoHelper, ProductoHelper>();

            await builder.Build().RunAsync();
        }
    }
}
>>>>>>> master
