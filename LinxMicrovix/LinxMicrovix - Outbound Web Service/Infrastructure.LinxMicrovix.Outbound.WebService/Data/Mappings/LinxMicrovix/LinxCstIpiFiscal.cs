using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxCstIpiFiscalMap : IEntityTypeConfiguration<LinxCstIpiFiscal>
    {
        public void Configure(EntityTypeBuilder<LinxCstIpiFiscal> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxCstIpiFiscal));

            builder.ToTable("LinxCstIpiFiscal");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_cst_ipi_fiscal);
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

            builder.Property(e => e.id_cst_ipi_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.cst_ipi_fiscal)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.excluido)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.inicio_vigencia)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.termino_vigencia)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.cst_ipi_fiscal_inverso)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
