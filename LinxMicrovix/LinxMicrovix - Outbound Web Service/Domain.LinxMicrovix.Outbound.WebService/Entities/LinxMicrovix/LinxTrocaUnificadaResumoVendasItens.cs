using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxTrocaUnificadaResumoVendasItens
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int64? id_troca_unificada_resumo_vendas_itens { get; private set; }

        public Int64? id_troca_unificada_resumo_vendas { get; private set; }

        public Int64? codigoproduto { get; private set; }

        public Int32? transacao { get; private set; }

        [LengthValidation(length: 50, propertyName: "serial")]
        public string? serial { get; private set; }

        public decimal? valor_liquido { get; private set; }

        public DateTime? data_validade { get; private set; }

        public bool? venda_referenciada { get; private set; }

        public bool? token_utilizado { get; private set; }

        public decimal? quantidade { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxTrocaUnificadaResumoVendasItens() { }

        public LinxTrocaUnificadaResumoVendasItens(
            List<ValidationResult> listValidations,
            string? id_troca_unificada_resumo_vendas_itens,
            string? id_troca_unificada_resumo_vendas,
            string? codigoproduto,
            string? transacao,
            string? serial,
            string? valor_liquido,
            string? data_validade,
            string? venda_referenciada,
            string? token_utilizado,
            string? quantidade,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.transacao =
                ConvertToInt32Validation.IsValid(transacao, "transacao", listValidations) ?
                Convert.ToInt32(transacao) :
                0;

            this.id_troca_unificada_resumo_vendas_itens =
                ConvertToInt64Validation.IsValid(id_troca_unificada_resumo_vendas_itens, "id_troca_unificada_resumo_vendas_itens", listValidations) ?
                Convert.ToInt64(id_troca_unificada_resumo_vendas_itens) :
                0;

            this.id_troca_unificada_resumo_vendas =
                ConvertToInt64Validation.IsValid(id_troca_unificada_resumo_vendas, "id_troca_unificada_resumo_vendas", listValidations) ?
                Convert.ToInt64(id_troca_unificada_resumo_vendas) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.valor_liquido =
                ConvertToDecimalValidation.IsValid(valor_liquido, "valor_liquido", listValidations) ?
                Convert.ToDecimal(valor_liquido, new CultureInfo("en-US")) :
                0;

            this.quantidade =
                ConvertToDecimalValidation.IsValid(quantidade, "quantidade", listValidations) ?
                Convert.ToDecimal(quantidade, new CultureInfo("en-US")) :
                0;

            this.venda_referenciada =
                ConvertToBooleanValidation.IsValid(venda_referenciada, "venda_referenciada", listValidations) ?
                Convert.ToBoolean(venda_referenciada) :
                false;

            this.token_utilizado =
                ConvertToBooleanValidation.IsValid(token_utilizado, "token_utilizado", listValidations) ?
                Convert.ToBoolean(token_utilizado) :
                false;

            this.data_validade =
               ConvertToDateTimeValidation.IsValid(data_validade, "data_validade", listValidations) ?
               Convert.ToDateTime(data_validade) :
               new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.serial = serial;
        }
    }
}
