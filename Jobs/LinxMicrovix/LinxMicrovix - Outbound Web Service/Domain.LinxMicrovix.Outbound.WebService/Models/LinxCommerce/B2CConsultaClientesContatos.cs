using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaClientesContatos
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_clientes_contatos { get; private set; }
        public Int32? id_contato_b2c { get; private set; }
        public string? nome_contato { get; private set; }
        public DateTime? data_nasc_contato { get; private set; }
        public string? sexo_contato { get; private set; }
        public Int32? id_parentesco { get; private set; }
        public string? fone_contato { get; private set; }
        public string? celular_contato { get; private set; }
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
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaClientesContatos record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_clientes_contatos = CustomConvertersExtensions.ConvertToInt32Validation(record.id_clientes_contatos);
            this.id_contato_b2c = CustomConvertersExtensions.ConvertToInt32Validation(record.id_contato_b2c);
            this.id_parentesco = CustomConvertersExtensions.ConvertToInt32Validation(record.id_parentesco);
            this.cod_cliente_erp = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_cliente_erp);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.data_nasc_contato = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_nasc_contato);

            this.nome_contato = record.nome_contato;
            this.sexo_contato = record.sexo_contato;
            this.fone_contato = record.fone_contato;
            this.celular_contato = record.celular_contato;
            this.email_contato = record.email_contato;
            this.recordXml = recordXml;
        }
    }
}
