using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxConfiguracoesTributariasDetalhesSimplificado
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        public Int32? id_config_tributaria_detalhe { get; private set; }

        public Int32? id_config_tributaria { get; private set; }

        [LengthValidation(length: 10, propertyName: "cod_natureza_operacao")]
        public string? cod_natureza_operacao { get; private set; }

        public Int32? id_classe_fiscal { get; private set; }

        public Int32? id_cst_icms_fiscal { get; private set; }

        public Int32? id_csosn_fiscal { get; private set; }

        public Int32? id_cfop_fiscal { get; private set; }

        public bool? ipi_credito { get; private set; }

        public bool? icms_credito { get; private set; }

        public decimal? aliq_icms { get; private set; }

        public decimal? perc_reducao_icms { get; private set; }

        public decimal? aliquota_st { get; private set; }

        public decimal? margem_st { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxConfiguracoesTributariasDetalhesSimplificado() { }

        public LinxConfiguracoesTributariasDetalhesSimplificado(
            List<ValidationResult> listValidations,
            string? portal,
            string? id_config_tributaria_detalhe,
            string? id_config_tributaria,
            string? cod_natureza_operacao,
            string? id_classe_fiscal,
            string? id_cst_icms_fiscal,
            string? id_csosn_fiscal,
            string? id_cfop_fiscal,
            string? ipi_credito,
            string? icms_credito,
            string? aliq_icms,
            string? perc_reducao_icms,
            string? aliquota_st,
            string? margem_st,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_config_tributaria_detalhe =
               ConvertToInt32Validation.IsValid(id_config_tributaria_detalhe, "id_config_tributaria_detalhe", listValidations) ?
               Convert.ToInt32(id_config_tributaria_detalhe) :
               0;

            this.id_config_tributaria =
               ConvertToInt32Validation.IsValid(id_config_tributaria, "id_config_tributaria", listValidations) ?
               Convert.ToInt32(id_config_tributaria) :
               0;

            this.id_classe_fiscal =
               ConvertToInt32Validation.IsValid(id_classe_fiscal, "id_classe_fiscal", listValidations) ?
               Convert.ToInt32(id_classe_fiscal) :
               0;

            this.id_cst_icms_fiscal =
               ConvertToInt32Validation.IsValid(id_cst_icms_fiscal, "id_cst_icms_fiscal", listValidations) ?
               Convert.ToInt32(id_cst_icms_fiscal) :
               0;

            this.id_csosn_fiscal =
               ConvertToInt32Validation.IsValid(id_csosn_fiscal, "id_csosn_fiscal", listValidations) ?
               Convert.ToInt32(id_csosn_fiscal) :
               0;

            this.id_cfop_fiscal =
               ConvertToInt32Validation.IsValid(id_cfop_fiscal, "id_cfop_fiscal", listValidations) ?
               Convert.ToInt32(id_cfop_fiscal) :
               0;

            this.aliq_icms =
                ConvertToDecimalValidation.IsValid(aliq_icms, "aliq_icms", listValidations) ?
                Convert.ToDecimal(aliq_icms, new CultureInfo("en-US")) :
                0;

            this.perc_reducao_icms =
                ConvertToDecimalValidation.IsValid(perc_reducao_icms, "perc_reducao_icms", listValidations) ?
                Convert.ToDecimal(perc_reducao_icms, new CultureInfo("en-US")) :
                0;

            this.aliquota_st =
                ConvertToDecimalValidation.IsValid(aliquota_st, "aliquota_st", listValidations) ?
                Convert.ToDecimal(aliquota_st, new CultureInfo("en-US")) :
                0;

            this.margem_st =
                ConvertToDecimalValidation.IsValid(margem_st, "margem_st", listValidations) ?
                Convert.ToDecimal(margem_st, new CultureInfo("en-US")) :
                0;

            this.icms_credito =
                ConvertToBooleanValidation.IsValid(icms_credito, "icms_credito", listValidations) ?
                Convert.ToBoolean(icms_credito) :
                false;

            this.ipi_credito =
                ConvertToBooleanValidation.IsValid(ipi_credito, "ipi_credito", listValidations) ?
                Convert.ToBoolean(ipi_credito) :
                false;

            this.portal =
               ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
               Convert.ToInt32(portal) :
               0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.cod_natureza_operacao = cod_natureza_operacao;
        }
    }
}
