using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoGiftCardTrustedMap : IEntityTypeConfiguration<LinxMovimentoGiftCard>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoGiftCard> builder)
        {
            builder.ToTable("LinxMovimentoGiftCard", "linx_microvix_erp");

            builder.HasKey(e => e.identificador_movimento);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.data_transacao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.operacao)
                .HasColumnType("int");

            builder.Property(e => e.nsu_cliente)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.nsu_host)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.valor)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.json_envio)
                .HasColumnType("varchar(max)");

            builder.Property(e => e.json_retorno)
                .HasColumnType("varchar(max)");

            builder.Property(e => e.qtde_tentativa)
                .HasColumnType("int");

            builder.Property(e => e.aprovado_barramento)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.estornada)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.codigo_loja)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.identificador_movimento)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.numero_cartao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.plano)
                .HasColumnType("int");

            builder.Property(e => e.ambiente_producao)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxMovimentoGiftCardRawMap : IEntityTypeConfiguration<LinxMovimentoGiftCard>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoGiftCard> builder)
        {
            builder.ToTable("LinxMovimentoGiftCard", "untreated");

            builder.HasKey(e => e.identificador_movimento);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.data_transacao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.operacao)
                .HasColumnType("int");

            builder.Property(e => e.nsu_cliente)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.nsu_host)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.valor)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.json_envio)
                .HasColumnType("varchar(max)");

            builder.Property(e => e.json_retorno)
                .HasColumnType("varchar(max)");

            builder.Property(e => e.qtde_tentativa)
                .HasColumnType("int");

            builder.Property(e => e.aprovado_barramento)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.estornada)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.codigo_loja)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.identificador_movimento)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.numero_cartao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.plano)
                .HasColumnType("int");

            builder.Property(e => e.ambiente_producao)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
