using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxLancContabil
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? cod_lanc { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "centro_custo")]
        public string? centro_custo { get; private set; }

        [Column(TypeName = "varchar(150)")]
        [LengthValidation(length: 150, propertyName: "ind_conta")]
        public string? ind_conta { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? cod_conta { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "nome_conta")]
        public string? nome_conta { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_conta { get; private set; }

        [Column(TypeName = "varchar(1)")]
        [LengthValidation(length: 1, propertyName: "cred_deb")]
        public string? cred_deb { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_lanc { get; private set; }

        [Column(TypeName = "varchar(500)")]
        [LengthValidation(length: 500, propertyName: "compl_conta")]
        public string? compl_conta { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? cod_historico { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "desc_historico")]
        public string? desc_historico { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_compensacao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? fatura_origem { get; private set; }

        [Column(TypeName = "varchar(1)")]
        [LengthValidation(length: 1, propertyName: "efetivado")]
        public string? efetivado { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? id_lanc { get; private set; }

        [Column(TypeName = "varchar(1)")]
        [LengthValidation(length: 1, propertyName: "cancelado")]
        public string? cancelado { get; private set; }

        public LinxLancContabil() { }

        public LinxLancContabil(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? cod_lanc,
            string? centro_custo,
            string? ind_conta,
            string? cod_conta,
            string? nome_conta,
            string? valor_conta,
            string? cred_deb,
            string? data_lanc,
            string? compl_conta,
            string? identificador,
            string? cod_historico,
            string? desc_historico,
            string? data_compensacao,
            string? fatura_origem,
            string? efetivado,
            string? timestamp,
            string? empresa,
            string? id_lanc,
            string? cancelado
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.fatura_origem =
                ConvertToInt32Validation.IsValid(fatura_origem, "fatura_origem", listValidations) ?
                Convert.ToInt32(fatura_origem) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.cod_lanc =
                ConvertToInt64Validation.IsValid(cod_lanc, "cod_lanc", listValidations) ?
                Convert.ToInt64(cod_lanc) :
                0;

            this.cod_conta =
                ConvertToInt64Validation.IsValid(cod_conta, "cod_conta", listValidations) ?
                Convert.ToInt64(cod_conta) :
                0;

            this.cod_historico =
                ConvertToInt64Validation.IsValid(cod_historico, "cod_historico", listValidations) ?
                Convert.ToInt64(cod_historico) :
                0;

            this.id_lanc =
                ConvertToInt64Validation.IsValid(id_lanc, "id_lanc", listValidations) ?
                Convert.ToInt64(id_lanc) :
                0;

            this.valor_conta =
                ConvertToDecimalValidation.IsValid(valor_conta, "valor_conta", listValidations) ?
                Convert.ToDecimal(valor_conta) :
                0;

            this.data_lanc =
                ConvertToDateTimeValidation.IsValid(data_lanc, "data_lanc", listValidations) ?
                Convert.ToDateTime(data_lanc) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_compensacao =
                ConvertToDateTimeValidation.IsValid(data_compensacao, "data_compensacao", listValidations) ?
                Convert.ToDateTime(data_compensacao) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.cancelado = cancelado;
            this.efetivado = efetivado;
            this.desc_historico = desc_historico;
            this.compl_conta = compl_conta;
            this.cred_deb = cred_deb;
            this.nome_conta = nome_conta;
            this.ind_conta = ind_conta;
            this.centro_custo = centro_custo;
            this.cnpj_emp = cnpj_emp;
        }
    }
}
