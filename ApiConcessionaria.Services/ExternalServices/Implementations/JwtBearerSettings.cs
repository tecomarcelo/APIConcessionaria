namespace ApiConcessionaria.Services.ExternalServices.Implementations
{
    public class JwtBearerSettings
    {
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
        public int ExpirationInMinutes { get; set; }
    }
}
