using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxTradeinParceiro
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        public Int32? id_tradein_parceiro { get; private set; }

        [LengthValidation(length: 100, propertyName: "nome_parceiro")]
        public string? nome_parceiro { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxTradeinParceiro() { }

        public LinxTradeinParceiro(
            List<ValidationResult> listValidations,
            string? portal,
            string? id_tradein_parceiro,
            string? nome_parceiro,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.id_tradein_parceiro =
                ConvertToInt32Validation.IsValid(id_tradein_parceiro, "id_tradein_parceiro", listValidations) ?
                Convert.ToInt32(id_tradein_parceiro) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_parceiro = nome_parceiro;
        }
    }
}
