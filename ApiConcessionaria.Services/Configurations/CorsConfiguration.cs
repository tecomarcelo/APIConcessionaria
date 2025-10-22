namespace ApiConcessionaria.Services.Configurations
{
    /// <summary>
    /// classe de configuração do CORS no AspNet
    /// </summary>
    public class CorsConfiguration
    {
        public static void AddCors(WebApplicationBuilder builder)
        {
            builder.Services.AddCors(s => s.AddPolicy("DefaulPolicy",
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }));
        }

        public static void UseCors(WebApplication app)
        {
            app.UseCors("DefaultPolicy");
        }
    }
}
