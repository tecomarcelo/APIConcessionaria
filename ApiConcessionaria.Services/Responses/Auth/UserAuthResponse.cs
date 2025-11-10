using System.Reflection.Metadata.Ecma335;

namespace ApiConcessionaria.Services.Responses.Auth
{
    public class UserAuthResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
