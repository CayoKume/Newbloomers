using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxClasseFiscalMap : IEntityTypeConfiguration<LinxClasseFiscal>
    {
        public void Configure(EntityTypeBuilder<LinxClasseFiscal> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxClasseFiscal));

            builder.ToTable("LinxClasseFiscal");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_classe_fiscal);
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

            builder.Property(e => e.id_classe_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.excluido)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
