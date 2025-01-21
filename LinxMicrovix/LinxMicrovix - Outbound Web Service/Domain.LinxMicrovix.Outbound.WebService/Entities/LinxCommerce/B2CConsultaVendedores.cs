using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    [Table("B2CConsultaVendedores", Schema = "linx_microvix_commerce")]
    public class B2CConsultaVendedores
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_vendedor { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "nome_vendedor")]
        public string? nome_vendedor { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? comissao_produtos { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? comissao_servicos { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "tipo")]
        public string? tipo { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? ativo { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? comissionado { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaVendedores() { }

        public B2CConsultaVendedores(
            List<ValidationResult> listValidations,
            string? cod_vendedor,
            string? nome_vendedor,
            string? comissao_produtos,
            string? comissao_servicos,
            string? tipo,
            string? ativo,
            string? comissionado,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.cod_vendedor =
                ConvertToInt32Validation.IsValid(cod_vendedor, "cod_vendedor", listValidations) ?
                Convert.ToInt32(cod_vendedor) :
                0;

            this.comissao_produtos =
                ConvertToDecimalValidation.IsValid(comissao_produtos, "comissao_produtos", listValidations) ?
                Convert.ToDecimal(comissao_produtos) :
                0;

            this.comissao_servicos =
                ConvertToDecimalValidation.IsValid(comissao_servicos, "comissao_servicos", listValidations) ?
                Convert.ToDecimal(comissao_servicos) :
                0;

            this.ativo =
                ConvertToInt32Validation.IsValid(ativo, "ativo", listValidations) ?
                Convert.ToInt32(ativo) :
                0;

            this.comissionado =
                ConvertToInt32Validation.IsValid(comissionado, "comissionado", listValidations) ?
                Convert.ToInt32(comissionado) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_vendedor = nome_vendedor;
            this.tipo = tipo;
        }
    }
}
