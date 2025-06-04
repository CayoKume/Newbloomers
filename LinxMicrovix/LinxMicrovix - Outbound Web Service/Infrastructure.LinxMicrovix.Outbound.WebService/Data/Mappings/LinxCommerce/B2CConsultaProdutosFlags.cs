using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosFlagsMap : IEntityTypeConfiguration<B2CConsultaProdutosFlags>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosFlags> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaProdutosFlags));

            builder.ToTable("B2CConsultaProdutosFlags");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.id_b2c_flags_produtos);
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

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_b2c_flags_produtos)
                .HasColumnType("int");

            builder.Property(e => e.id_b2c_flags)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.descricao_b2c_flags)
                .HasColumnType("varchar(300)");
        }
    }
}
