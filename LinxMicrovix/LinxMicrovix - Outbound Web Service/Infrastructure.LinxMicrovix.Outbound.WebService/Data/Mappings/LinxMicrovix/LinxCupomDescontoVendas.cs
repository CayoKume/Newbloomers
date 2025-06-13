using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxCupomDescontoVendasMap : IEntityTypeConfiguration<LinxCupomDescontoVendas>
    {
        public void Configure(EntityTypeBuilder<LinxCupomDescontoVendas> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxCupomDescontoVendas));

            builder.ToTable("LinxCupomDescontoVendas");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_cupom_desconto_vendas);
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

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.id_cupom_desconto_vendas)
                .HasColumnType("int");

            builder.Property(e => e.id_cupom_desconto)
                .HasColumnType("int");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.valor)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
