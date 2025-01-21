using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxMovimentoTrocafone", Schema = "untreated")]
    public class LinxMovimentoTrocafone
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? num_vale { get; private set; }

        [Column(TypeName = "varchar(100)")]
        [LengthValidation(length: 100, propertyName: "voucher")]
        public string? voucher { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_vale { get; private set; }

        [Column(TypeName = "varchar(250)")]
        [LengthValidation(length: 250, propertyName: "nome_produto")]
        public string? nome_produto { get; private set; }

        [Column(TypeName = "varchar(250)")]
        [LengthValidation(length: 250, propertyName: "condicao")]
        public string? condicao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_tradein_parceiro { get; private set; }

        public LinxMovimentoTrocafone() { }

        public LinxMovimentoTrocafone(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? identificador,
            string? num_vale,
            string? voucher,
            string? valor_vale,
            string? nome_produto,
            string? condicao,
            string? id_tradein_parceiro
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.id_tradein_parceiro =
                ConvertToInt32Validation.IsValid(id_tradein_parceiro, "id_tradein_parceiro", listValidations) ?
                Convert.ToInt32(id_tradein_parceiro) :
                0;

            this.num_vale =
                ConvertToInt64Validation.IsValid(num_vale, "num_vale", listValidations) ?
                Convert.ToInt64(num_vale) :
                0;

            this.valor_vale =
                ConvertToDecimalValidation.IsValid(valor_vale, "valor_vale", listValidations) ?
                Convert.ToDecimal(valor_vale) :
                0;

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.cnpj_emp = cnpj_emp;
            this.voucher = voucher;
            this.nome_produto = nome_produto;
            this.condicao = condicao;
        }
    }
}
