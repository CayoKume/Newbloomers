using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.IntegrationsCore.CustomValidations;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxLotesProdutos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_lote { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? codigo_produto { get; private set; }

        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "lote")]
        public string? lote { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? transacao { get; private set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? data_fabricacao { get; private set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? data_vencimento { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }
        
        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxLotesProdutos() { }

        public LinxLotesProdutos(
            List<ValidationResult> listValidations,
            string? id_lote,
            string? codigo_produto,
            string? lote,
            string? identificador,
            string? transacao,
            string? data_fabricacao,
            string? data_vencimento,
            string? portal,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.data_fabricacao =
                ConvertToDateTimeValidation.IsValid(data_fabricacao, "data_fabricacao", listValidations) ?
                Convert.ToDateTime(data_fabricacao) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_vencimento =
                ConvertToDateTimeValidation.IsValid(data_vencimento, "data_vencimento", listValidations) ?
                Convert.ToDateTime(data_vencimento) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.id_lote =
                ConvertToInt32Validation.IsValid(id_lote, "id_lote", listValidations) ?
                Convert.ToInt32(id_lote) :
                0;

            this.transacao =
                ConvertToInt32Validation.IsValid(transacao, "transacao", listValidations) ?
                Convert.ToInt32(transacao) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.codigo_produto =
                ConvertToInt64Validation.IsValid(codigo_produto, "codigo_produto", listValidations) ?
                Convert.ToInt64(codigo_produto) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.lote = lote;
        }
    }
}
