using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxCstPisFiscalMap : IEntityTypeConfiguration<LinxCstPisFiscal>
    {
        public void Configure(EntityTypeBuilder<LinxCstPisFiscal> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxCstPisFiscal));

            builder.ToTable("LinxCstPisFiscal");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_cst_pis_fiscal);
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

            builder.Property(e => e.id_cst_pis_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.cst_pis_fiscal)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.excluido)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.inicio_vigencia)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.termino_vigencia)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
