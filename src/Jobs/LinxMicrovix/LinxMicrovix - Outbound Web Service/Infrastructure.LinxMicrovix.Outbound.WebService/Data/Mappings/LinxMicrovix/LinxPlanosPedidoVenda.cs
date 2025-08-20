using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxPlanosPedidoVendaMap : IEntityTypeConfiguration<LinxPlanosPedidoVenda>
    {
        public void Configure(EntityTypeBuilder<LinxPlanosPedidoVenda> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxPlanosPedidoVenda));

            builder.ToTable("LinxPlanosPedidoVenda");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.cod_pedido);
                builder.Ignore(x => x.id);
            }
            else
            {
                builder.HasKey(x => x.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

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
