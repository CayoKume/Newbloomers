using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxCfopFiscalMap : IEntityTypeConfiguration<LinxCfopFiscal>
    {
        public void Configure(EntityTypeBuilder<LinxCfopFiscal> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxCfopFiscal));

            builder.ToTable("LinxCfopFiscal");

            if (schema == "linx_microvix_erp")
            { 
                builder.HasKey(e => e.id_cfop_fiscal);
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

            builder.Property(e => e.id_cfop_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.cfop_fiscal)
                .HasColumnType("varchar(5)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(300)");

            builder.Property(e => e.excluido)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
