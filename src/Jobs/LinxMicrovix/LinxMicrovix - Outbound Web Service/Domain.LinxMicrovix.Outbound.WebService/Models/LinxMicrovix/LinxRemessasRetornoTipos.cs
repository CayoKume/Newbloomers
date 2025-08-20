using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxRemessasRetornoTipos
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_remessa_retorno_tipos { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 50, propertyName: "descricao")]
        public string? descricao { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxRemessasRetornoTipos() { }

        public LinxRemessasRetornoTipos(
            List<ValidationResult> listValidations,
            string? id_remessa_retorno_tipos,
            string? portal,
            string? descricao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_remessa_retorno_tipos =
                ConvertToInt32Validation.IsValid(id_remessa_retorno_tipos, "id_remessa_retorno_tipos", listValidations) ?
                Convert.ToInt32(id_remessa_retorno_tipos) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao = descricao;
        }
    }
}
