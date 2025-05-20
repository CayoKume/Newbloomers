using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxOticoPrismaDescricao
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_otico_prisma_descricao { get; private set; }

        [LengthValidation(length: 10, propertyName: "descricao")]
        public string? descricao { get; private set; }

        public Int32? portal { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxOticoPrismaDescricao() { }

        public LinxOticoPrismaDescricao(
            List<ValidationResult> listValidations,
            string? id_otico_prisma_descricao,
            string? descricao,
            string? portal,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_otico_prisma_descricao =
                ConvertToInt32Validation.IsValid(id_otico_prisma_descricao, "id_otico_prisma_descricao", listValidations) ?
                Convert.ToInt32(id_otico_prisma_descricao) :
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
