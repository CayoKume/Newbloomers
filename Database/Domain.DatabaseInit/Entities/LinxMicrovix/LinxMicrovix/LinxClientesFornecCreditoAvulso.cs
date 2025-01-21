using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxClientesFornecCreditoAvulso", Schema = "untreated")]
    public class LinxClientesFornecCreditoAvulso
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_cliente { get; private set; }

        [Column(TypeName = "int")]
        public Int32? controle { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public DateTime? data { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "cd")]
        public string? cd { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? motivo { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador { get; private set; }

        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        public LinxClientesFornecCreditoAvulso() { }

        public LinxClientesFornecCreditoAvulso(
            List<ValidationResult> listValidations,
            string? portal,
            string? empresa,
            string? cod_cliente,
            string? controle,
            string? data,
            string? cd,
            string? valor,
            string? motivo,
            string? timestamp,
            string? identificador,
            string? cnpj_emp
        )
        {
            lastupdateon = DateTime.Now;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.cod_cliente =
                ConvertToInt32Validation.IsValid(cod_cliente, "cod_cliente", listValidations) ?
                Convert.ToInt32(cod_cliente) :
                0;

            this.controle =
                ConvertToInt32Validation.IsValid(controle, "controle", listValidations) ?
                Convert.ToInt32(controle) :
                0;

            this.data =
                ConvertToDateTimeValidation.IsValid(data, "data", listValidations) ?
                Convert.ToDateTime(data) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.valor =
                ConvertToDecimalValidation.IsValid(valor, "valor", listValidations) ?
                Convert.ToDecimal(valor) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.cd = cd;
            this.motivo = motivo;
            this.cnpj_emp = cnpj_emp;
        }
    }
}
