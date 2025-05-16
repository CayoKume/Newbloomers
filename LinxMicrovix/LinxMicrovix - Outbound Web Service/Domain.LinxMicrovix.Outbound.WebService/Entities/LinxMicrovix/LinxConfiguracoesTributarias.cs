using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxConfiguracoesTributarias
    {
        [NotMapped]
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        public Int32? id_config_tributaria { get; private set; }

        [LengthValidation(length: 100, propertyName: "desc_config_tributaria")]
        public string? desc_config_tributaria { get; private set; }

        [LengthValidation(length: 50, propertyName: "sigla_config_tributaria")]
        public string? sigla_config_tributaria { get; private set; }

        public Int64? timestamp { get; private set; }

        public bool? ativa { get; private set; }

        [LengthValidation(length: 2, propertyName: "uf")]
        public string? uf { get; private set; }

        [LengthValidation(length: 1, propertyName: "sistema_tributacao")]
        public string? sistema_tributacao { get; private set; }

        public Int32? tipo_atividade { get; private set; }

        public Int32? id_origem_mercadoria { get; private set; }

        public bool? utiliza_uso_consumo { get; private set; }

        public Int32? id_classificacao_cest_produto { get; private set; }

        [LengthValidation(length: 50, propertyName: "codigo_ws")]
        public string? codigo_ws { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxConfiguracoesTributarias() { }

        public LinxConfiguracoesTributarias(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? id_config_tributaria,
            string? desc_config_tributaria,
            string? sigla_config_tributaria,
            string? timestamp,
            string? ativa,
            string? uf,
            string? sistema_tributacao,
            string? tipo_atividade,
            string? id_origem_mercadoria,
            string? utiliza_uso_consumo,
            string? id_classificacao_cest_produto,
            string? codigo_ws
        )
        {
            lastupdateon = DateTime.Now;

            this.id_config_tributaria =
                ConvertToInt32Validation.IsValid(id_config_tributaria, "id_config_tributaria", listValidations) ?
                Convert.ToInt32(id_config_tributaria) :
                0;

            this.tipo_atividade =
                ConvertToInt32Validation.IsValid(tipo_atividade, "tipo_atividade", listValidations) ?
                Convert.ToInt32(tipo_atividade) :
                0;

            this.id_origem_mercadoria =
                ConvertToInt32Validation.IsValid(id_origem_mercadoria, "id_origem_mercadoria", listValidations) ?
                Convert.ToInt32(id_origem_mercadoria) :
                0;

            this.id_classificacao_cest_produto =
                ConvertToInt32Validation.IsValid(id_classificacao_cest_produto, "id_classificacao_cest_produto", listValidations) ?
                Convert.ToInt32(id_classificacao_cest_produto) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.ativa =
                ConvertToBooleanValidation.IsValid(ativa, "ativa", listValidations) ?
                Convert.ToBoolean(ativa) :
                false;

            this.utiliza_uso_consumo =
                ConvertToBooleanValidation.IsValid(utiliza_uso_consumo, "utiliza_uso_consumo", listValidations) ?
                Convert.ToBoolean(utiliza_uso_consumo) :
                false;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.cnpj_emp = cnpj_emp;
            this.desc_config_tributaria = desc_config_tributaria;
            this.uf = uf;
            this.sigla_config_tributaria = sigla_config_tributaria;
            this.sistema_tributacao = sistema_tributacao;
            this.codigo_ws = codigo_ws;
        }
    }
}
