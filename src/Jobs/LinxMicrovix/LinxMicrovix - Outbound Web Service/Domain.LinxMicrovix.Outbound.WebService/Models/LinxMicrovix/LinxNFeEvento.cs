
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxNFeEvento
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int32? id_nfe_evento { get; private set; }
        public Int32? id_nfe { get; private set; }
        public string? codigo_tipo { get; private set; }
        public string? xml { get; private set; }
        public Int64? timestamp { get; private set; }
        public DateTime? data_emissao { get; private set; }
        public string? hora_emissao { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxNFeEvento() { }

        public LinxNFeEvento(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxNFeEvento record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.id_nfe_evento = CustomConvertersExtensions.ConvertToInt32Validation(record.id_nfe_evento);
            this.id_nfe = CustomConvertersExtensions.ConvertToInt32Validation(record.id_nfe);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.data_emissao =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_emissao);
            this.hora_emissao = record.hora_emissao;
            this.xml = record.xml;
            this.codigo_tipo = record.codigo_tipo;
            this.cnpj_emp = record.cnpj_emp;
        }
    }
}
