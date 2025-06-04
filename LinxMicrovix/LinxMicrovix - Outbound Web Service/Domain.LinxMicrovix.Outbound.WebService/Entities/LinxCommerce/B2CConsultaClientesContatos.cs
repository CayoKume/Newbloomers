using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce
{
    public class B2CConsultaClientesContatos
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_clientes_contatos { get; private set; }

        public Int32? id_contato_b2c { get; private set; }

        [LengthValidation(length: 50, propertyName: "nome_contato")]
        public string? nome_contato { get; private set; }

        public DateTime? data_nasc_contato { get; private set; }

        [LengthValidation(length: 1, propertyName: "sexo_contato")]
        public string? sexo_contato { get; private set; }

        public Int32? id_parentesco { get; private set; }

        [LengthValidation(length: 20, propertyName: "fone_contato")]
        public string? fone_contato { get; private set; }

        [LengthValidation(length: 20, propertyName: "celular_contato")]
        public string? celular_contato { get; private set; }

        [LengthValidation(length: 50, propertyName: "email_contato")]
        public string? email_contato { get; private set; }

        public int? cod_cliente_erp { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaClientesContatos() { }

        public B2CConsultaClientesContatos(
            List<ValidationResult> listValidations,
            string? id_clientes_contatos,
            string? id_contato_b2c,
            string? nome_contato,
            string? data_nasc_contato,
            string? sexo_contato,
            string? id_parentesco,
            string? fone_contato,
            string? celular_contato,
            string? email_contato,
            string? cod_cliente_erp,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_clientes_contatos =
                ConvertToInt32Validation.IsValid(id_clientes_contatos, "id_clientes_contatos", listValidations) ?
                Convert.ToInt32(id_clientes_contatos) :
                0;

            this.id_contato_b2c =
                ConvertToInt32Validation.IsValid(id_contato_b2c, "id_contato_b2c", listValidations) ?
                Convert.ToInt32(id_contato_b2c) :
                0;

            this.id_parentesco =
                ConvertToInt32Validation.IsValid(id_parentesco, "id_parentesco", listValidations) ?
                Convert.ToInt32(id_parentesco) :
                0;

            this.cod_cliente_erp =
                ConvertToInt32Validation.IsValid(cod_cliente_erp, "cod_cliente_erp", listValidations) ?
                Convert.ToInt32(cod_cliente_erp) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.data_nasc_contato =
                ConvertToDateTimeValidation.IsValid(data_nasc_contato, "data_nasc_contato", listValidations) ?
                Convert.ToDateTime(data_nasc_contato) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.nome_contato = nome_contato;
            this.sexo_contato = sexo_contato;
            this.fone_contato = fone_contato;
            this.celular_contato = celular_contato;
            this.email_contato = email_contato;
            this.recordXml = recordXml;
        }
    }
}
