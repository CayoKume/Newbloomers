
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxPedidosVenda
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int32? cod_pedido { get; private set; }
        public DateTime? data_lancamento { get; private set; }
        public string? hora_lancamento { get; private set; }
        public Int32? transacao { get; private set; }
        public Int32? usuario { get; private set; }
        public Int32? codigo_cliente { get; private set; }
        public Int64? cod_produto { get; private set; }
        public decimal? quantidade { get; private set; }
        public decimal? valor_unitario { get; private set; }
        public Int32? cod_vendedor { get; private set; }
        public decimal? valor_frete { get; private set; }
        public decimal? valor_total { get; private set; }
        public decimal? desconto_item { get; private set; }
        public Int32? cod_plano_pagamento { get; private set; }
        public string? plano_pagamento { get; private set; }
        public string? obs { get; private set; }
        public string? aprovado { get; private set; }
        public string? cancelado { get; private set; }
        public DateTime? data_aprovacao { get; private set; }
        public DateTime? data_alteracao { get; private set; }
        public Int32? tipo_frete { get; private set; }
        public string? natureza_operacao { get; private set; }
        public Int32? tabela_preco { get; private set; }
        public string? nome_tabela_preco { get; private set; }
        public DateTime? previsao_entrega { get; private set; }
        public Int32? realizado_por { get; private set; }
        public Int32? pontuacao_ser { get; private set; }
        public string? venda_externa { get; private set; }
        public string? nf_gerada { get; private set; }
        public string? status { get; private set; }
        public string? numero_projeto_officina { get; private set; }
        public string? cod_natureza_operacao { get; private set; }
        public decimal? margem_contribuicao { get; private set; }
        public Int32? doc_origem { get; private set; }
        public Int32? posicao_item { get; private set; }
        public Int32? orcamento_origem { get; private set; }
        public Int32? transacao_origem { get; private set; }
        public Int64? timestamp { get; private set; }
        public decimal? desconto { get; private set; }
        public Int32? transacao_ws { get; private set; }
        public Int32? empresa { get; private set; }
        public Int64? transportador { get; private set; }
        public Int32? deposito { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxPedidosVenda() { }

        public LinxPedidosVenda(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxPedidosVenda record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.transacao = CustomConvertersExtensions.ConvertToInt32Validation(record.transacao);
            this.usuario = CustomConvertersExtensions.ConvertToInt32Validation(record.usuario);
            this.codigo_cliente = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_cliente);
            this.cod_pedido = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_pedido);
            this.cod_vendedor = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_vendedor);
            this.cod_plano_pagamento = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_plano_pagamento);
            this.tipo_frete = CustomConvertersExtensions.ConvertToInt32Validation(record.tipo_frete);
            this.tabela_preco = CustomConvertersExtensions.ConvertToInt32Validation(record.tabela_preco);
            this.realizado_por = CustomConvertersExtensions.ConvertToInt32Validation(record.realizado_por);
            this.pontuacao_ser = CustomConvertersExtensions.ConvertToInt32Validation(record.pontuacao_ser);
            this.doc_origem = CustomConvertersExtensions.ConvertToInt32Validation(record.doc_origem);
            this.posicao_item = CustomConvertersExtensions.ConvertToInt32Validation(record.posicao_item);
            this.orcamento_origem = CustomConvertersExtensions.ConvertToInt32Validation(record.orcamento_origem);
            this.transacao_origem = CustomConvertersExtensions.ConvertToInt32Validation(record.transacao_origem);
            this.transacao_ws = CustomConvertersExtensions.ConvertToInt32Validation(record.transacao_ws);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.deposito = CustomConvertersExtensions.ConvertToInt32Validation(record.deposito);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.cod_produto = CustomConvertersExtensions.ConvertToInt64Validation(record.cod_produto);
            this.transportador = CustomConvertersExtensions.ConvertToInt64Validation(record.transportador);
            this.data_lancamento =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_lancamento);
            this.data_aprovacao =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_aprovacao);
            this.data_alteracao =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_alteracao);
            this.previsao_entrega =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.previsao_entrega);
            this.quantidade = CustomConvertersExtensions.ConvertToDecimalValidation(record.quantidade);
            this.valor_unitario = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_unitario);
            this.valor_frete = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_frete);
            this.valor_total = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_total);
            this.desconto_item = CustomConvertersExtensions.ConvertToDecimalValidation(record.desconto_item);
            this.margem_contribuicao = CustomConvertersExtensions.ConvertToDecimalValidation(record.margem_contribuicao);
            this.desconto = CustomConvertersExtensions.ConvertToDecimalValidation(record.desconto);
            this.cod_natureza_operacao = record.cod_natureza_operacao;
            this.numero_projeto_officina = record.numero_projeto_officina;
            this.status = record.status;
            this.nf_gerada = record.nf_gerada;
            this.venda_externa = record.venda_externa;
            this.nome_tabela_preco = record.nome_tabela_preco;
            this.natureza_operacao = record.natureza_operacao;
            this.aprovado = record.aprovado;
            this.cancelado = record.cancelado;
            this.obs = record.obs;
            this.plano_pagamento = record.plano_pagamento;
            this.hora_lancamento = record.hora_lancamento;
            this.cnpj_emp = record.cnpj_emp;
            this.recordKey = $"[{record.cnpj_emp}]|[{record.cod_pedido}]|[{record.codigo_cliente}]|[{record.cod_produto}]|[{record.timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
