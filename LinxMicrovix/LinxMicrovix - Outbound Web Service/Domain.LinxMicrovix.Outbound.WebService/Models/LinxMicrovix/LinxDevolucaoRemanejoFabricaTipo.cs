using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaTipo
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_devolucao_remanejo_fabrica_tipo { get; private set; }

        [LengthValidation(length: 100, propertyName: "descricao")]
        public string? descricao { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxDevolucaoRemanejoFabricaTipo() { }

        public LinxDevolucaoRemanejoFabricaTipo(
            List<ValidationResult> listValidations,
            string? id_devolucao_remanejo_fabrica_tipo,
            string? descricao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_devolucao_remanejo_fabrica_tipo =
                ConvertToInt32Validation.IsValid(id_devolucao_remanejo_fabrica_tipo, "id_devolucao_remanejo_fabrica_tipo", listValidations) ?
                Convert.ToInt32(id_devolucao_remanejo_fabrica_tipo) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao = descricao;
        }
    }
}
