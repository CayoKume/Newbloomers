using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxTrocaUnificadaResumoVendasItensMap : IEntityTypeConfiguration<LinxTrocaUnificadaResumoVendasItens>
    {
        public void Configure(EntityTypeBuilder<LinxTrocaUnificadaResumoVendasItens> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxTrocaUnificadaResumoVendasItens));

            builder.ToTable("LinxTrocaUnificadaResumoVendasItens");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_troca_unificada_resumo_vendas_itens);
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

            builder.Property(e => e.id_troca_unificada_resumo_vendas_itens)
                .HasColumnType("bigint");

            builder.Property(e => e.id_troca_unificada_resumo_vendas)
                .HasColumnType("bigint");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.transacao)
                .HasColumnType("int");

            builder.Property(e => e.serial)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.valor_liquido)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.data_validade)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.venda_referenciada)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.token_utilizado)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.quantidade)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
