using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxClientesFornecContatos
    {
        [NotMapped]
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32 portal { get; private set; }

        public Int32 cod_cliente { get; private set; }

        [LengthValidation(length: 50, propertyName: "nome_contato")]
        public string? nome_contato { get; private set; }

        [LengthValidation(length: 1, propertyName: "sexo_contato")]
        public string? sexo_contato { get; private set; }

        public Int32 contatos_clientes_parentesco { get; private set; }

        [LengthValidation(length: 20, propertyName: "fone1_contato")]
        public string? fone1_contato { get; private set; }

        [LengthValidation(length: 20, propertyName: "fone2_contato")]
        public string? fone2_contato { get; private set; }

        [LengthValidation(length: 20, propertyName: "celular_contato")]
        public string? celular_contato { get; private set; }

        [LengthValidation(length: 50, propertyName: "email_contato")]
        public string? email_contato { get; private set; }

        public DateTime data_nasc_contato { get; private set; }

        [LengthValidation(length: 20, propertyName: "tipo_contato")]
        public string? tipo_contato { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxClientesFornecContatos() { }

        public LinxClientesFornecContatos(
            List<ValidationResult> listValidations,
            string? portal,
            string? cod_cliente,
            string? nome_contato,
            string? sexo_contato,
            string? contatos_clientes_parentesco,
            string? fone1_contato,
            string? fone2_contato,
            string? celular_contato,
            string? email_contato,
            string? data_nasc_contato,
            string? tipo_contato
        )
        {
            lastupdateon = DateTime.Now;

            this.cod_cliente =
                ConvertToInt32Validation.IsValid(cod_cliente, "cod_cliente", listValidations) ?
                Convert.ToInt32(cod_cliente) :
                0;

            this.contatos_clientes_parentesco =
                ConvertToInt32Validation.IsValid(contatos_clientes_parentesco, "contatos_clientes_parentesco", listValidations) ?
                Convert.ToInt32(contatos_clientes_parentesco) :
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
            this.fone1_contato = fone1_contato;
            this.fone2_contato = fone2_contato;
            this.celular_contato = celular_contato;
            this.email_contato = email_contato;
            this.tipo_contato = tipo_contato;
        }
    }
}
