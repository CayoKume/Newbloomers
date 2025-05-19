using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoReshopItensMap : IEntityTypeConfiguration<LinxMovimentoReshopItens>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxMovimentoReshopItens> builder)
        {
            builder.ToTable("LinxMovimentoReshopItens");

            builder.HasKey(e => e.id_movimento_campanha_reshop_item);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_movimento_campanha_reshop_item)
                .HasColumnType("int");

            builder.Property(e => e.id_campanha)
                .HasColumnType("int");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.valor_unitario)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_desconto_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.quantidade)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_original)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.ordem)
                .HasColumnType("int");
        }
    }
}
