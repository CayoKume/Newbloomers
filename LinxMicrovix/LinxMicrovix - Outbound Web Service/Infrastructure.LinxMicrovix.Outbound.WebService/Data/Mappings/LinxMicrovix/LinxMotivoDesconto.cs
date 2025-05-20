using Infrastructure.LinxMicrovix.Outbound.WebService.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMotivoDescontoMap : IEntityTypeConfiguration<LinxMotivoDesconto>
    {
        public void Configure(EntityTypeBuilder<LinxMotivoDesconto> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMotivoDesconto));

            builder.ToTable("LinxMotivoDesconto");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_motivo_desconto);
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

            builder.Property(e => e.id_motivo_desconto)
                .HasColumnType("int");

            builder.Property(e => e.desc_motivo_desconto)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.excluido)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
