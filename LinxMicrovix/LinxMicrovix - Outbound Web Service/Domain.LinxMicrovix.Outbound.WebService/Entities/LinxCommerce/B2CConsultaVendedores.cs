using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.IntegrationsCore.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
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
                String.IsNullOrEmpty(cod_vendedor) ? 0
                : Convert.ToInt32(cod_vendedor);

            this.comissao_produtos =
                String.IsNullOrEmpty(comissao_produtos) ? 0
                : Convert.ToDecimal(comissao_produtos);

            this.comissao_servicos =
                String.IsNullOrEmpty(comissao_servicos) ? 0
                : Convert.ToDecimal(comissao_servicos);

            this.ativo =
                String.IsNullOrEmpty(ativo) ? 0
                : Convert.ToInt32(ativo);

            this.comissionado =
                String.IsNullOrEmpty(comissionado) ? 0
                : Convert.ToInt32(comissionado);

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
