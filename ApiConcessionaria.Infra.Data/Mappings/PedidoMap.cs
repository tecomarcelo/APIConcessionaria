using ApiConcessionaria.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConcessionaria.Infra.Data.Mappings
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("PEDIDO");

            builder.HasKey(p => p.IdPedido);

            builder.Property(p => p.IdPedido)
                .HasColumnName("IDPEDIDO")
                .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnName("VALOR")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .HasColumnName("QUANTIDADE")
                .IsRequired();

            builder.Property(p => p.DataCriacao)
                .HasColumnName("DATACRIACAO")
                .IsRequired();

            builder.Property(p => p.DataAlteracao)
                .HasColumnName("DATAALTERACAO")
                .IsRequired();


            #region Mapeamento de relacionamento 1 para muitos

            builder.HasOne(p => p.Cliente) //Pedido TEM 1 Cliente
                .WithMany(c => c.Pedidos) //Cliente TEM MUITOS Pedidos
                .HasForeignKey(p => p.IdCliente); //chave estrangeira

            builder.HasOne(p => p.Veiculo)
                .WithMany(v => v.Pedidos)
                .HasForeignKey(p => p.IdVeiculo);

            builder.HasOne(p => p.Opcional)
                .WithMany(o => o.Pedidos)
                .HasForeignKey(p => p.IdOpcional);

            #endregion
        }
    }
}
