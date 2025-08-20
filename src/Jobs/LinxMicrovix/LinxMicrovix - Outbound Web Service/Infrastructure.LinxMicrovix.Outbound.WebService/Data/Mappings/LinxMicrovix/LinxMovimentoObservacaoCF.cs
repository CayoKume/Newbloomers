using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoObservacaoCFMap : IEntityTypeConfiguration<LinxMovimentoObservacaoCF>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoObservacaoCF> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoObservacaoCF));

            builder.ToTable("LinxMovimentoObservacaoCF");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.identificador);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.identificador)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.documento_cliente)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
