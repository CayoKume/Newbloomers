using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxLojas", Schema = "linx_microvix_erp")]
    public class LinxLojas
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        public Int32? empresa { get; private set; }

        [LengthValidation(length: 50, propertyName: "nome_emp")]
        public string? nome_emp { get; private set; }

        [LengthValidation(length: 200, propertyName: "razao_emp")]
        public string? razao_emp { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        [LengthValidation(length: 20, propertyName: "inscricao_emp")]
        public string? inscricao_emp { get; private set; }

        [LengthValidation(length: 250, propertyName: "endereco_emp")]
        public string? endereco_emp { get; private set; }

        public Int32? num_emp { get; private set; }

        [LengthValidation(length: 60, propertyName: "complement_emp")]
        public string? complement_emp { get; private set; }

        [LengthValidation(length: 50, propertyName: "bairro_emp")]
        public string? bairro_emp { get; private set; }

        [LengthValidation(length: 9, propertyName: "cep_emp")]
        public string? cep_emp { get; private set; }

        [LengthValidation(length: 50, propertyName: "cidade_emp")]
        public string? cidade_emp { get; private set; }

        [LengthValidation(length: 2, propertyName: "estado_emp")]
        public string? estado_emp { get; private set; }

        [LengthValidation(length: 70, propertyName: "fone_emp")]
        public string? fone_emp { get; private set; }

        [LengthValidation(length: 50, propertyName: "email_emp")]
        public string? email_emp { get; private set; }

        public Int32? cod_ibge_municipio { get; private set; }

        public DateTime? data_criacao_emp { get; private set; }

        public DateTime? data_criacao_portal { get; private set; }

        [LengthValidation(length: 1, propertyName: "sistema_tributacao")]
        public string? sistema_tributacao { get; private set; }

        public Int32? regime_tributario { get; private set; }

        public decimal? area_empresa { get; private set; }

        public Int64? timestamp { get; private set; }

        [LengthValidation(length: 10, propertyName: "sigla_empresa")]
        public string? sigla_empresa { get; private set; }

        public Int32? id_classe_fiscal { get; private set; }

        public bool? centro_distribuicao { get; private set; }

        [LengthValidation(length: 30, propertyName: "inscricao_municipal_emp")]
        public string? inscricao_municipal_emp { get; private set; }

        [LengthValidation(length: 7, propertyName: "cnae_emp")]
        public string? cnae_emp { get; private set; }

        [LengthValidation(length: 6, propertyName: "cod_cliente_linx")]
        public string? cod_cliente_linx { get; private set; }

        public Int32? tabela_preco_preferencial { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxLojas() { }

        public LinxLojas(
            List<ValidationResult> listValidations,
            string? portal,
            string? empresa,
            string? nome_emp,
            string? razao_emp,
            string? cnpj_emp,
            string? inscricao_emp,
            string? endereco_emp,
            string? num_emp,
            string? complement_emp,
            string? bairro_emp,
            string? cep_emp,
            string? cidade_emp,
            string? estado_emp,
            string? fone_emp,
            string? email_emp,
            string? cod_ibge_municipio,
            string? data_criacao_emp,
            string? data_criacao_portal,
            string? sistema_tributacao,
            string? regime_tributario,
            string? area_empresa,
            string? timestamp,
            string? sigla_empresa,
            string? id_classe_fiscal,
            string? centro_distribuicao,
            string? inscricao_municipal_emp,
            string? cnae_emp,
            string? cod_cliente_linx,
            string? tabela_preco_preferencial,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.num_emp =
                ConvertToInt32Validation.IsValid(num_emp, "num_emp", listValidations) ?
                Convert.ToInt32(num_emp) :
                0;

            this.cod_ibge_municipio =
                ConvertToInt32Validation.IsValid(cod_ibge_municipio, "cod_ibge_municipio", listValidations) ?
                Convert.ToInt32(cod_ibge_municipio) :
                0;

            this.regime_tributario =
                ConvertToInt32Validation.IsValid(regime_tributario, "regime_tributario", listValidations) ?
                Convert.ToInt32(regime_tributario) :
                0;

            this.id_classe_fiscal =
                ConvertToInt32Validation.IsValid(id_classe_fiscal, "id_classe_fiscal", listValidations) ?
                Convert.ToInt32(id_classe_fiscal) :
                0;

            this.tabela_preco_preferencial =
                ConvertToInt32Validation.IsValid(tabela_preco_preferencial, "tabela_preco_preferencial", listValidations) ?
                Convert.ToInt32(tabela_preco_preferencial) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.area_empresa =
                ConvertToDecimalValidation.IsValid(area_empresa, "area_empresa", listValidations) ?
                Convert.ToDecimal(area_empresa, new CultureInfo("en-US")) :
                0;

            this.centro_distribuicao =
                ConvertToBooleanValidation.IsValid(centro_distribuicao, "centro_distribuicao", listValidations) ?
                Convert.ToBoolean(centro_distribuicao) :
                false;

            this.data_criacao_emp =
                ConvertToDateTimeValidation.IsValid(data_criacao_emp, "data_criacao_emp", listValidations) ?
                Convert.ToDateTime(data_criacao_emp) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_criacao_portal =
                ConvertToDateTimeValidation.IsValid(data_criacao_portal, "data_criacao_portal", listValidations) ?
                Convert.ToDateTime(data_criacao_portal) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.cidade_emp = cidade_emp;
            this.cnae_emp = cnae_emp;
            this.inscricao_municipal_emp = inscricao_municipal_emp;
            this.sigla_empresa = sigla_empresa;
            this.sistema_tributacao = sistema_tributacao;
            this.email_emp = email_emp;
            this.fone_emp = fone_emp;
            this.estado_emp = estado_emp;
            this.cep_emp = cep_emp;
            this.bairro_emp = bairro_emp;
            this.complement_emp = complement_emp;
            this.endereco_emp = endereco_emp;
            this.inscricao_emp = inscricao_emp;
            this.cnae_emp = cnae_emp;
            this.razao_emp = razao_emp;
            this.nome_emp = nome_emp;
            this.cnpj_emp = cnpj_emp;
            this.cod_cliente_linx = cod_cliente_linx;
            this.recordKey = $"[{empresa}]|[{cnpj_emp}]|[{timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
