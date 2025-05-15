using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoReshopTrustedMap : IEntityTypeConfiguration<LinxMovimentoReshop>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoReshop> builder)
        {
            builder.ToTable("LinxMovimentoReshop", "linx_microvix_erp");

            builder.HasKey(e => e.identificador);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_movimento_campanha_reshop)
                .HasColumnType("int");

            builder.Property(e => e.id_campanha)
                .HasColumnType("int");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.nome)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.aplicar_desconto_venda)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.valor_desconto_subtotal)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_desconto_completo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxMovimentoReshopRawMap : IEntityTypeConfiguration<LinxMovimentoReshop>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoReshop> builder)
        {
            builder.ToTable("LinxMovimentoReshop", "untreated");

            builder.HasKey(e => e.identificador);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_movimento_campanha_reshop)
                .HasColumnType("int");

            builder.Property(e => e.id_campanha)
                .HasColumnType("int");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.nome)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.aplicar_desconto_venda)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.valor_desconto_subtotal)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_desconto_completo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
