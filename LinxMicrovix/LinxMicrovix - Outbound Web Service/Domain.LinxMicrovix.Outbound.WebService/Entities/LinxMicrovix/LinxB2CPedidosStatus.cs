using Domain.IntegrationsCore.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxB2CPedidosStatus", Schema = "linx_microvix_erp")]
    public class LinxB2CPedidosStatus
    {
        [Column(TypeName = "datetime")]
        public DateTime lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_status { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_pedido { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_hora { get; private set; }

        [Column(TypeName = "varchar(80)")]
        [LengthValidation(length: 80, propertyName: "anotacao")]
        public string? anotacao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxB2CPedidosStatus() { }

        public LinxB2CPedidosStatus(
            List<ValidationResult> listValidations,
            string id,
            string id_status,
            string id_pedido,
            string data_hora,
            string anotacao,
            string timestamp,
            string portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id =
                 ConvertToInt32Validation.IsValid(id, "id", listValidations) ?
                 Convert.ToInt32(id) :
                 0;

            this.id_status =
                 ConvertToInt32Validation.IsValid(id_status, "id_status", listValidations) ?
                 Convert.ToInt32(id_status) :
                 0;

            this.id_pedido =
                 ConvertToInt32Validation.IsValid(id_pedido, "id_pedido", listValidations) ?
                 Convert.ToInt32(id_pedido) :
                 0;

            this.data_hora =
                ConvertToDateTimeValidation.IsValid(data_hora, "data_hora", listValidations) ?
                Convert.ToDateTime(data_hora) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.portal =
                 ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                 Convert.ToInt32(portal) :
                 0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.recordKey = $"[{id}]|[{id_status}]|[{id_pedido}]|[{timestamp}]";
            this.recordXml = recordXml;
            this.anotacao = anotacao;
        }
    }
}
