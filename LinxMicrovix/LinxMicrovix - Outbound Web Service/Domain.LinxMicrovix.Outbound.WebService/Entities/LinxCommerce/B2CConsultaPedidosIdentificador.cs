using Domain.IntegrationsCore.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    [Table("B2CConsultaPedidosIdentificador", Schema = "linx_microvix_commerce")]
    public class B2CConsultaPedidosIdentificador
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_venda { get; private set; }

        [Key]
        [Column(TypeName = "varchar(40)")]
        [LengthValidation(length: 40, propertyName: "order_id")]
        public string? order_id { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_cliente { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_frete { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_origem { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaPedidosIdentificador() { }

        public B2CConsultaPedidosIdentificador(
            List<ValidationResult> listValidations,
            string? portal,
            string? empresa,
            string? identificador,
            string? id_venda,
            string? order_id,
            string? id_cliente,
            string? valor_frete,
            string? data_origem,
            string? timestamp,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.id_venda =
                ConvertToInt32Validation.IsValid(id_venda, "id_venda", listValidations) ?
                Convert.ToInt32(id_venda) :
                0;

            this.id_cliente =
                ConvertToInt32Validation.IsValid(id_cliente, "id_cliente", listValidations) ?
                Convert.ToInt32(id_cliente) :
                0;

            this.data_origem =
                ConvertToDateTimeValidation.IsValid(data_origem, "data_origem", listValidations) ?
                Convert.ToDateTime(data_origem) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.valor_frete =
                ConvertToDecimalValidation.IsValid(valor_frete, "valor_frete", listValidations) ?
                Convert.ToDecimal(valor_frete, new CultureInfo("en-US")) :
                0;

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.order_id = order_id;
            this.recordXml = recordXml;
        }
    }
}
