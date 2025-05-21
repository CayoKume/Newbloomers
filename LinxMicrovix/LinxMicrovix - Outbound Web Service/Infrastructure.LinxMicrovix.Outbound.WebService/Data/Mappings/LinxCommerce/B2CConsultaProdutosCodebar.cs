using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosCodebarMap : IEntityTypeConfiguration<B2CConsultaProdutosCodebar>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCodebar> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaProdutosCodebar));

            builder.ToTable("B2CConsultaProdutosCodebar");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => new { e.codigoproduto, e.id_produtos_codebar });
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

            builder.Property(e => e.codebar)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.id_produtos_codebar)
                .HasColumnType("int");

            builder.Property(e => e.principal)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.tipo_codebar)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
