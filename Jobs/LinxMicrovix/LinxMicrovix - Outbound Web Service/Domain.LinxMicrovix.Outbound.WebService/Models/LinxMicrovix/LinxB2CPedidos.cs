
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxB2CPedidos
    {
        public DateTime lastupdateon { get; private set; }
        public Int32? id_pedido { get; private set; }
        public DateTime dt_pedido { get; private set; }
        public Int32 cod_cliente_erp { get; private set; }
        public Int32 cod_cliente_b2c { get; private set; }
        public decimal vl_frete { get; private set; }
        public Int32 forma_pgto { get; private set; }
        public Int32 plano_pagamento { get; private set; }
        public string anotacao { get; private set; }
        public decimal taxa_impressao { get; private set; }
        public bool finalizado { get; private set; }
        public decimal valor_frete_gratis { get; private set; }
        public Int32 tipo_frete { get; private set; }
        public Int32 id_status { get; private set; }
        public Int32 cod_transportador { get; private set; }
        public Int32 tipo_cobranca_frete { get; private set; }
        public bool ativo { get; private set; }
        public Int32 empresa { get; private set; }
        public Int32 id_tabela_preco { get; private set; }
        public decimal valor_credito { get; private set; }
        public Int32 cod_vendedor { get; private set; }
        public Int64 timestamp { get; private set; }
        public DateTime dt_insert { get; private set; }
        public DateTime dt_disponivel_faturamento { get; private set; }
        public string mensagem_falha_faturamento { get; private set; }
        public Int32 portal { get; private set; }
        public Int32 id_tipo_b2c { get; private set; }
        public string ecommerce_origem { get; private set; }
        public string marketplace_loja { get; private set; }
        public string order_id { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxB2CPedidos() { }

        public LinxB2CPedidos(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxB2CPedidos record, string recordXml) {
            this.lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.vl_frete = CustomConvertersExtensions.ConvertToDecimalValidation(record.vl_frete);
            this.taxa_impressao = CustomConvertersExtensions.ConvertToDecimalValidation(record.taxa_impressao);
            this.valor_frete_gratis = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_frete_gratis);
            this.id_tipo_b2c = CustomConvertersExtensions.ConvertToInt32Validation(record.id_tipo_b2c);
            this.id_tabela_preco = CustomConvertersExtensions.ConvertToInt32Validation(record.id_tabela_preco);
            this.id_pedido = CustomConvertersExtensions.ConvertToInt32Validation(record.id_pedido);
            this.dt_pedido =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.dt_pedido);
            this.dt_insert =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.dt_insert);
            this.dt_disponivel_faturamento =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.dt_disponivel_faturamento);
            this.cod_cliente_erp = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_cliente_erp);
            this.cod_cliente_b2c = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_cliente_b2c);
            this.forma_pgto = CustomConvertersExtensions.ConvertToInt32Validation(record.forma_pgto);
            this.plano_pagamento = CustomConvertersExtensions.ConvertToInt32Validation(record.plano_pagamento);
            this.tipo_frete = CustomConvertersExtensions.ConvertToInt32Validation(record.tipo_frete);
            this.id_status = CustomConvertersExtensions.ConvertToInt32Validation(record.id_status);
            this.cod_transportador = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_transportador);
            this.tipo_cobranca_frete = CustomConvertersExtensions.ConvertToInt32Validation(record.tipo_cobranca_frete);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.id_tabela_preco = CustomConvertersExtensions.ConvertToInt32Validation(record.id_tabela_preco);
            this.cod_vendedor = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_vendedor);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.recordKey = $"[{record.empresa}]|[{record.id_pedido}]|[{record.cod_cliente_b2c}]|[{record.cod_cliente_erp}]|[{record.order_id}]|[{record.timestamp}]";
            this.recordXml = recordXml;
            this.order_id = record.order_id;
            this.anotacao = record.anotacao;
            this.ecommerce_origem = record.ecommerce_origem;
            this.marketplace_loja = record.marketplace_loja;
            this.mensagem_falha_faturamento = record.mensagem_falha_faturamento;
        }
    }
}
