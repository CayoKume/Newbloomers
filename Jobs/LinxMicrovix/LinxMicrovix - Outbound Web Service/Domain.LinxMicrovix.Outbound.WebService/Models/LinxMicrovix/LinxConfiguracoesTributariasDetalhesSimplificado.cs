
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxConfiguracoesTributariasDetalhesSimplificado
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? id_config_tributaria_detalhe { get; private set; }
        public Int32? id_config_tributaria { get; private set; }
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

        public LinxConfiguracoesTributariasDetalhesSimplificado(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxConfiguracoesTributariasDetalhesSimplificado record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_config_tributaria_detalhe = CustomConvertersExtensions.ConvertToInt32Validation(record.id_config_tributaria_detalhe);
            this.id_config_tributaria = CustomConvertersExtensions.ConvertToInt32Validation(record.id_config_tributaria);
            this.id_classe_fiscal = CustomConvertersExtensions.ConvertToInt32Validation(record.id_classe_fiscal);
            this.id_cst_icms_fiscal = CustomConvertersExtensions.ConvertToInt32Validation(record.id_cst_icms_fiscal);
            this.id_csosn_fiscal = CustomConvertersExtensions.ConvertToInt32Validation(record.id_csosn_fiscal);
            this.id_cfop_fiscal = CustomConvertersExtensions.ConvertToInt32Validation(record.id_cfop_fiscal);
            this.aliq_icms = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliq_icms);
            this.perc_reducao_icms = CustomConvertersExtensions.ConvertToDecimalValidation(record.perc_reducao_icms);
            this.aliquota_st = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliquota_st);
            this.margem_st = CustomConvertersExtensions.ConvertToDecimalValidation(record.margem_st);
            this.icms_credito = CustomConvertersExtensions.ConvertToBooleanValidation(record.icms_credito);
            this.ipi_credito = CustomConvertersExtensions.ConvertToBooleanValidation(record.ipi_credito);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.cod_natureza_operacao = record.cod_natureza_operacao;
        }
    }
}
