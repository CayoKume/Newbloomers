using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosStatusMap : IEntityTypeConfiguration<B2CConsultaProdutosStatus>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosStatus> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaProdutosStatus));

            builder.ToTable("B2CConsultaProdutosStatus");

            if (schema == "linx_microvix_commerce")
                builder.HasKey(e => e.codigoproduto);
            
                
            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.referencia)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.b2c)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
