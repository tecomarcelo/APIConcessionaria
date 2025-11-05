using ApiConcessionaria.Infra.Data.Contexts;
using ApiConcessionaria.Infra.Data.Interfaces;
using ApiConcessionaria.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiConcessionaria.Services.Configurations
{
    /// <summary>
    /// Classe de configuração do EntityFramework no AspNet
    /// </summary>
    public class EntityFrameworkConfiguration
    {
        public static void AddEntityFramework(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("ApiConcessionaria");

            builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
            builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
            builder.Services.AddTransient<IVeiculoRepository, VeiculoRepository>();
            builder.Services.AddTransient<IOpcionalRepository, OpcionalRepository>();
            builder.Services.AddTransient<IPedidoOpcionalRepository, PedidoOpcionalRepository>();
        }
    }
}
