using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoVendaConjugadaMap : IEntityTypeConfiguration<LinxMovimentoVendaConjugada>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoVendaConjugada> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoVendaConjugada));

            builder.ToTable("LinxMovimentoVendaConjugada");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.identificador_produto);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.identificador_produto)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.identificador_servico)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
