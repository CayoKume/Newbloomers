using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxNfseMap : IEntityTypeConfiguration<LinxNfse>
    {
        public void Configure(EntityTypeBuilder<LinxNfse> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxNfse));

            builder.ToTable("LinxNfse");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_nfse);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_nfse)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.documento)
                .HasColumnType("int");

            builder.Property(e => e.codigo_verificacao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.id_nfse_situacao)
                .HasColumnType("int");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.dt_insert)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
