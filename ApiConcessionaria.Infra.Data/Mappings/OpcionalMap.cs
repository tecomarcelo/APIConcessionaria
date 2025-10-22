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
    public class OpcionalMap : IEntityTypeConfiguration<Opcional>
    {
        public void Configure(EntityTypeBuilder<Opcional> builder)
        {
            builder.ToTable("OPCIONAL");

            builder.HasKey(o => o.IdOpcional);

            builder.Property(o => o.IdOpcional)
                .HasColumnName("IDOPCIONAL")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(o => o.Item)
                .HasColumnName("ITEM")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(o => o.Preco)
                .HasColumnName("PRECO")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            #region Mapeamento de relacionamento 1 para muitos

            builder.HasOne(p => p.Veiculo) //Opcional TEM 1 Veiculo
                .WithMany(c => c.Opcionais) //Veiculo TEM MUITOS Opcionais
                .HasForeignKey(p => p.IdVeiculo); //chave estrangeira

            #endregion
        }
    }
}
