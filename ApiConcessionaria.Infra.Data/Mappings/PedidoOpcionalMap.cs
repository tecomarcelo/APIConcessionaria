using ApiConcessionaria.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiConcessionaria.Infra.Data.Mappings
{
    public class PedidoOpcionalMap : IEntityTypeConfiguration<PedidoOpcional>
    {
        public void Configure(EntityTypeBuilder<PedidoOpcional> builder)
        {
            builder.ToTable("PEDIDO_OPCIONAL");

            builder.HasKey(po => new { po.IdPedido, po.IdOpcional });

            builder.HasOne(po => po.Pedido)
                .WithMany(p => p.PedidoOpcionais)
                .HasForeignKey(po => po.IdPedido);

            builder.HasOne(po => po.Opcional)
                .WithMany(o => o.PedidoOpcionais)
                .HasForeignKey(po => po.IdOpcional);
        }

    }
}
