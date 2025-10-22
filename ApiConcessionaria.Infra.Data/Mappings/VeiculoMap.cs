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
    /// <summary>
    /// Classe de mapamento ORM para entidade Veiculos
    /// </summary>
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("VEICULO");

            builder.HasKey(v => v.IdVeiculo);

            builder.Property(v => v.IdVeiculo)
                .HasColumnName("IDVEICULO")
                .IsRequired();

            builder.Property(v => v.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(v => v.Marca)
                .HasColumnName("MARCA")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(v => v.Preco)
                .HasColumnName("PRECO")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(v => v.AnoVeiculo)
                .HasColumnName("ANOVEICULO")
                .IsRequired();

            builder.Property(v => v.DataCriacao)
                .HasColumnName("DATACRIACAO")
                .IsRequired();

            builder.Property(v => v.DataAlteracao)
                .HasColumnName("DATAALTERACAO")
                .IsRequired();
        }
    }
}
