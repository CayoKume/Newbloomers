using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxSpedTipoBaseCreditoMap : IEntityTypeConfiguration<LinxSpedTipoBaseCredito>
    {
        public void Configure(EntityTypeBuilder<LinxSpedTipoBaseCredito> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxSpedTipoBaseCredito));

            builder.ToTable("LinxSpedTipoBaseCredito");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_sped_tipo_base_credito);
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

            builder.Property(e => e.id_sped_tipo_base_credito)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.codigo_sped_tipo_base_credito)
                .HasColumnType("varchar(2)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
