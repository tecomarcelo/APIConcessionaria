using ApiConcessionaria.Services.ExternalServices.Interfaces;
using ApiConcessionaria.Services.Requests.Auth;
using ApiConcessionaria.Services.Responses.Auth;

namespace ApiConcessionaria.Services.ExternalServices.Implementations
{
    public class AuthExternalService : IAuthExternalService
    {
        private readonly HttpClient _httpClient;

        public AuthExternalService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;

            // BaseAddress vem do appsettings.json
            var baseUrl = config["ExternalApis:TasksApi"];
            _httpClient.BaseAddress = new Uri(baseUrl!);
        }

        public async Task<UserCreateResponse?> CreateUserAsync(UserCreateRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/users/create", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserCreateResponse>();
        }

        public async Task<UserAuthResponse?> AuthenticateAsync(UserAuthRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/users/auth", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserAuthResponse>();
        }
    }
}
