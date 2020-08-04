using System.Collections.Generic;

namespace Sistema.Shared.Services.Usuario.Administrador
{
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Blazored.LocalStorage;
    using Microsoft.AspNetCore.Components.Authorization;
    using Sistema.Shared.Entidades.Usuario.Administrador;
    using Sistema.Shared.Providers;

    public class AdminDataService : IAdminDataService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AdminDataService(HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorage)
        {
            this._httpClient = httpClient;
            this._authenticationStateProvider = authenticationStateProvider;
            this._localStorage = localStorage;
        }

        public async Task<bool> Login(AdminLogin model)
        {
            if (model == null)
            {
                return false;
            }

            var loginJson = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await this._httpClient.PostAsync($"login", loginJson).ConfigureAwait(false);

            var loginResult = await JsonSerializer.DeserializeAsync<LoginResult>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).ConfigureAwait(false);

            loginJson.Dispose();

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            await this._localStorage.SetItemAsync("authToken", loginResult.Token).ConfigureAwait(false);
            ((ApiAuthenticationStateProvider)this._authenticationStateProvider).MarkUserAsAuthenticated(model.Usuario);
            this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);

            return true;
        }

        public async Task Logout()
        {
            await this._localStorage.RemoveItemAsync("authToken").ConfigureAwait(false);
            ((ApiAuthenticationStateProvider)this._authenticationStateProvider).MarkUserAsLoggedOut();
            this._httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public Task<IEnumerable<AdministradorViewModel>> Listar()
        {
            throw new System.NotImplementedException();
        }

        public Task<AdministradorViewModel> Mostrar(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Activar(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Desactivar(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Actualizar(ActualizarViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Crear(CrearViewModel model)
        {
            var modelJson =
                new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await this._httpClient.PostAsync($"crear", modelJson).ConfigureAwait(false);

            modelJson.Dispose();

            if (response.StatusCode == HttpStatusCode.Created)
            {
                return true;
            }

            return false;
        }
    }

    public class LoginResult
    {
        public string Token { get; set; }
    }
}
