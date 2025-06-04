using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxCommerce
{
    [Table("B2CConsultaProdutosPromocao", Schema = "linx_microvix_commerce")]
    public class B2CConsultaProdutosPromocao
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? codigo_promocao { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? preco { get; private set; }

        [Column(TypeName = "smallstring")]
        public string? data_inicio { get; private set; }

        [Column(TypeName = "smallstring")]
        public string? data_termino { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_cadastro { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? ativa { get; private set; }

        [Column(TypeName = "int")]
        public string? codigo_campanha { get; private set; }

        [Column(TypeName = "bit")]
        public string? promocao_opcional { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? referencia { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
