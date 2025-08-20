
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxPedidosCompra
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int32? cod_pedido { get; private set; }
        public DateTime? data_pedido { get; private set; }
        public Int32? transacao { get; private set; }
        public Int32? usuario { get; private set; }
        public Int32? codigo_fornecedor { get; private set; }
        public Int64? cod_produto { get; private set; }
        public decimal? quantidade { get; private set; }
        public decimal? valor_unitario { get; private set; }
        public Int32? cod_comprador { get; private set; }
        public decimal? valor_frete { get; private set; }
        public decimal? valor_total { get; private set; }
        public Int32? cod_plano_pagamento { get; private set; }
        public string? plano_pagamento { get; private set; }
        public string? obs { get; private set; }
        public string? aprovado { get; private set; }
        public string? cancelado { get; private set; }
        public string? encerrado { get; private set; }
        public DateTime? data_aprovacao { get; private set; }
        public string? numero_ped_fornec { get; private set; }
        public string? tipo_frete { get; private set; }
        public string? natureza_operacao { get; private set; }
        public DateTime? previsao_entrega { get; private set; }
        public string? numero_projeto_officina { get; private set; }
        public string? status_pedido { get; private set; }
        public decimal? qtde_entregue { get; private set; }
        public string? descricao_frete { get; private set; }
        public Int32? integrado_linx { get; private set; }
        public Int32? nf_gerada { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? empresa { get; private set; }
        public string? nf_origem_ws { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxPedidosCompra() { }

        public LinxPedidosCompra(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxPedidosCompra record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.cod_pedido = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_pedido);
            this.transacao = CustomConvertersExtensions.ConvertToInt32Validation(record.transacao);
            this.usuario = CustomConvertersExtensions.ConvertToInt32Validation(record.usuario);
            this.codigo_fornecedor = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_fornecedor);
            this.cod_comprador = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_comprador);
            this.cod_plano_pagamento = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_plano_pagamento);
            this.nf_gerada = CustomConvertersExtensions.ConvertToInt32Validation(record.nf_gerada);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.cod_produto = CustomConvertersExtensions.ConvertToInt64Validation(record.cod_produto);
            this.data_pedido =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_pedido);
            this.data_aprovacao =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_aprovacao);
            this.previsao_entrega =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.previsao_entrega);
            this.quantidade = CustomConvertersExtensions.ConvertToDecimalValidation(record.quantidade);
            this.valor_unitario = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_unitario);
            this.valor_frete = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_frete);
            this.valor_total = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_total);
            this.qtde_entregue = CustomConvertersExtensions.ConvertToDecimalValidation(record.qtde_entregue);
            this.integrado_linx = CustomConvertersExtensions.ConvertToInt32Validation(record.integrado_linx);
            this.status_pedido = record.status_pedido;
            this.tipo_frete = record.tipo_frete;
            this.nf_origem_ws = record.nf_origem_ws;
            this.descricao_frete = record.descricao_frete;
            this.numero_projeto_officina = record.numero_projeto_officina;
            this.natureza_operacao = record.natureza_operacao;
            this.numero_ped_fornec = record.numero_ped_fornec;
            this.encerrado = record.encerrado;
            this.aprovado = record.aprovado;
            this.cancelado = record.cancelado;
            this.obs = record.obs;
            this.plano_pagamento = record.plano_pagamento;
            this.cnpj_emp = record.cnpj_emp;
            this.recordKey = $"[{record.cnpj_emp}]|[{record.cod_pedido}]|[{record.codigo_fornecedor}]|[{record.cod_produto}]|[{record.timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
