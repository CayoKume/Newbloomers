using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.IntegrationsCore.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxCstIcmsFiscal
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_cst_icms_fiscal { get; private set; }

        [Column(TypeName = "varchar(4)")]
        [LengthValidation(length: 4, propertyName: "cst_icms_fiscal")]
        public string? cst_icms_fiscal { get; private set; }

        [Column(TypeName = "varchar(150)")]
        [LengthValidation(length: 150, propertyName: "descricao")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bit")]
        public bool? substituicao_tributaria { get; private set; }

        [Column(TypeName = "bit")]
        public bool? excluido { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxCstIcmsFiscal() { }

        public LinxCstIcmsFiscal(
            List<ValidationResult> listValidations,
            string? portal,
            string? id_cst_icms_fiscal,
            string? cst_icms_fiscal,
            string? descricao,
            string? substituicao_tributaria,
            string? excluido,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_cst_icms_fiscal =
                ConvertToInt32Validation.IsValid(id_cst_icms_fiscal, "id_cst_icms_fiscal", listValidations) ?
                Convert.ToInt32(id_cst_icms_fiscal) :
                0;

            this.substituicao_tributaria =
                ConvertToBooleanValidation.IsValid(substituicao_tributaria, "substituicao_tributaria", listValidations) ?
                Convert.ToBoolean(substituicao_tributaria) :
                false;

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

            this.descricao = descricao;
            this.cst_icms_fiscal = cst_icms_fiscal;
        }
    }
}
