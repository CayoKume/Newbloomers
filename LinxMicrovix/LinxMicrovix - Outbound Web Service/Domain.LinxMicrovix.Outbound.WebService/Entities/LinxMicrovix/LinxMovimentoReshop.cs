using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxMovimentoReshop", Schema = "linx_microvix_erp")]
    public class LinxMovimentoReshop
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_movimento_campanha_reshop { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_campanha { get; private set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador { get; private set; }

        [Column(TypeName = "varchar(200)")]
        [LengthValidation(length: 200, propertyName: "")]
        public string? nome { get; private set; }

        [Column(TypeName = "varchar(200)")]
        [LengthValidation(length: 200, propertyName: "")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bit")]
        public bool? aplicar_desconto_venda { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_desconto_subtotal { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_desconto_completo { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxMovimentoReshop() { }

        public LinxMovimentoReshop(
            List<ValidationResult> listValidations,
            string? id_movimento_campanha_reshop,
            string? id_campanha,
            string? identificador,
            string? nome,
            string? descricao,
            string? aplicar_desconto_venda,
            string? valor_desconto_subtotal,
            string? valor_desconto_completo,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_movimento_campanha_reshop =
                ConvertToInt32Validation.IsValid(id_movimento_campanha_reshop, "id_movimento_campanha_reshop", listValidations) ?
                Convert.ToInt32(id_movimento_campanha_reshop) :
                0;

            this.id_campanha =
                ConvertToInt32Validation.IsValid(id_campanha, "id_campanha", listValidations) ?
                Convert.ToInt32(id_campanha) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.valor_desconto_subtotal =
                ConvertToDecimalValidation.IsValid(valor_desconto_subtotal, "valor_desconto_subtotal", listValidations) ?
                Convert.ToDecimal(valor_desconto_subtotal, new CultureInfo("en-US")) :
                0;

            this.valor_desconto_completo =
                ConvertToDecimalValidation.IsValid(valor_desconto_completo, "valor_desconto_completo", listValidations) ?
                Convert.ToDecimal(valor_desconto_completo, new CultureInfo("en-US")) :
                0;

            this.aplicar_desconto_venda =
                ConvertToBooleanValidation.IsValid(aplicar_desconto_venda, "aplicar_desconto_venda", listValidations) ?
                Convert.ToBoolean(aplicar_desconto_venda) :
                false;

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.descricao = descricao;
            this.nome = nome;
        }
    }
}
