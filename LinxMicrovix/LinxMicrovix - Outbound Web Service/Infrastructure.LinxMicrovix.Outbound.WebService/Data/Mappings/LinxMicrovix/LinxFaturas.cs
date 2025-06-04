using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxFaturasMap : IEntityTypeConfiguration<LinxFaturas>
    {
        public void Configure(EntityTypeBuilder<LinxFaturas> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxFaturas));

            builder.ToTable("LinxFaturas");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.codigo_fatura);
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

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.codigo_fatura)
                .HasColumnType("bigint");

            builder.Property(e => e.data_emissao)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.cod_cliente)
                .HasColumnType("int");

            builder.Property(e => e.nome_cliente)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.data_vencimento)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.data_baixa)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.valor_fatura)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_pago)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_desconto)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_juros)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.documento)
                .HasColumnType("int");

            builder.Property(e => e.serie)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.ecf)
                .HasColumnType("int");

            builder.Property(e => e.observacao)
                .HasColumnType("text");

            builder.Property(e => e.qtde_parcelas)
                .HasColumnType("int");

            builder.Property(e => e.ordem_parcela)
                .HasColumnType("int");

            builder.Property(e => e.receber_pagar)
                .HasColumnType("char(1)");

            builder.Property(e => e.vendedor)
                .HasColumnType("int");

            builder.Property(e => e.excluido)
                .HasColumnType("char(1)");

            builder.Property(e => e.cancelado)
                .HasColumnType("char(1)");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.nsu)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.cod_autorizacao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.documento_sem_tef)
                .HasColumnType("varchar(350)");

            builder.Property(e => e.autorizacao_sem_tef)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.plano)
                .HasColumnType("int");

            builder.Property(e => e.conta_credito)
                .HasColumnType("bigint");

            builder.Property(e => e.conta_debito)
                .HasColumnType("bigint");

            builder.Property(e => e.conta_fluxo)
                .HasColumnType("bigint");

            builder.Property(e => e.cod_historico)
                .HasColumnType("bigint");

            builder.Property(e => e.forma_pgto)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.ordem_cartao)
                .HasColumnType("int");

            builder.Property(e => e.banco_codigo)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.banco_agencia)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.banco_conta)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.banco_autorizacao_garantidora)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.numero_bilhete_seguro)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.id_categorias_financeiras)
                .HasColumnType("int");

            builder.Property(e => e.taxa_financeira)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_abatimento)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_multa)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.centrocusto)
                .HasColumnType("int");

            builder.Property(e => e.perc_taxa_adquirente)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.fatura_origem_importacao_erp)
                .HasColumnType("varchar(50)");
        }
    }
}
