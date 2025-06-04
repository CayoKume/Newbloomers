using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix
{
    public class LinxOrcamentoComponenteFormula
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_orcamento_componente_formula { get; private set; }

        public Int32? documento { get; private set; }

        public Int64? codigo_produto { get; private set; }

        [LengthValidation(length: 10, propertyName: "codigo_componente")]
        public string? codigo_componente { get; private set; }

        [LengthValidation(length: 50, propertyName: "descricao_componente")]
        public string? descricao_componente { get; private set; }

        [LengthValidation(length: 5, propertyName: "unidade")]
        public string? unidade { get; private set; }

        public decimal? quantidade { get; private set; }

        public decimal? valor_componente { get; private set; }

        [LengthValidation(length: 30, propertyName: "lote_componente")]
        public string? lote_componente { get; private set; }

        public DateTime? data_validade_lote { get; private set; }

        [LengthValidation(length: 50, propertyName: "codigo_ws")]
        public string? codigo_ws { get; private set; }

        public Int32? portal { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxOrcamentoComponenteFormula() { }

        public LinxOrcamentoComponenteFormula(
            List<ValidationResult> listValidations,
            string? id_orcamento_componente_formula,
            string? documento,
            string? codigo_produto,
            string? codigo_componente,
            string? descricao_componente,
            string? unidade,
            string? quantidade,
            string? valor_componente,
            string? lote_componente,
            string? data_validade_lote,
            string? codigo_ws,
            string? portal,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_orcamento_componente_formula =
                ConvertToInt32Validation.IsValid(id_orcamento_componente_formula, "id_orcamento_componente_formula", listValidations) ?
                Convert.ToInt32(id_orcamento_componente_formula) :
                0;

            this.documento =
                ConvertToInt32Validation.IsValid(documento, "documento", listValidations) ?
                Convert.ToInt32(documento) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.data_validade_lote =
               ConvertToDateTimeValidation.IsValid(data_validade_lote, "data_validade_lote", listValidations) ?
               Convert.ToDateTime(data_validade_lote) :
               new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.quantidade =
                ConvertToDecimalValidation.IsValid(quantidade, "quantidade", listValidations) ?
                Convert.ToDecimal(quantidade, new CultureInfo("en-US")) :
                0;

            this.valor_componente =
                ConvertToDecimalValidation.IsValid(valor_componente, "valor_componente", listValidations) ?
                Convert.ToDecimal(valor_componente, new CultureInfo("en-US")) :
                0;

            this.codigo_produto =
                ConvertToInt64Validation.IsValid(codigo_produto, "codigo_produto", listValidations) ?
                Convert.ToInt64(codigo_produto) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.codigo_componente = codigo_componente;
            this.descricao_componente = descricao_componente;
            this.unidade = unidade;
            this.lote_componente = lote_componente;
            this.codigo_ws = codigo_ws;
        }
    }
}
