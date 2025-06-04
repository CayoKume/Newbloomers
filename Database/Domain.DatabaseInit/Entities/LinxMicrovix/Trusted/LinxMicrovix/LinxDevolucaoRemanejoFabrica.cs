using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxDevolucaoRemanejoFabrica", Schema = "linx_microvix_erp")]
    public class LinxDevolucaoRemanejoFabrica
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_devolucao_remanejo_fabrica { get; private set; }

        [Column(TypeName = "int")]
        public string? id_devolucao_remanejo_fabrica_tipo { get; private set; }

        [Column(TypeName = "int")]
        public string? id_motivo_devolucao_fabrica { get; private set; }

        [Column(TypeName = "int")]
        public string? id_deposito { get; private set; }

        [Column(TypeName = "int")]
        public string? id_devolucao_remanejo_fabrica_status { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "int")]
        public string? fornecedor { get; private set; }

        [Column(TypeName = "char(10)")]
        public string? cfop { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? serie { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? codigo_solicitacao { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_solicitacao { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
