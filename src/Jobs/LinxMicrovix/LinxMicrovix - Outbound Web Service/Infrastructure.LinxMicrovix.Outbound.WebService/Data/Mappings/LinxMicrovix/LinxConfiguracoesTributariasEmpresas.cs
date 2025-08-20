using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxConfiguracoesTributariasEmpresasMap : IEntityTypeConfiguration<LinxConfiguracoesTributariasEmpresas>
    {
        public void Configure(EntityTypeBuilder<LinxConfiguracoesTributariasEmpresas> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxConfiguracoesTributariasEmpresas));

            builder.ToTable("LinxConfiguracoesTributariasEmpresas");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_config_tributaria);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_config_tributaria)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
