using ApiConcessionaria.Infra.Data.Entities;
using ApiConcessionaria.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConcessionaria.Infra.Data.Contexts
{
    /// <summary>
    /// Classe para acesso ao banco de dados com o EntityFramework
    /// </summary>
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }

        //declara uma propriedade DbSet para cada entidade
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Opcional> Opcionals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adicionando as classes de mapeamento
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new VeiculoMap());
            modelBuilder.ApplyConfiguration(new OpcionalMap());

        }
    }
}
