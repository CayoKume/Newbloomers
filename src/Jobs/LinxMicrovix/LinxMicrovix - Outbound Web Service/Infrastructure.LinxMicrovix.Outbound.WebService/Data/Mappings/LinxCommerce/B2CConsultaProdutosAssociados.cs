using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosAssociadosMap : IEntityTypeConfiguration<B2CConsultaProdutosAssociados>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosAssociados> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaProdutosAssociados));

            builder.ToTable("B2CConsultaProdutosAssociados");

            if (schema == "linx_microvix_commerce")
                builder.HasKey(e => new { e.id, e.codigoproduto, e.codigoproduto_associado });
            
            
            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.codigoproduto_associado)
                .HasColumnType("bigint");

            builder.Property(e => e.coeficiente_desconto)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.qtde_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.item_obrigatorio)
                .HasProviderColumnType(EnumTableColumnType.Bool);
        }
    }
}
