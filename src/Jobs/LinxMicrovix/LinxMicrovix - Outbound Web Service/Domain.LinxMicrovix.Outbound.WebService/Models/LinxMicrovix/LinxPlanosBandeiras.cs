
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxPlanosBandeiras
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? plano { get; private set; }
        public Int32? portal { get; private set; }
        public string? bandeira { get; private set; }
        public string? tipo_bandeira { get; private set; }
        public Int32? adquirente { get; private set; }
        public string? nome_adquirente { get; private set; }
        public string? codigo_bandeira_sitef { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxPlanosBandeiras() { }

        public LinxPlanosBandeiras(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxPlanosBandeiras record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.plano = CustomConvertersExtensions.ConvertToInt32Validation(record.plano);
            this.adquirente = CustomConvertersExtensions.ConvertToInt32Validation(record.adquirente);
            this.bandeira = record.bandeira;
            this.tipo_bandeira = record.tipo_bandeira;
            this.nome_adquirente = record.nome_adquirente;
            this.codigo_bandeira_sitef = record.codigo_bandeira_sitef;
        }
    }
}
