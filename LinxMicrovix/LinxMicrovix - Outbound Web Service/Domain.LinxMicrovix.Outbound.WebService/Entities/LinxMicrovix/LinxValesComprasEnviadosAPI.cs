using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxValesComprasEnviadosAPI
    {
        [NotMapped]
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? numero_controle { get; private set; }

        public decimal? valor_vale { get; private set; }

        [LengthValidation(length: 14, propertyName: "doc_cliente")]
        public string? doc_cliente { get; private set; }

        public Int32? status_vale { get; private set; }

        public Int32? codigo_portal_resgate { get; private set; }

        public Int32? codigo_empresa_resgate { get; private set; }

        public Int32? codigo_usuario_resgate { get; private set; }

        public Int32? codigo_vale_empresa_resgate { get; private set; }

        public DateTime? data_criacao { get; private set; }

        public Int64? timestamp { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj_empresa_resgate")]
        public string? cnpj_empresa_resgate { get; private set; }

        public DateTime? data_resgate { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxValesComprasEnviadosAPI() { }

        public LinxValesComprasEnviadosAPI(
            List<ValidationResult> listValidations,
            string? numero_controle,
            string? valor_vale,
            string? doc_cliente,
            string? status_vale,
            string? codigo_portal_resgate,
            string? codigo_empresa_resgate,
            string? codigo_usuario_resgate,
            string? codigo_vale_empresa_resgate,
            string? data_criacao,
            string? timestamp,
            string? cnpj_empresa_resgate,
            string? data_resgate
        )
        {
            lastupdateon = DateTime.Now;

            this.numero_controle =
                ConvertToInt32Validation.IsValid(numero_controle, "numero_controle", listValidations) ?
                Convert.ToInt32(numero_controle) :
                0;

            this.status_vale =
                ConvertToInt32Validation.IsValid(status_vale, "status_vale", listValidations) ?
                Convert.ToInt32(status_vale) :
                0;

            this.codigo_portal_resgate =
                ConvertToInt32Validation.IsValid(codigo_portal_resgate, "codigo_portal_resgate", listValidations) ?
                Convert.ToInt32(codigo_portal_resgate) :
                0;

            this.codigo_empresa_resgate =
                ConvertToInt32Validation.IsValid(codigo_empresa_resgate, "codigo_empresa_resgate", listValidations) ?
                Convert.ToInt32(codigo_empresa_resgate) :
                0;

            this.codigo_usuario_resgate =
                ConvertToInt32Validation.IsValid(codigo_usuario_resgate, "codigo_usuario_resgate", listValidations) ?
                Convert.ToInt32(codigo_usuario_resgate) :
                0;

            this.codigo_vale_empresa_resgate =
                ConvertToInt32Validation.IsValid(codigo_vale_empresa_resgate, "codigo_vale_empresa_resgate", listValidations) ?
                Convert.ToInt32(codigo_vale_empresa_resgate) :
                0;

            this.data_criacao =
                ConvertToDateTimeValidation.IsValid(data_criacao, "data_criacao", listValidations) ?
                Convert.ToDateTime(data_criacao) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_resgate =
                ConvertToDateTimeValidation.IsValid(data_resgate, "data_resgate", listValidations) ?
                Convert.ToDateTime(data_resgate) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.valor_vale =
                ConvertToDecimalValidation.IsValid(valor_vale, "valor_vale", listValidations) ?
                Convert.ToDecimal(valor_vale, new CultureInfo("en-US")) :
                0;

            this.doc_cliente = doc_cliente;
            this.cnpj_empresa_resgate = cnpj_empresa_resgate;
        }
    }
}
