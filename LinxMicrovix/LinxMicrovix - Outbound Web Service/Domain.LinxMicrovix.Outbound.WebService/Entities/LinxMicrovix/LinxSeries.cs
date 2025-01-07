using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxSeries
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Key]
        [Column(TypeName = "varchar(10)")]
        [LengthValidation(length: 10, propertyName: "serie")]
        public string? serie { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_modelo_nf { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxSeries() { }

        public LinxSeries(
            List<ValidationResult> listValidations,
            string? portal,
            string? serie,
            string? id_modelo_nf,
            string? timestamp
        )
        {
            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.id_modelo_nf =
                ConvertToInt32Validation.IsValid(id_modelo_nf, "id_modelo_nf", listValidations) ?
                Convert.ToInt32(id_modelo_nf) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.serie = serie;
        }
    }
}
