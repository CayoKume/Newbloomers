using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxPlanosPedidoVenda", Schema = "linx_microvix_erp")]
    public class LinxPlanosPedidoVenda
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_pedido { get; private set; }

        [Column(TypeName = "int")]
        public Int32? plano { get; private set; }

        [Column(TypeName = "varchar(35)")]
        [LengthValidation(length: 35, propertyName: "desc_plano")]
        public string? desc_plano { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? total { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtde_parcelas { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? indice_plano { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_desc_acresc_plano { get; private set; }

        [Column(TypeName = "int")]
        public Int32? cod_forma_pgto { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "forma_pgto")]
        public string? forma_pgto { get; private set; }

        public LinxPlanosPedidoVenda() { }

        public LinxPlanosPedidoVenda(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? cod_pedido,
            string? plano,
            string? desc_plano,
            string? total,
            string? qtde_parcelas,
            string? indice_plano,
            string? valor_desc_acresc_plano,
            string? cod_forma_pgto,
            string? forma_pgto
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.plano =
                ConvertToInt32Validation.IsValid(plano, "plano", listValidations) ?
                Convert.ToInt32(plano) :
                0;

            this.cod_pedido =
                ConvertToInt32Validation.IsValid(cod_pedido, "cod_pedido", listValidations) ?
                Convert.ToInt32(cod_pedido) :
                0;

            this.qtde_parcelas =
                ConvertToInt32Validation.IsValid(qtde_parcelas, "qtde_parcelas", listValidations) ?
                Convert.ToInt32(qtde_parcelas) :
                0;

            this.cod_forma_pgto =
                ConvertToInt32Validation.IsValid(cod_forma_pgto, "cod_forma_pgto", listValidations) ?
                Convert.ToInt32(cod_forma_pgto) :
                0;

            this.valor_desc_acresc_plano =
                ConvertToDecimalValidation.IsValid(valor_desc_acresc_plano, "valor_desc_acresc_plano", listValidations) ?
                Convert.ToDecimal(valor_desc_acresc_plano, new CultureInfo("en-US")) :
                0;

            this.indice_plano =
                ConvertToDecimalValidation.IsValid(indice_plano, "indice_plano", listValidations) ?
                Convert.ToDecimal(indice_plano, new CultureInfo("en-US")) :
                0;

            this.total =
                ConvertToDecimalValidation.IsValid(total, "total", listValidations) ?
                Convert.ToDecimal(total, new CultureInfo("en-US")) :
                0;

            this.forma_pgto = forma_pgto;
            this.desc_plano = desc_plano;
            this.cnpj_emp = cnpj_emp;
        }
    }
}
