using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxOrcamentoComponenteFormula", Schema = "linx_microvix_erp")]
    public class LinxOrcamentoComponenteFormula
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_orcamento_componente_formula { get; private set; }

        [Column(TypeName = "int")]
        public string? documento { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigo_produto { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? codigo_componente { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? descricao_componente { get; private set; }

        [Column(TypeName = "varchar(5)")]
        public string? unidade { get; private set; }

        [Column(TypeName = "int")]
        public string? quantidade { get; private set; }

        [Column(TypeName = "int")]
        public string? valor_componente { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? lote_componente { get; private set; }

        [Column(TypeName = "int")]
        public string? data_validade_lote { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? codigo_ws { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
