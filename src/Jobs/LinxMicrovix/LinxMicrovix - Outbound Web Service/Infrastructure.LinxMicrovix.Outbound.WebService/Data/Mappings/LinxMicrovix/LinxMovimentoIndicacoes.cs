using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Infrastructure.Core.Data.Schemas;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoIndicacoesMap : IEntityTypeConfiguration<LinxMovimentoIndicacoes>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoIndicacoes> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoIndicacoes));

            builder.ToTable("LinxMovimentoIndicacoes");

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

            builder.Property(e => e.cod_cliente)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
