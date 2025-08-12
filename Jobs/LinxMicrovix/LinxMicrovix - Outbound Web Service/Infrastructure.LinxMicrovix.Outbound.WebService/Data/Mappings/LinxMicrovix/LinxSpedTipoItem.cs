using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxSpedTipoItemMap : IEntityTypeConfiguration<LinxSpedTipoItem>
    {
        public void Configure(EntityTypeBuilder<LinxSpedTipoItem> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxSpedTipoItem));

            builder.ToTable("LinxSpedTipoItem");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_sped_tipo_item);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_sped_tipo_item)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.codigo)
                .HasColumnType("varchar(2)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
