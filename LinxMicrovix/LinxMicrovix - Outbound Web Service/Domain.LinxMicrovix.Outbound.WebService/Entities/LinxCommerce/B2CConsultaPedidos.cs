using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    [Table("B2CConsultaPedidos", Schema = "linx_microvix_commerce")]
    public class B2CConsultaPedidos
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? id_pedido { get; private set; }

        public DateTime? dt_pedido { get; private set; }

        public Int32? cod_cliente_erp { get; private set; }

        public Int32? cod_cliente_b2c { get; private set; }

        public decimal? vl_frete { get; private set; }

        public Int32? forma_pgto { get; private set; }

        public Int32? plano_pagamento { get; private set; }

        [LengthValidation(length: 400, propertyName: "anotacao")]
        public string? anotacao { get; private set; }

        public decimal? taxa_impressao { get; private set; }

        public Int32? finalizado { get; private set; }

        public decimal? valor_frete_gratis { get; private set; }

        public Int32? tipo_frete { get; private set; }

        public Int32? id_status { get; private set; }

        public Int32? cod_transportador { get; private set; }

        public Int32? tipo_cobranca_frete { get; private set; }

        public Int32? ativo { get; private set; }

        public Int32? empresa { get; private set; }

        public Int32? id_tabela_preco { get; private set; }

        public decimal? valor_credito { get; private set; }

        public Int32? cod_vendedor { get; private set; }

        public Int64? timestamp { get; private set; }

        public DateTime? dt_insert { get; private set; }

        public DateTime? dt_disponivel_faturamento { get; private set; }

        public Int32? portal { get; private set; }

        public string? mensagem_falha_faturamento { get; private set; }

        public Int32? id_tipo_b2c { get; private set; }

        [LengthValidation(length: 200, propertyName: "ecommerce_origem")]
        public string? ecommerce_origem { get; private set; }

        [LengthValidation(length: 40, propertyName: "order_id")]
        public string? order_id { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaPedidos() { }

        public B2CConsultaPedidos(
            List<ValidationResult> listValidations,
            string? id_pedido,
            string? dt_pedido,
            string? cod_cliente_erp,
            string? cod_cliente_b2c,
            string? vl_frete,
            string? forma_pgto,
            string? plano_pagamento,
            string? anotacao,
            string? taxa_impressao,
            string? finalizado,
            string? valor_frete_gratis,
            string? tipo_frete,
            string? id_status,
            string? cod_transportador,
            string? tipo_cobranca_frete,
            string? ativo,
            string? empresa,
            string? id_tabela_preco,
            string? valor_credito,
            string? cod_vendedor,
            string? timestamp,
            string? dt_insert,
            string? dt_disponivel_faturamento,
            string? portal,
            string? mensagem_falha_faturamento,
            string? id_tipo_b2c,
            string? ecommerce_origem,
            string? order_id,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_pedido =
                ConvertToInt32Validation.IsValid(id_pedido, "id_pedido", listValidations) ?
                Convert.ToInt32(id_pedido) :
                0;

            this.dt_pedido =
                ConvertToDateTimeValidation.IsValid(dt_pedido, "dt_pedido", listValidations) ?
                Convert.ToDateTime(dt_pedido) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.cod_cliente_erp =
                ConvertToInt32Validation.IsValid(cod_cliente_erp, "cod_cliente_erp", listValidations) ?
                Convert.ToInt32(cod_cliente_erp) :
                0;

            this.cod_cliente_b2c =
                ConvertToInt32Validation.IsValid(cod_cliente_b2c, "cod_cliente_b2c", listValidations) ?
                Convert.ToInt32(cod_cliente_b2c) :
                0;

            this.vl_frete =
                ConvertToDecimalValidation.IsValid(vl_frete, "vl_frete", listValidations) ?
                Convert.ToDecimal(vl_frete, new CultureInfo("en-US")) :
                0;

            this.forma_pgto =
                ConvertToInt32Validation.IsValid(forma_pgto, "forma_pgto", listValidations) ?
                Convert.ToInt32(forma_pgto) :
                0;

            this.plano_pagamento =
                ConvertToInt32Validation.IsValid(plano_pagamento, "plano_pagamento", listValidations) ?
                Convert.ToInt32(plano_pagamento) :
                0;

            this.taxa_impressao =
                String.IsNullOrEmpty(taxa_impressao) ? 0
                : Convert.ToDecimal(taxa_impressao, new CultureInfo("en-US"));

            this.finalizado =
                ConvertToInt32Validation.IsValid(finalizado, "finalizado", listValidations) ?
                Convert.ToInt32(finalizado) :
                0;

            this.valor_frete_gratis =
                ConvertToDecimalValidation.IsValid(valor_frete_gratis, "valor_frete_gratis", listValidations) ?
                Convert.ToDecimal(valor_frete_gratis, new CultureInfo("en-US")) :
                0;

            this.tipo_frete =
                ConvertToInt32Validation.IsValid(tipo_frete, "tipo_frete", listValidations) ?
                Convert.ToInt32(tipo_frete) :
                0;

            this.id_status =
                ConvertToInt32Validation.IsValid(id_status, "id_status", listValidations) ?
                Convert.ToInt32(id_status) :
                0;

            this.cod_transportador =
                ConvertToInt32Validation.IsValid(cod_transportador, "cod_transportador", listValidations) ?
                Convert.ToInt32(cod_transportador) :
                0;

            this.tipo_cobranca_frete =
                ConvertToInt32Validation.IsValid(tipo_cobranca_frete, "tipo_cobranca_frete", listValidations) ?
                Convert.ToInt32(tipo_cobranca_frete) :
                0;

            this.ativo =
                ConvertToInt32Validation.IsValid(ativo, "ativo", listValidations) ?
                Convert.ToInt32(ativo) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.id_tabela_preco =
                ConvertToInt32Validation.IsValid(id_tabela_preco, "id_tabela_preco", listValidations) ?
                Convert.ToInt32(id_tabela_preco) :
                0;

            this.valor_credito =
                ConvertToDecimalValidation.IsValid(valor_credito, "valor_credito", listValidations) ?
                Convert.ToDecimal(valor_credito, new CultureInfo("en-US")) :
                0;

            this.cod_vendedor =
                ConvertToInt32Validation.IsValid(cod_vendedor, "cod_vendedor", listValidations) ?
                Convert.ToInt32(cod_vendedor) :
                0;

            this.dt_insert =
                ConvertToDateTimeValidation.IsValid(dt_insert, "dt_insert", listValidations) ?
                Convert.ToDateTime(dt_insert) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.dt_disponivel_faturamento =
                ConvertToDateTimeValidation.IsValid(dt_disponivel_faturamento, "dt_disponivel_faturamento", listValidations) ?
                Convert.ToDateTime(dt_disponivel_faturamento) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.id_tipo_b2c =
                ConvertToInt32Validation.IsValid(id_tipo_b2c, "id_tipo_b2c", listValidations) ?
                Convert.ToInt32(id_tipo_b2c) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.anotacao = anotacao;
            this.ecommerce_origem = ecommerce_origem;
            this.order_id = order_id;
            this.mensagem_falha_faturamento = mensagem_falha_faturamento;
            this.recordKey = $"[{empresa}]|[{id_pedido}]|[{cod_cliente_b2c}]|[{cod_cliente_erp}]|[{order_id}]|[{timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
