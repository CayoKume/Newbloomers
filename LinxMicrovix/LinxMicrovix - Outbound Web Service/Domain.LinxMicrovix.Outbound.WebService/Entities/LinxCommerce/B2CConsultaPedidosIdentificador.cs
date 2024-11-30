using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
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
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.empresa =
                String.IsNullOrEmpty(empresa) ? 0
                : Convert.ToInt32(empresa);

            this.id_venda =
                String.IsNullOrEmpty(id_venda) ? 0
                : Convert.ToInt32(id_venda);

            this.id_cliente =
                String.IsNullOrEmpty(id_cliente) ? 0
                : Convert.ToInt32(id_cliente);

            this.data_origem =
                String.IsNullOrEmpty(data_origem) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(data_origem);

            this.valor_frete =
               String.IsNullOrEmpty(valor_frete) ? 0
               : Convert.ToDecimal(valor_frete);

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.order_id =
                String.IsNullOrEmpty(order_id) ? ""
                : order_id.Substring(
                    0,
                    order_id.Length > 40 ? 40
                    : order_id.Length
                );

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
