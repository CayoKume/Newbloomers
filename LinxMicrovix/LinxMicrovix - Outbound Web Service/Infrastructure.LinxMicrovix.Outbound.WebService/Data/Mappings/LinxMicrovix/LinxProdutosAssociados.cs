using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosAssociadosMap : IEntityTypeConfiguration<LinxProdutosAssociados>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosAssociados> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxProdutosAssociados));

            builder.ToTable("LinxProdutosAssociados");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.codigoproduto_associado);
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

            builder.Property(e => e.codigoproduto_associado)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto_origem)
                .HasColumnType("bigint");

            builder.Property(e => e.coeficiente_desconto)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.qtde_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.item_obrigatorio)
                .HasProviderColumnType(EnumTableColumnType.Bool);
        }
    }
}
