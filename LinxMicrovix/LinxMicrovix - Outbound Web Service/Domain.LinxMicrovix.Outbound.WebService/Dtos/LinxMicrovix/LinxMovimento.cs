using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimento
    {
        public string? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public string? transacao { get; private set; }
        public string? usuario { get; private set; }
        public string? documento { get; private set; }
        public string? chave_nf { get; private set; }
        public string? ecf { get; private set; }
        public string? numero_serie_ecf { get; private set; }
        public string? modelo_nf { get; private set; }
        public string? data_documento { get; private set; }
        public string? data_lancamento { get; private set; }
        public string? codigo_cliente { get; private set; }
        public string? serie { get; private set; }
        public string? desc_cfop { get; private set; }
        public string? id_cfop { get; private set; }
        public string? cod_vendedor { get; private set; }
        public string? quantidade { get; private set; }
        public string? preco_custo { get; private set; }
        public string? valor_liquido { get; private set; }
        public string? desconto { get; private set; }
        public string? cst_icms { get; private set; }
        public string? cst_pis { get; private set; }
        public string? cst_cofins { get; private set; }
        public string? cst_ipi { get; private set; }
        public string? valor_icms { get; private set; }
        public string? aliquota_icms { get; private set; }
        public string? base_icms { get; private set; }
        public string? valor_pis { get; private set; }
        public string? aliquota_pis { get; private set; }
        public string? base_pis { get; private set; }
        public string? valor_cofins { get; private set; }
        public string? aliquota_cofins { get; private set; }
        public string? base_cofins { get; private set; }
        public string? valor_icms_st { get; private set; }
        public string? aliquota_icms_st { get; private set; }
        public string? base_icms_st { get; private set; }
        public string? valor_ipi { get; private set; }
        public string? aliquota_ipi { get; private set; }
        public string? base_ipi { get; private set; }
        public string? valor_total { get; private set; }
        public string? forma_dinheiro { get; private set; }
        public string? total_dinheiro { get; private set; }
        public string? forma_cheque { get; private set; }
        public string? total_cheque { get; private set; }
        public string? forma_cartao { get; private set; }
        public string? total_cartao { get; private set; }
        public string? forma_crediario { get; private set; }
        public string? total_crediario { get; private set; }
        public string? forma_convenio { get; private set; }
        public string? total_convenio { get; private set; }
        public string? frete { get; private set; }
        public string? operacao { get; private set; }
        public string? tipo_transacao { get; private set; }
        public string? cod_produto { get; private set; }        
        public string? cod_barra { get; private set; }        
        public string? cancelado { get; private set; }        
        public string? excluido { get; private set; }        
        public string? soma_relatorio { get; private set; }
        public string? identificador { get; private set; }        
        public string? deposito { get; private set; }
        public string? obs { get; private set; }
        public string? preco_unitario { get; private set; }        
        public string? hora_lancamento { get; private set; }       
        public string? natureza_operacao { get; private set; }
        public string? tabela_preco { get; private set; }
        public string? nome_tabela_preco { get; private set; }
        public string? cod_sefaz_situacao { get; private set; }
        public string? desc_sefaz_situacao { get; private set; }
        public string? protocolo_aut_nfe { get; private set; }
        public string? dt_update { get; private set; }
        public string? forma_cheque_prazo { get; private set; }
        public string? total_cheque_prazo { get; private set; }
        public string? cod_natureza_operacao { get; private set; }
        public string? preco_tabela_epoca { get; private set; }
        public string? desconto_total_item { get; private set; }
        public string? conferido { get; private set; }
        public string? transacao_pedido_venda { get; private set; }
        public string? codigo_modelo_nf { get; private set; }
        public string? acrescimo { get; private set; }
        public string? mob_checkout { get; private set; }
        public string? aliquota_iss { get; private set; }
        public string? base_iss { get; private set; }
        public string? ordem { get; private set; }
        public string? codigo_rotina_origem { get; private set; }
        public string? timestamp { get; private set; }
        public string? troco { get; private set; }
        public string? transportador { get; private set; }
        public string? icms_aliquota_desonerado { get; private set; }
        public string? icms_valor_desonerado_item { get; private set; }
        public string? empresa { get; private set; }
        public string? desconto_item { get; private set; }
        public string? aliq_iss { get; private set; }
        public string? iss_base_item { get; private set; }
        public string? despesas { get; private set; }
        public string? seguro_total_item { get; private set; }
        public string? acrescimo_total_item { get; private set; }
        public string? despesas_total_item { get; private set; }
        public string? forma_pix { get; private set; }
        public string? total_pix { get; private set; }
        public string? forma_deposito_bancario { get; private set; }
        public string? total_deposito_bancario { get; private set; }
        public string? id_venda_produto_b2c { get; private set; }
        public string? item_promocional { get; private set; }
        public string? acrescimo_item { get; private set; }
        public string? icms_st_antecipado_aliquota { get; private set; }
        public string? icms_st_antecipado_margem { get; private set; }
        public string? icms_st_antecipado_percentual_reducao { get; private set; }
        public string? icms_st_antecipado_valor_item { get; private set; }
        public string? icms_base_desonerado_item { get; private set; }
        public string? codigo_status_nfe { get; private set; }

        public LinxMovimento() { }

        public LinxMovimento(
            string? portal,
            string? cnpj_emp,
            string? transacao,
            string? usuario,
            string? documento,
            string? chave_nf,
            string? ecf,
            string? numero_serie_ecf,
            string? modelo_nf,
            string? data_documento,
            string? data_lancamento,
            string? codigo_cliente,
            string? serie,
            string? desc_cfop,
            string? id_cfop,
            string? cod_vendedor,
            string? quantidade,
            string? preco_custo,
            string? valor_liquido,
            string? desconto,
            string? cst_icms,
            string? cst_pis,
            string? cst_cofins,
            string? cst_ipi,
            string? valor_icms,
            string? aliquota_icms,
            string? base_icms,
            string? valor_pis,
            string? aliquota_pis,
            string? base_pis,
            string? valor_cofins,
            string? aliquota_cofins,
            string? base_cofins,
            string? valor_icms_st,
            string? aliquota_icms_st,
            string? base_icms_st,
            string? valor_ipi,
            string? aliquota_ipi,
            string? base_ipi,
            string? valor_total,
            string? forma_dinheiro,
            string? total_dinheiro,
            string? forma_cheque,
            string? total_cheque,
            string? forma_cartao,
            string? total_cartao,
            string? total_crediario,
            string? forma_crediario,
            string? forma_convenio,
            string? total_convenio,
            string? frete,
            string? operacao,
            string? tipo_transacao,
            string? cod_produto,
            string? cod_barra,
            string? cancelado,
            string? excluido,
            string? soma_relatorio,
            string? identificador,
            string? deposito,
            string? obs,
            string? preco_unitario,
            string? hora_lancamento,
            string? natureza_operacao,
            string? tabela_preco,
            string? nome_tabela_preco,
            string? cod_sefaz_situacao,
            string? desc_sefaz_situacao,
            string? protocolo_aut_nfe,
            string? dt_update,
            string? forma_cheque_prazo,
            string? total_cheque_prazo,
            string? cod_natureza_operacao,
            string? preco_tabela_epoca,
            string? desconto_total_item,
            string? conferido,
            string? transacao_pedido_venda,
            string? codigo_modelo_nf,
            string? acrescimo,
            string? mob_checkout,
            string? aliquota_iss,
            string? base_iss,
            string? ordem,
            string? codigo_rotina_origem,
            string? timestamp,
            string? troco,
            string? transportador,
            string? icms_aliquota_desonerado,
            string? icms_valor_desonerado_item,
            string? empresa,
            string? desconto_item,
            string? aliq_iss,
            string? iss_base_item,
            string? despesas,
            string? seguro_total_item,
            string? acrescimo_total_item,
            string? despesas_total_item,
            string? forma_pix,
            string? total_pix,
            string? forma_deposito_bancario,
            string? total_deposito_bancario,
            string? id_venda_produto_b2c,
            string? item_promocional,
            string? acrescimo_item,
            string? icms_st_antecipado_aliquota,
            string? icms_st_antecipado_margem,
            string? icms_st_antecipado_percentual_reducao,
            string? icms_st_antecipado_valor_item,
            string? icms_base_desonerado_item,
            string? codigo_status_nfe
        )
        {
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.transacao = transacao;
            this.usuario = usuario;
            this.documento = documento;
            this.chave_nf = chave_nf;
            this.ecf = ecf;
            this.numero_serie_ecf = numero_serie_ecf;
            this.modelo_nf = modelo_nf;
            this.data_documento = data_documento;
            this.data_lancamento = data_lancamento;
            this.codigo_cliente = codigo_cliente;
            this.serie = serie;
            this.desc_cfop = desc_cfop;
            this.id_cfop = id_cfop;
            this.cod_vendedor = cod_vendedor;
            this.quantidade = quantidade;
            this.preco_custo = preco_custo;
            this.valor_liquido = valor_liquido;
            this.desconto = desconto;
            this.cst_icms = cst_icms;
            this.cst_pis = cst_pis;
            this.cst_cofins = cst_cofins;
            this.cst_ipi = cst_ipi;
            this.valor_icms = valor_icms;
            this.aliquota_icms = aliquota_icms;
            this.base_icms = base_icms;
            this.valor_pis = valor_pis;
            this.aliquota_pis = aliquota_pis;
            this.base_pis = base_pis;
            this.valor_cofins = valor_cofins;
            this.aliquota_cofins = aliquota_cofins;
            this.base_cofins = base_cofins;
            this.valor_icms_st = valor_icms_st;
            this.aliquota_icms_st = aliquota_icms_st;
            this.base_icms_st = base_icms_st;
            this.valor_ipi = valor_ipi;
            this.aliquota_ipi = aliquota_ipi;
            this.base_ipi = base_ipi;
            this.valor_total = valor_total;
            this.forma_dinheiro = forma_dinheiro;
            this.total_dinheiro = total_dinheiro;
            this.forma_cheque = forma_cheque;
            this.total_cheque = total_cheque;
            this.forma_cartao = forma_cartao;
            this.total_cartao = total_cartao;
            this.total_crediario = total_crediario;
            this.forma_crediario = forma_crediario;
            this.forma_convenio = forma_convenio;
            this.total_convenio = total_convenio;
            this.frete = frete;
            this.operacao = operacao;
            this.tipo_transacao = tipo_transacao;
            this.cod_produto = cod_produto;
            this.cod_barra = cod_barra;
            this.cancelado = cancelado;
            this.excluido = excluido;
            this.soma_relatorio = soma_relatorio;
            this.identificador = identificador;
            this.deposito = deposito;
            this.obs = obs;
            this.preco_unitario = preco_unitario;
            this.hora_lancamento = hora_lancamento;
            this.natureza_operacao = natureza_operacao;
            this.tabela_preco = tabela_preco;
            this.nome_tabela_preco = nome_tabela_preco;
            this.cod_sefaz_situacao = cod_sefaz_situacao;
            this.desc_sefaz_situacao = desc_sefaz_situacao;
            this.protocolo_aut_nfe = protocolo_aut_nfe;
            this.dt_update = dt_update;
            this.forma_cheque_prazo = forma_cheque_prazo;
            this.total_cheque_prazo = total_cheque_prazo;
            this.cod_natureza_operacao = cod_natureza_operacao;
            this.preco_tabela_epoca = preco_tabela_epoca;
            this.desconto_total_item = desconto_total_item;
            this.conferido = conferido;
            this.transacao_pedido_venda = transacao_pedido_venda;
            this.codigo_modelo_nf = codigo_modelo_nf;
            this.acrescimo = acrescimo;
            this.mob_checkout = mob_checkout;
            this.aliquota_iss = aliquota_iss;
            this.base_iss = base_iss;
            this.ordem = ordem;
            this.codigo_rotina_origem = codigo_rotina_origem;
            this.timestamp = timestamp;
            this.troco = troco;
            this.transportador = transportador;
            this.icms_aliquota_desonerado = icms_aliquota_desonerado;
            this.icms_valor_desonerado_item = icms_valor_desonerado_item;
            this.empresa = empresa;
            this.desconto_item = desconto_item;
            this.aliq_iss = aliq_iss;
            this.iss_base_item = iss_base_item;
            this.despesas = despesas;
            this.seguro_total_item = seguro_total_item;
            this.acrescimo_total_item = acrescimo_total_item;
            this.despesas_total_item = despesas_total_item;
            this.forma_pix = forma_pix;
            this.total_pix = total_pix;
            this.forma_deposito_bancario = forma_deposito_bancario;
            this.total_deposito_bancario = total_deposito_bancario;
            this.id_venda_produto_b2c = id_venda_produto_b2c;
            this.item_promocional = item_promocional;
            this.acrescimo_item = acrescimo_item;
            this.icms_st_antecipado_aliquota = icms_st_antecipado_aliquota;
            this.icms_st_antecipado_margem = icms_st_antecipado_margem;
            this.icms_st_antecipado_percentual_reducao = icms_st_antecipado_percentual_reducao;
            this.icms_st_antecipado_valor_item = icms_st_antecipado_valor_item;
            this.icms_base_desonerado_item = icms_base_desonerado_item;
            this.codigo_status_nfe = codigo_status_nfe;
        }
    }
}