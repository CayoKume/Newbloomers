using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxCommerce
{
    [Table("B2CConsultaProdutosDetalhes", Schema = "linx_microvix_commerce")]
    public class B2CConsultaProdutosDetalhes
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_prod_det { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? saldo { get; private set; }

        [Column(TypeName = "bit")]
        public string? controla_lote { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? nomeproduto_alternativo { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? referencia { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? localizacao { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "smallint")]
        public string? tempo_preparacao_estoque { get; private set; }
    }
}
