using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxPlanoContas", Schema = "linx_microvix_erp")]
    public class LinxPlanoContas
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_conta { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_conta { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? sintetica { get; private set; }

        [Column(TypeName = "varchar(150)")]
        public string? indice { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? ativa { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? fluxo_caixa { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? conta_contabil { get; private set; }

        [Column(TypeName = "int")]
        public string? id_natureza_conta { get; private set; }

        [Column(TypeName = "bit")]
        public string? conta_bancaria { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
