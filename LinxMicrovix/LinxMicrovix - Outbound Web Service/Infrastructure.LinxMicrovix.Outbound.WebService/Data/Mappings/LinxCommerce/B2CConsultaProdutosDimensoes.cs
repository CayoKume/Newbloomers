using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosDimensoesMap : IEntityTypeConfiguration<B2CConsultaProdutosDimensoes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosDimensoes> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaProdutosDimensoes));

            builder.ToTable("B2CConsultaProdutosDimensoes");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.codigoproduto);
                builder.Ignore(e => e.id);
            }
            else
            {
                builder.HasKey(e => e.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }
            
            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.altura)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.comprimento)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.largura)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
