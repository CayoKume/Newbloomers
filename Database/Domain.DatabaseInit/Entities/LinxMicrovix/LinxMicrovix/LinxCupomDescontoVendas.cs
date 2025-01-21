using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxCupomDescontoVendas", Schema = "untreated")]
    public class LinxCupomDescontoVendas
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_cupom_desconto_vendas { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_cupom_desconto { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_vendas_pos { get; private set; }

        public LinxCupomDescontoVendas() { }

        public LinxCupomDescontoVendas(
            List<ValidationResult> listValidations,
            string? portal,
            string? empresa,
            string? id_cupom_desconto_vendas,
            string? id_cupom_desconto,
            string? identificador,
            string? valor,
            string? timestamp,
            string? id_vendas_pos
        )
        {
            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.id_cupom_desconto_vendas =
                ConvertToInt32Validation.IsValid(id_cupom_desconto_vendas, "id_cupom_desconto_vendas", listValidations) ?
                Convert.ToInt32(id_cupom_desconto_vendas) :
                0;

            this.id_cupom_desconto =
                ConvertToInt32Validation.IsValid(id_cupom_desconto, "id_cupom_desconto", listValidations) ?
                Convert.ToInt32(id_cupom_desconto) :
                0;

            this.id_vendas_pos =
                ConvertToInt32Validation.IsValid(id_vendas_pos, "id_vendas_pos", listValidations) ?
                Convert.ToInt32(id_vendas_pos) :
                0;

            this.valor =
                ConvertToDecimalValidation.IsValid(valor, "valor", listValidations) ?
                Convert.ToDecimal(valor) :
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
        }
    }
}
