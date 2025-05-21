using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoObservacaoCFMap : IEntityTypeConfiguration<LinxMovimentoObservacaoCF>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoObservacaoCF> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoObservacaoCF));

            builder.ToTable("LinxMovimentoObservacaoCF");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.identificador);
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

            builder.Property(e => e.identificador)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.documento_cliente)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
