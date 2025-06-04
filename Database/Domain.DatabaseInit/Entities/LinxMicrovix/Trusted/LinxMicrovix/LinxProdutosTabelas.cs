using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxProdutosTabelas", Schema = "linx_microvix_erp")]
    public class LinxProdutosTabelas
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_tabela { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_tabela { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? ativa { get; private set; }

        [Column(TypeName = "int")]
        public string? timestamp { get; private set; }

        [Key]
        [Column(TypeName = "char(1)")]
        public string? tipo_tabela { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? codigo_integracao_ws { get; private set; }
    }
}
