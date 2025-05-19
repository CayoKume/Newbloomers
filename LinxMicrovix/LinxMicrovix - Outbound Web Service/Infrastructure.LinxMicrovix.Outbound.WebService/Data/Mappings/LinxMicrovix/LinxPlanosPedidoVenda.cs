using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxPlanosPedidoVendaMap : IEntityTypeConfiguration<LinxPlanosPedidoVenda>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxPlanosPedidoVenda> builder)
        {
            builder.ToTable("LinxPlanosPedidoVenda");

            builder.HasKey(e => e.cod_pedido);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.cod_pedido)
                .HasColumnType("int");

            builder.Property(e => e.plano)
                .HasColumnType("int");

            builder.Property(e => e.desc_plano)
                .HasColumnType("varchar(35)");

            builder.Property(e => e.total)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.qtde_parcelas)
                .HasColumnType("int");

            builder.Property(e => e.indice_plano)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_desc_acresc_plano)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cod_forma_pgto)
                .HasColumnType("int");

            builder.Property(e => e.forma_pgto)
                .HasColumnType("varchar(50)");
        }
    }
}
