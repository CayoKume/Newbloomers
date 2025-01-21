using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxTrocaUnificadaResumoVendas", Schema = "untreated")]
    public class LinxTrocaUnificadaResumoVendas
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? id_troca_unificada_resumo_vendas { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "varchar(30)")]
        [LengthValidation(length: 30, propertyName: "token")]
        public string? token { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador { get; private set; }

        [Column(TypeName = "int")]
        public Int32? documento { get; private set; }

        [Column(TypeName = "varchar(10)")]
        [LengthValidation(length: 10, propertyName: "serie")]
        public string? serie { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_venda { get; private set; }

        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "documento_cliente")]
        public string? documento_cliente { get; private set; }

        [Column(TypeName = "bit")]
        public bool? venda_cancelada { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxTrocaUnificadaResumoVendas() { }

        public LinxTrocaUnificadaResumoVendas(
            List<ValidationResult> listValidations,
            string? id_troca_unificada_resumo_vendas,
            string? portal,
            string? empresa,
            string? token,
            string? identificador,
            string? documento,
            string? serie,
            string? data_venda,
            string? documento_cliente,
            string? venda_cancelada,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.documento =
                ConvertToInt32Validation.IsValid(documento, "documento", listValidations) ?
                Convert.ToInt32(documento) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.id_troca_unificada_resumo_vendas =
                ConvertToInt64Validation.IsValid(id_troca_unificada_resumo_vendas, "id_troca_unificada_resumo_vendas", listValidations) ?
                Convert.ToInt64(id_troca_unificada_resumo_vendas) :
                0;

            this.venda_cancelada =
                ConvertToBooleanValidation.IsValid(venda_cancelada, "venda_cancelada", listValidations) ?
                Convert.ToBoolean(venda_cancelada) :
                false;

            this.data_venda =
                ConvertToDateTimeValidation.IsValid(data_venda, "data_venda", listValidations) ?
                Convert.ToDateTime(data_venda) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.serie = serie;
            this.token = token;
            this.documento_cliente = documento_cliente;
        }
    }
}
