using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxCsosnFiscalMap : IEntityTypeConfiguration<LinxCsosnFiscal>
    {
        public void Configure(EntityTypeBuilder<LinxCsosnFiscal> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxCsosnFiscal));

            builder.ToTable("LinxCsosnFiscal");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_csosn_fiscal);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_csosn_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.csosn_fiscal)
                .HasColumnType("varchar(5)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.id_csosn_fiscal_substitutiva)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
