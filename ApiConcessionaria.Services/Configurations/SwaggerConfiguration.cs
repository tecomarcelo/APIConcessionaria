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
            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
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
            });
        }
    }
}
