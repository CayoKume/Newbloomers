using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxCfopFiscal
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32 portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32 id_cfop_fiscal { get; private set; }

        [Column(TypeName = "varchar(5)")]
        [LengthValidation(length: 5, propertyName: "cfop_fiscal")]
        public string? cfop_fiscal { get; private set; }

        [Column(TypeName = "varchar(300)")]
        [LengthValidation(length: 300, propertyName: "descricao")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bit")]
        public bool excluido { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64 timestamp { get; private set; }

        public LinxCfopFiscal() { }

        public LinxCfopFiscal(
            List<ValidationResult> listValidations,
            string? portal,
            string? id_cfop_fiscal,
            string? cfop_fiscal,
            string? descricao,
            string? excluido,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_cfop_fiscal =
                ConvertToInt32Validation.IsValid(id_cfop_fiscal, "id_cfop_fiscal", listValidations) ?
                Convert.ToInt32(id_cfop_fiscal) :
                0;

            this.excluido =
                ConvertToBooleanValidation.IsValid(excluido, "excluido", listValidations) ?
                Convert.ToBoolean(excluido) :
                false;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.cfop_fiscal = cfop_fiscal;
            this.descricao = descricao;
        }
    }
}
