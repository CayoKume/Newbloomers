using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxOticoPrismaDescricaoMap : IEntityTypeConfiguration<LinxOticoPrismaDescricao>
    {
        public void Configure(EntityTypeBuilder<LinxOticoPrismaDescricao> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxOticoPrismaDescricao));

            builder.ToTable("LinxOticoPrismaDescricao");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_otico_prisma_descricao);
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

            builder.Property(e => e.id_otico_prisma_descricao)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
