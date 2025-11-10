using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace ApiConcessionaria.Services.Configurations
{
    /// <summary>
    /// Classe de configuração do Swagger
    /// </summary>
    public class SwaggerConfiguration
    {
        public static void AddSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "API para controle de Veiculos",
                    Description = "Projeto desenvolvido em NET6 API EntityFramework SqlServer",
                    Contact = new OpenApiContact
                    {
                        Name = "Concessionário de Veiculos CARs",
                        Url = new Uri("http://www.cars.com.br"),
                        Email = "contato@cars.com.br"
                    }
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}
