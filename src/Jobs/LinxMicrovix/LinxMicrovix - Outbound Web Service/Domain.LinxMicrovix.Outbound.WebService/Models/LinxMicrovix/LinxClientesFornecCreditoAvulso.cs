
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxClientesFornecCreditoAvulso
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? empresa { get; private set; }
        public Int32? cod_cliente { get; private set; }
        public Int32? controle { get; private set; }
        public DateTime? data { get; private set; }
        public string? cd { get; private set; }
        public decimal? valor { get; private set; }
        public string? motivo { get; private set; }
        public Int64? timestamp { get; private set; }
        public Guid? identificador { get; private set; }
        public string? cnpj_emp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxClientesFornecCreditoAvulso() { }

        public LinxClientesFornecCreditoAvulso(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxClientesFornecCreditoAvulso record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.cod_cliente = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_cliente);
            this.controle = CustomConvertersExtensions.ConvertToInt32Validation(record.controle);
            this.data =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data);
            this.identificador = Guid.Parse(record.identificador);
            this.valor = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.cd = record.cd;
            this.motivo = record.motivo;
            this.cnpj_emp = record.cnpj_emp;
        }
    }
}
