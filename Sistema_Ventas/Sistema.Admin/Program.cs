namespace Sistema.Admin
{
    using System;
    using System.Threading.Tasks;
    using Blazored.LocalStorage;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Sistema.Shared.Helpers.General;
    using Sistema.Shared.Helpers.Producto;
    using Sistema.Shared.Providers;
    using Sistema.Shared.Services.Almacen.Categoria;
    using Sistema.Shared.Services.Almacen.ProductoFoto;
    using Sistema.Shared.Services.Almacen.Marca;
    using Sistema.Shared.Services.Almacen.Producto;
    using Sistema.Shared.Services.Ordenes.Carrito;
    using Sistema.Shared.Services.Ordenes.Orden;
    using Sistema.Shared.Services.Ordenes.Pago;
    using Sistema.Shared.Services.Ordenes.Pedido;
    using Sistema.Shared.Services.Usuario.Administrador;
    using Sistema.Shared.Services.Usuario.Rol;

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
            builder.Services.AddHttpClient<IAdminDataService, AdminDataService>(client =>
                client.BaseAddress = new Uri(baseAddress + "/administradores/"));

            builder.Services.AddHttpClient<IRolDataService, RolDataService>(client =>
                client.BaseAddress = new Uri(baseAddress + "/roles/"));

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

            builder.Services.AddHttpClient<IProductoFotoDataService, ProductoFotoDataService>(client =>
                client.BaseAddress = new Uri(baseAddress + "/productoFotos/"));

            // Helper Classes //
            builder.Services.AddSingleton<IStringHelper, StringHelper>();
            builder.Services.AddSingleton<IProductoHelper, ProductoHelper>();

            await builder.Build().RunAsync().ConfigureAwait(false);
        }
    }
}
