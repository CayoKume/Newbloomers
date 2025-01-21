using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    [Table("B2CConsultaEmpresas", Schema = "linx_microvix_commerce")]
    public class B2CConsultaEmpresas
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "nome_emp")]
        public string? nome_emp { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "varchar(250)")]
        [LengthValidation(length: 250, propertyName: "end_unidade")]
        public string? end_unidade { get; private set; }

        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "complemento_end_unidade")]
        public string? complemento_end_unidade { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "nr_rua_unidade")]
        public string? nr_rua_unidade { get; private set; }

        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "bairro_unidade")]
        public string? bairro_unidade { get; private set; }

        [Column(TypeName = "varchar(9)")]
        [LengthValidation(length: 9, propertyName: "cep_unidade")]
        public string? cep_unidade { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "cidade_unidade")]
        public string? cidade_unidade { get; private set; }

        [Column(TypeName = "char(2)")]
        [LengthValidation(length: 2, propertyName: "uf_unidade")]
        public string? uf_unidade { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "email_unidade")]
        public string? email_unidade { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_criacao { get; private set; }

        [Column(TypeName = "bit")]
        public bool? centro_distribuicao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaEmpresas() { }

        public B2CConsultaEmpresas(
            List<ValidationResult> listValidations,
            string? empresa,
            string? nome_emp,
            string? cnpj_emp,
            string? end_unidade,
            string? complemento_end_unidade,
            string? nr_rua_unidade,
            string? bairro_unidade,
            string? cep_unidade,
            string? cidade_unidade,
            string? uf_unidade,
            string? email_unidade,
            string? timestamp,
            string? data_criacao,
            string? centro_distribuicao,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.data_criacao =
                ConvertToDateTimeValidation.IsValid(data_criacao, "data_criacao", listValidations) ?
                Convert.ToDateTime(data_criacao) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.centro_distribuicao =
                ConvertToBooleanValidation.IsValid(centro_distribuicao, "centro_distribuicao", listValidations) ?
                Convert.ToBoolean(centro_distribuicao) :
                false;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_emp = nome_emp;
            this.cnpj_emp = cnpj_emp;
            this.end_unidade = end_unidade;
            this.complemento_end_unidade = complemento_end_unidade;
            this.nr_rua_unidade = nr_rua_unidade;
            this.bairro_unidade = bairro_unidade;
            this.cep_unidade = cep_unidade;
            this.cidade_unidade = cidade_unidade;
            this.uf_unidade = uf_unidade;
            this.email_unidade = end_unidade;
        }
    }
}
