using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaPedidosStatus
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id { get; private set; }

        [Column(TypeName = "tinyint")]
        public Int32? id_status { get; private set; }

        [Key]
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

        public B2CConsultaPedidosStatus() { }

        public B2CConsultaPedidosStatus(
            List<ValidationResult> listValidations,
            string? id,
            string? id_status,
            string? id_pedido,
            string? data_hora,
            string? anotacao,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id =
                String.IsNullOrEmpty(id) ? 0
                : Convert.ToInt32(id);

            this.id_status =
                String.IsNullOrEmpty(id_status) ? 0
                : Convert.ToInt32(id_status);

            this.id_pedido =
                String.IsNullOrEmpty(id_pedido) ? 0
                : Convert.ToInt32(id_pedido);

            this.data_hora =
                String.IsNullOrEmpty(data_hora) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(data_hora);

            this.anotacao = anotacao;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;
        }
    }
}
