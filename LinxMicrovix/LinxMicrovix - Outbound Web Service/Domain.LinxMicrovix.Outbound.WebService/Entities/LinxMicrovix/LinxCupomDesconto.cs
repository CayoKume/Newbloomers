using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxCupomDesconto", Schema = "linx_microvix_erp")]
    public class LinxCupomDesconto
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_cupom_desconto { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "cupom")]
        public string? cupom { get; private set; }

        [Column(TypeName = "varchar(255)")]
        [LengthValidation(length: 255, propertyName: "descricao")]
        public string? descricao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? percentual_desconto { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_inicial_vigencia { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_final_vigencia { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtde_original { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtde_disponivel { get; private set; }

        [Column(TypeName = "int")]
        public Int32? cod_vendedor { get; private set; }

        [Column(TypeName = "bit")]
        public bool? disponivel { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxCupomDesconto() { }

        public LinxCupomDesconto(
            List<ValidationResult> listValidations,
            string? portal,
            string? empresa,
            string? id_cupom_desconto,
            string? cupom,
            string? descricao,
            string? percentual_desconto,
            string? data_inicial_vigencia,
            string? data_final_vigencia,
            string? qtde_original,
            string? qtde_disponivel,
            string? cod_vendedor,
            string? disponivel,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_cupom_desconto =
                ConvertToInt32Validation.IsValid(id_cupom_desconto, "id_cupom_desconto", listValidations) ?
                Convert.ToInt32(id_cupom_desconto) :
                0;

            this.qtde_original =
                ConvertToInt32Validation.IsValid(qtde_original, "qtde_original", listValidations) ?
                Convert.ToInt32(qtde_original) :
                0;

            this.qtde_disponivel =
                ConvertToInt32Validation.IsValid(qtde_disponivel, "qtde_disponivel", listValidations) ?
                Convert.ToInt32(qtde_disponivel) :
                0;

            this.cod_vendedor =
                ConvertToInt32Validation.IsValid(cod_vendedor, "cod_vendedor", listValidations) ?
                Convert.ToInt32(cod_vendedor) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.percentual_desconto =
                ConvertToDecimalValidation.IsValid(percentual_desconto, "percentual_desconto", listValidations) ?
                Convert.ToDecimal(percentual_desconto, new CultureInfo("en-US")) :
                0;

            this.data_inicial_vigencia =
                ConvertToDateTimeValidation.IsValid(data_inicial_vigencia, "data_inicial_vigencia", listValidations) ?
                Convert.ToDateTime(data_inicial_vigencia) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_final_vigencia =
                ConvertToDateTimeValidation.IsValid(data_final_vigencia, "data_final_vigencia", listValidations) ?
                Convert.ToDateTime(data_final_vigencia) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.disponivel =
               ConvertToBooleanValidation.IsValid(disponivel, "disponivel", listValidations) ?
               Convert.ToBoolean(disponivel) :
               false;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.cupom = cupom;
            this.descricao = descricao;
        }
    }
}
