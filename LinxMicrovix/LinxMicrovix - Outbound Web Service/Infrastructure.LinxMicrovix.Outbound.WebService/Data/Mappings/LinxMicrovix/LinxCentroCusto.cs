using Infrastructure.LinxMicrovix.Outbound.WebService.Schema;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxCentroCustoMap : IEntityTypeConfiguration<LinxCentroCusto>
    {
        public void Configure(EntityTypeBuilder<LinxCentroCusto> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxCentroCusto));

            builder.ToTable("LinxCentroCusto");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => new { e.id_centrocusto });
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
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.CNPJ)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.id_centrocusto)
                .HasColumnType("int");

            builder.Property(e => e.nome_centrocusto)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
