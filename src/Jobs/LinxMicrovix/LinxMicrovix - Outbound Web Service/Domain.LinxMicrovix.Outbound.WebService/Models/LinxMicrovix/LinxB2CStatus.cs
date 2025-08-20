using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxB2CStatus
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime lastupdateon { get; private set; }

        public Int32? id_status { get; private set; }

        [LengthValidation(length: 30, propertyName: "descricao_status")]
        public string? descricao_status { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxB2CStatus() { }

        public LinxB2CStatus(
            List<ValidationResult> listValidations,
            string? id_status,
            string? descricao_status,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_status =
                ConvertToInt32Validation.IsValid(id_status, "id_status", listValidations) ?
                Convert.ToInt32(id_status) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao_status = descricao_status;
            this.recordKey = $"[{id_status}]|[{timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
