using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxListaDaVez", Schema = "untreated")]
    public class LinxListaDaVez
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? cod_vendedor { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data { get; private set; }

        [Column(TypeName = "varchar(103)")]
        [LengthValidation(length: 103, propertyName: "motivo_nao_venda")]
        public string? motivo_nao_venda { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtde_ocorrencias { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_hora_ini_atend { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_hora_fim_atend { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? obs { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "desc_produto_neg")]
        public string? desc_produto_neg { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_produto_neg { get; private set; }

        public LinxListaDaVez() { }

        public LinxListaDaVez(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? cod_vendedor,
            string? data,
            string? motivo_nao_venda,
            string? qtde_ocorrencias,
            string? data_hora_ini_atend,
            string? data_hora_fim_atend,
            string? obs,
            string? desc_produto_neg,
            string? valor_produto_neg
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.cod_vendedor =
                ConvertToInt32Validation.IsValid(cod_vendedor, "cod_vendedor", listValidations) ?
                Convert.ToInt32(cod_vendedor) :
                0;

            this.qtde_ocorrencias =
                ConvertToInt32Validation.IsValid(qtde_ocorrencias, "qtde_ocorrencias", listValidations) ?
                Convert.ToInt32(qtde_ocorrencias) :
                0;

            this.valor_produto_neg =
                ConvertToDecimalValidation.IsValid(valor_produto_neg, "valor_produto_neg", listValidations) ?
                Convert.ToDecimal(valor_produto_neg) :
                0;

            this.data =
                ConvertToDateTimeValidation.IsValid(data, "data", listValidations) ?
                Convert.ToDateTime(data) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_hora_ini_atend =
                ConvertToDateTimeValidation.IsValid(data_hora_ini_atend, "data_hora_ini_atend", listValidations) ?
                Convert.ToDateTime(data_hora_ini_atend) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_hora_fim_atend =
                ConvertToDateTimeValidation.IsValid(data_hora_fim_atend, "data_hora_fim_atend", listValidations) ?
                Convert.ToDateTime(data_hora_fim_atend) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.obs = obs;
            this.cnpj_emp = cnpj_emp;
            this.motivo_nao_venda = motivo_nao_venda;
            this.desc_produto_neg = desc_produto_neg;
        }
    }
}
