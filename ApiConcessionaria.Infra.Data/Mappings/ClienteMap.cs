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
    internal class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTE");

            builder.HasKey(c => c.IdCliente);

            builder.Property(c => c.IdCliente)
                .HasColumnName("IDCLIENTE")
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Cpf)
                .HasColumnName("CPF")
                .IsRequired();

            builder.Property(c => c.DataCriacao)
                .HasColumnName("DATACRIACAO")
                .IsRequired();

            builder.Property(c => c.DataAlteracao)
                .HasColumnName("DATAALTERACAO")
                .IsRequired();


            #region Mapeamento de campos únicos

            builder.HasIndex(c => c.Cpf)
                .IsUnique();

            #endregion
        }

    }
}
