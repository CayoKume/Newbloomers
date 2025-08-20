
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoRemessas
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_remessas { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? empresa { get; private set; }
        public Int32? id_tipo { get; private set; }
        public Guid? identificador_remessa { get; private set; }
        public Int32? status { get; private set; }
        public string? status_descricao { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoRemessas() { }

        public LinxMovimentoRemessas(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoRemessas record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.id_remessas = CustomConvertersExtensions.ConvertToInt32Validation(record.id_remessas);
            this.id_tipo = CustomConvertersExtensions.ConvertToInt32Validation(record.id_tipo);
            this.status = CustomConvertersExtensions.ConvertToInt32Validation(record.status);
            this.identificador_remessa = Guid.Parse(record.identificador_remessa);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.status_descricao = record.status_descricao;
        }
    }
}
