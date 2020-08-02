using System;

namespace Sistema.Ecommerce.Services.Usuario
{
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Blazored.LocalStorage;
    using Microsoft.AspNetCore.Components.Authorization;
    using Sistema.Ecommerce.Providers;
    using Sistema.Shared.Entidades.Usuario;

    public class LoginDataService : ILoginDataService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public LoginDataService(HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorage)
        {
            this._httpClient = httpClient;
            this._authenticationStateProvider = authenticationStateProvider;
            this._localStorage = localStorage;
        }

        public async Task<bool> Login(ClienteLogin model)
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
            ((ApiAuthenticationStateProvider)this._authenticationStateProvider).MarkUserAsAuthenticated(model.Email);
            this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);

            return true;
        }

        public async Task Logout()
        {
            await this._localStorage.RemoveItemAsync("authToken").ConfigureAwait(false);
            ((ApiAuthenticationStateProvider)this._authenticationStateProvider).MarkUserAsLoggedOut();
            this._httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<bool> Registrar(ClienteRegister model)
        {
            var usuarioJson =
                new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await this._httpClient.PostAsync($"crear", usuarioJson).ConfigureAwait(false);

            usuarioJson.Dispose();

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
