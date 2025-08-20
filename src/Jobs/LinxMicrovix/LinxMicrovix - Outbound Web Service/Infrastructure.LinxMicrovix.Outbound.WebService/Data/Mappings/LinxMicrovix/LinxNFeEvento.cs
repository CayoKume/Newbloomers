using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxNFeEventoMap : IEntityTypeConfiguration<LinxNFeEvento>
    {
        public void Configure(EntityTypeBuilder<LinxNFeEvento> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxNFeEvento));

            builder.ToTable("LinxNFeEvento");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_nfe_evento);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.id_nfe_evento)
                .HasColumnType("int");

            builder.Property(e => e.id_nfe)
                .HasColumnType("int");

            builder.Property(e => e.codigo_tipo)
                .HasColumnType("varchar(6)");

            builder.Property(e => e.xml)
                .HasProviderColumnType(EnumTableColumnType.Varchar_Max);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.data_emissao)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.hora_emissao)
                .HasColumnType("char(5)");
        }
    }
}
