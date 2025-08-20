
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxConfiguracoesTributariasEmpresas
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? id_config_tributaria { get; private set; }
        public Int32? empresa { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxConfiguracoesTributariasEmpresas() { }

        public LinxConfiguracoesTributariasEmpresas(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxConfiguracoesTributariasEmpresas record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_config_tributaria = CustomConvertersExtensions.ConvertToInt32Validation(record.id_config_tributaria);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            
        }
    }
}
