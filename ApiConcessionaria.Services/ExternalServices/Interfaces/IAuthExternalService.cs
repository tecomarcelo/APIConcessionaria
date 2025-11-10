using ApiConcessionaria.Services.Requests.Auth;
using ApiConcessionaria.Services.Responses.Auth;

namespace ApiConcessionaria.Services.ExternalServices.Interfaces
{
    public interface IAuthExternalService
    {
        Task<UserCreateResponse?> CreateUserAsync(UserCreateRequest request);
        Task<UserAuthResponse?> AuthenticateAsync(UserAuthRequest request);
    }
}
