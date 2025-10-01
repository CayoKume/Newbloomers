
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxNcm
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? codigo { get; private set; }
        public string? descricao { get; private set; }
        public Int32? codigo_genero { get; private set; }
        public bool? ativo { get; private set; }
        public Int32? id_ncm { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxNcm() { }

        public LinxNcm(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxNcm record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.ativo = CustomConvertersExtensions.ConvertToBooleanValidation(record.ativo);
            this.codigo_genero = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_genero);
            this.id_ncm = CustomConvertersExtensions.ConvertToInt32Validation(record.id_ncm);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.codigo = record.codigo;
            this.descricao = record.descricao;
        }
    }
}
