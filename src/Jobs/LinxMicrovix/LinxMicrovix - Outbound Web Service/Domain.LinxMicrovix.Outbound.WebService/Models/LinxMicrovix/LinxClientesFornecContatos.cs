
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxClientesFornecContatos
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32 portal { get; private set; }
        public Int32 cod_cliente { get; private set; }
        public string? nome_contato { get; private set; }
        public string? sexo_contato { get; private set; }
        public Int32 contatos_clientes_parentesco { get; private set; }
        public string? fone1_contato { get; private set; }
        public string? fone2_contato { get; private set; }
        public string? celular_contato { get; private set; }
        public string? email_contato { get; private set; }
        public DateTime data_nasc_contato { get; private set; }
        public string? tipo_contato { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxClientesFornecContatos() { }

        public LinxClientesFornecContatos(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxClientesFornecContatos record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.cod_cliente = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_cliente);
            this.contatos_clientes_parentesco = CustomConvertersExtensions.ConvertToInt32Validation(record.contatos_clientes_parentesco);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.data_nasc_contato =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_nasc_contato);
            this.nome_contato = record.nome_contato;
            this.sexo_contato = record.sexo_contato;
            this.fone1_contato = record.fone1_contato;
            this.fone2_contato = record.fone2_contato;
            this.celular_contato = record.celular_contato;
            this.email_contato = record.email_contato;
            this.tipo_contato = record.tipo_contato;
        }
    }
}
