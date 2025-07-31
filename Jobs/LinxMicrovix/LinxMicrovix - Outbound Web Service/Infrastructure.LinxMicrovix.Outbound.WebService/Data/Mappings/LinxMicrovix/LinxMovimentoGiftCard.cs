using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoGiftCardMap : IEntityTypeConfiguration<LinxMovimentoGiftCard>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoGiftCard> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoGiftCard));

            builder.ToTable("LinxMovimentoGiftCard");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.identificador_movimento);
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

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.data_transacao)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.operacao)
                .HasColumnType("int");

            builder.Property(e => e.nsu_cliente)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.nsu_host)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.valor)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.json_envio)
                .HasProviderColumnType(EnumTableColumnType.Varchar_Max);

            builder.Property(e => e.json_retorno)
                .HasProviderColumnType(EnumTableColumnType.Varchar_Max);

            builder.Property(e => e.qtde_tentativa)
                .HasColumnType("int");

            builder.Property(e => e.aprovado_barramento)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.estornada)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.codigo_loja)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.identificador_movimento)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.numero_cartao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.plano)
                .HasColumnType("int");

            builder.Property(e => e.ambiente_producao)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
