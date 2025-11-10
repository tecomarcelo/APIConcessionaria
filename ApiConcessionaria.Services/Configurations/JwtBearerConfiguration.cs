using ApiConcessionaria.Services.ExternalServices.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;


using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiConcessionaria.Services.Configurations
{
    public class JwtBearerConfiguration
    {
        public static void AddJwtConfiguration(WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            var services = builder.Services;

            var settings = "JwtBearerSettings";

            var issuer = configuration.GetSection($"{settings}:Issuer").Value;
            var audience = configuration.GetSection($"{settings}:Audience").Value;
            var secretKey = configuration.GetSection($"{settings}:SecretKey").Value;
            var expirationInMinutes = int.Parse(configuration.GetSection($"{settings}:ExpirationInMinutes").Value);

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });

            services.Configure<JwtBearerSettings>(configuration.GetSection(settings));
        }
    }
}
