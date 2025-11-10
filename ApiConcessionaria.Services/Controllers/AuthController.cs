using ApiConcessionaria.Services.ExternalServices.Interfaces;
using ApiConcessionaria.Services.Requests.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiConcessionaria.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthExternalService _authService;

        public AuthController(IAuthExternalService authService)
        {
            _authService = authService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(UserCreateRequest request)
        {
            var result = await _authService.CreateUserAsync(request);
            return result is null ? BadRequest("Erro ao criar o usuário") : Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserAuthRequest request)
        {
            var result = await _authService.AuthenticateAsync(request);
            return result is null ? Unauthorized("Credenciais inválidas") : Ok(result);
        }
    }
}
