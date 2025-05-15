using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoTrustedMap : IEntityTypeConfiguration<LinxMovimento>
    {
        public void Configure(EntityTypeBuilder<LinxMovimento> builder)
        {
            builder.ToTable("LinxMovimento", "linx_microvix_erp");

    builder.HasKey(e => new { 
        e.cnpj_emp, 
        e.documento, 
        e.chave_nf, 
        e.data_documento, 
        e.codigo_cliente, 
        e.cod_produto, 
        e.cancelado, 
        e.excluido, 
        e.transacao_pedido_venda, 
        e.ordem 
    });

    builder.Property(e => e.lastupdateon)
        .HasProviderColumnType(LogicalColumnType.DateTime);

    builder.Property(e => e.portal)
        .HasColumnType("int");

    builder.Property(e => e.cnpj_emp)
        .HasColumnType("varchar(14)");

    builder.Property(e => e.transacao)
        .HasColumnType("int");

    builder.Property(e => e.usuario)
        .HasColumnType("int");

    builder.Property(e => e.documento)
        .HasColumnType("int");

    builder.Property(e => e.chave_nf)
        .HasColumnType("varchar(44)");

    builder.Property(e => e.ecf)
        .HasColumnType("int");

    builder.Property(e => e.numero_serie_ecf)
        .HasColumnType("varchar(30)");

    builder.Property(e => e.modelo_nf)
        .HasColumnType("int");

    builder.Property(e => e.data_documento)
        .HasProviderColumnType(LogicalColumnType.DateTime);

    builder.Property(e => e.data_lancamento)
        .HasProviderColumnType(LogicalColumnType.DateTime);

    builder.Property(e => e.codigo_cliente)
        .HasColumnType("int");

    builder.Property(e => e.serie)
        .HasColumnType("varchar(10)");

    builder.Property(e => e.desc_cfop)
        .HasColumnType("varchar(300)");

    builder.Property(e => e.id_cfop)
        .HasColumnType("varchar(5)");

    builder.Property(e => e.cod_vendedor)
        .HasColumnType("int");

    builder.Property(e => e.quantidade)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.preco_custo)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.valor_liquido)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.desconto)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.cst_icms)
        .HasColumnType("varchar(4)");

    builder.Property(e => e.cst_pis)
        .HasColumnType("varchar(4)");

    builder.Property(e => e.cst_cofins)
        .HasColumnType("varchar(4)");

    builder.Property(e => e.cst_ipi)
        .HasColumnType("varchar(4)");

    builder.Property(e => e.valor_icms)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.aliquota_icms)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.base_icms)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.valor_pis)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.aliquota_pis)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.base_pis)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.valor_cofins)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.aliquota_cofins)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.base_cofins)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.valor_icms_st)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.aliquota_icms_st)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.base_icms_st)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.valor_ipi)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.aliquota_ipi)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.base_ipi)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.valor_total)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.forma_dinheiro)
        .HasProviderColumnType(LogicalColumnType.Bool);

    builder.Property(e => e.total_dinheiro)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.forma_cheque)
        .HasProviderColumnType(LogicalColumnType.Bool);

    builder.Property(e => e.total_cheque)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.forma_cartao)
        .HasProviderColumnType(LogicalColumnType.Bool);

    builder.Property(e => e.total_cartao)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.forma_crediario)
        .HasProviderColumnType(LogicalColumnType.Bool);

    builder.Property(e => e.total_crediario)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.forma_convenio)
        .HasProviderColumnType(LogicalColumnType.Bool);

    builder.Property(e => e.total_convenio)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.frete)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.operacao)
        .HasColumnType("char(2)");

    builder.Property(e => e.tipo_transacao)
        .HasColumnType("char(1)");

    builder.Property(e => e.cod_produto)
        .HasColumnType("bigint");

    builder.Property(e => e.cod_barra)
        .HasColumnType("varchar(20)");

    builder.Property(e => e.cancelado)
        .HasColumnType("char(1)");

    builder.Property(e => e.excluido)
        .HasColumnType("char(1)");

    builder.Property(e => e.soma_relatorio)
        .HasColumnType("char(1)");

    builder.Property(e => e.identificador)
        .HasProviderColumnType(LogicalColumnType.UUID);

    builder.Property(e => e.deposito)
        .HasColumnType("varchar(100)");

    builder.Property(e => e.obs)
        .HasColumnType("varchar(max)");

    builder.Property(e => e.preco_unitario)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.hora_lancamento)
        .HasColumnType("char(5)");

    builder.Property(e => e.natureza_operacao)
        .HasColumnType("varchar(60)");

    builder.Property(e => e.tabela_preco)
        .HasColumnType("int");

    builder.Property(e => e.nome_tabela_preco)
        .HasColumnType("varchar(50)");

    builder.Property(e => e.cod_sefaz_situacao)
        .HasColumnType("int");

    builder.Property(e => e.desc_sefaz_situacao)
        .HasColumnType("varchar(30)");

    builder.Property(e => e.protocolo_aut_nfe)
        .HasColumnType("varchar(15)");

    builder.Property(e => e.dt_update)
        .HasProviderColumnType(LogicalColumnType.DateTime);

    builder.Property(e => e.forma_cheque_prazo)
        .HasProviderColumnType(LogicalColumnType.Bool);

    builder.Property(e => e.total_cheque_prazo)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.cod_natureza_operacao)
        .HasColumnType("char(10)");

    builder.Property(e => e.preco_tabela_epoca)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.desconto_total_item)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.conferido)
        .HasColumnType("char(1)");

    builder.Property(e => e.transacao_pedido_venda)
        .HasColumnType("int");

    builder.Property(e => e.codigo_modelo_nf)
        .HasColumnType("varchar(5)");

    builder.Property(e => e.acrescimo)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.mob_checkout)
        .HasProviderColumnType(LogicalColumnType.Bool);

    builder.Property(e => e.aliquota_iss)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.base_iss)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.ordem)
        .HasColumnType("int");

    builder.Property(e => e.codigo_rotina_origem)
        .HasColumnType("int");

    builder.Property(e => e.timestamp)
        .HasColumnType("bigint");

    builder.Property(e => e.troco)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.transportador)
        .HasColumnType("int");

    builder.Property(e => e.icms_aliquota_desonerado)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.icms_valor_desonerado_item)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.empresa)
        .HasColumnType("int");

    builder.Property(e => e.desconto_item)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.aliq_iss)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.iss_base_item)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.despesas)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.seguro_total_item)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.acrescimo_total_item)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.despesas_total_item)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.forma_pix)
        .HasProviderColumnType(LogicalColumnType.Bool);

    builder.Property(e => e.total_pix)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.forma_deposito_bancario)
        .HasProviderColumnType(LogicalColumnType.Bool);

    builder.Property(e => e.total_deposito_bancario)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.id_venda_produto_b2c)
        .HasColumnType("int");

    builder.Property(e => e.item_promocional)
        .HasProviderColumnType(LogicalColumnType.Bool);

    builder.Property(e => e.acrescimo_item)
        .HasProviderColumnType(LogicalColumnType.Bool);

    builder.Property(e => e.icms_st_antecipado_aliquota)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.icms_st_antecipado_margem)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.icms_st_antecipado_percentual_reducao)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.icms_st_antecipado_valor_item)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.icms_base_desonerado_item)
        .HasColumnType("decimal(10,2)");

    builder.Property(e => e.codigo_status_nfe)
        .HasColumnType("varchar(5)");
        }
    }

    public class LinxMovimentoRawMap : IEntityTypeConfiguration<LinxMovimento>
    {
        public void Configure(EntityTypeBuilder<LinxMovimento> builder)
        {
            builder.ToTable("LinxMovimento", "untreated");

            builder.HasKey(e => new {
                e.cnpj_emp,
                e.documento,
                e.chave_nf,
                e.data_documento,
                e.codigo_cliente,
                e.cod_produto,
                e.cancelado,
                e.excluido,
                e.transacao_pedido_venda,
                e.ordem
            });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.transacao)
                .HasColumnType("int");

            builder.Property(e => e.usuario)
                .HasColumnType("int");

            builder.Property(e => e.documento)
                .HasColumnType("int");

            builder.Property(e => e.chave_nf)
                .HasColumnType("varchar(44)");

            builder.Property(e => e.ecf)
                .HasColumnType("int");

            builder.Property(e => e.numero_serie_ecf)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.modelo_nf)
                .HasColumnType("int");

            builder.Property(e => e.data_documento)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.data_lancamento)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigo_cliente)
                .HasColumnType("int");

            builder.Property(e => e.serie)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.desc_cfop)
                .HasColumnType("varchar(300)");

            builder.Property(e => e.id_cfop)
                .HasColumnType("varchar(5)");

            builder.Property(e => e.cod_vendedor)
                .HasColumnType("int");

            builder.Property(e => e.quantidade)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.preco_custo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_liquido)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.desconto)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cst_icms)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.cst_pis)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.cst_cofins)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.cst_ipi)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.valor_icms)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliquota_icms)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.base_icms)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_pis)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliquota_pis)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.base_pis)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_cofins)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliquota_cofins)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.base_cofins)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_icms_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliquota_icms_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.base_icms_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_ipi)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliquota_ipi)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.base_ipi)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_total)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.forma_dinheiro)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.total_dinheiro)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.forma_cheque)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.total_cheque)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.forma_cartao)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.total_cartao)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.forma_crediario)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.total_crediario)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.forma_convenio)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.total_convenio)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.frete)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.operacao)
                .HasColumnType("char(2)");

            builder.Property(e => e.tipo_transacao)
                .HasColumnType("char(1)");

            builder.Property(e => e.cod_produto)
                .HasColumnType("bigint");

            builder.Property(e => e.cod_barra)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.cancelado)
                .HasColumnType("char(1)");

            builder.Property(e => e.excluido)
                .HasColumnType("char(1)");

            builder.Property(e => e.soma_relatorio)
                .HasColumnType("char(1)");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.deposito)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.obs)
                .HasColumnType("varchar(max)");

            builder.Property(e => e.preco_unitario)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.hora_lancamento)
                .HasColumnType("char(5)");

            builder.Property(e => e.natureza_operacao)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.tabela_preco)
                .HasColumnType("int");

            builder.Property(e => e.nome_tabela_preco)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.cod_sefaz_situacao)
                .HasColumnType("int");

            builder.Property(e => e.desc_sefaz_situacao)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.protocolo_aut_nfe)
                .HasColumnType("varchar(15)");

            builder.Property(e => e.dt_update)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.forma_cheque_prazo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.total_cheque_prazo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cod_natureza_operacao)
                .HasColumnType("char(10)");

            builder.Property(e => e.preco_tabela_epoca)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.desconto_total_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.conferido)
                .HasColumnType("char(1)");

            builder.Property(e => e.transacao_pedido_venda)
                .HasColumnType("int");

            builder.Property(e => e.codigo_modelo_nf)
                .HasColumnType("varchar(5)");

            builder.Property(e => e.acrescimo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.mob_checkout)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.aliquota_iss)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.base_iss)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.ordem)
                .HasColumnType("int");

            builder.Property(e => e.codigo_rotina_origem)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.troco)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.transportador)
                .HasColumnType("int");

            builder.Property(e => e.icms_aliquota_desonerado)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_valor_desonerado_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.desconto_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliq_iss)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.iss_base_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.despesas)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.seguro_total_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.acrescimo_total_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.despesas_total_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.forma_pix)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.total_pix)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.forma_deposito_bancario)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.total_deposito_bancario)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.id_venda_produto_b2c)
                .HasColumnType("int");

            builder.Property(e => e.item_promocional)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.acrescimo_item)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.icms_st_antecipado_aliquota)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_st_antecipado_margem)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_st_antecipado_percentual_reducao)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_st_antecipado_valor_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_base_desonerado_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.codigo_status_nfe)
                .HasColumnType("varchar(5)");
        }
    }
}
