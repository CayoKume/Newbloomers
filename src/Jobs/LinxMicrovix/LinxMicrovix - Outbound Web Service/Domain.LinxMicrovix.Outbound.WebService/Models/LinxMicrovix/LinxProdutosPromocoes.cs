using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxProdutosPromocoes
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        public Int64? cod_produto { get; private set; }

        public decimal? preco_promocao { get; private set; }

        public DateTime? data_inicio_promocao { get; private set; }

        public DateTime? data_termino_promocao { get; private set; }

        public DateTime? data_cadastro_promocao { get; private set; }

        [LengthValidation(length: 1, propertyName: "promocao_ativa")]
        public string? promocao_ativa { get; private set; }

        public Int64? id_campanha { get; private set; }

        [LengthValidation(length: 60, propertyName: "nome_campanha")]
        public string? nome_campanha { get; private set; }

        public bool? promocao_opcional { get; private set; }

        public decimal? custo_total_campanha { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosPromocoes() { }

        public LinxProdutosPromocoes(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? cod_produto,
            string? preco_promocao,
            string? data_inicio_promocao,
            string? data_termino_promocao,
            string? data_cadastro_promocao,
            string? promocao_ativa,
            string? id_campanha,
            string? nome_campanha,
            string? promocao_opcional,
            string? custo_total_campanha,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.cod_produto =
                ConvertToInt64Validation.IsValid(cod_produto, "cod_produto", listValidations) ?
                Convert.ToInt64(cod_produto) :
                0;

            this.id_campanha =
                ConvertToInt64Validation.IsValid(id_campanha, "id_campanha", listValidations) ?
                Convert.ToInt64(id_campanha) :
                0;

            this.data_inicio_promocao =
               ConvertToDateTimeValidation.IsValid(data_inicio_promocao, "data_inicio_promocao", listValidations) ?
               Convert.ToDateTime(data_inicio_promocao) :
               new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_termino_promocao =
               ConvertToDateTimeValidation.IsValid(data_termino_promocao, "data_termino_promocao", listValidations) ?
               Convert.ToDateTime(data_termino_promocao) :
               new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_cadastro_promocao =
               ConvertToDateTimeValidation.IsValid(data_cadastro_promocao, "data_cadastro_promocao", listValidations) ?
               Convert.ToDateTime(data_cadastro_promocao) :
               new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.preco_promocao =
                ConvertToDecimalValidation.IsValid(preco_promocao, "preco_promocao", listValidations) ?
                Convert.ToDecimal(preco_promocao, new CultureInfo("en-US")) :
                0;

            this.custo_total_campanha =
                ConvertToDecimalValidation.IsValid(custo_total_campanha, "custo_total_campanha", listValidations) ?
                Convert.ToDecimal(custo_total_campanha, new CultureInfo("en-US")) :
                0;

            this.promocao_opcional =
                ConvertToBooleanValidation.IsValid(promocao_opcional, "promocao_opcional", listValidations) ?
                Convert.ToBoolean(promocao_opcional) :
                false;

            this.promocao_ativa = promocao_ativa;
            this.cnpj_emp = cnpj_emp;
            this.nome_campanha = nome_campanha;
            this.recordKey = $"[{portal}]|[{cnpj_emp}]|[{cod_produto}]|[{preco_promocao}]|[{data_inicio_promocao}]|[{data_termino_promocao}]|[{data_cadastro_promocao}]|[{promocao_ativa}]|[{id_campanha}]|[{nome_campanha}]|[{promocao_opcional}]|[{custo_total_campanha}]";
            this.recordXml = recordXml;
        }
    }
}
