using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxMovimentoRemessasAcertos", Schema = "linx_microvix_erp")]
    public class LinxMovimentoRemessasAcertos
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_remessas_acertos { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "int")]
        public string? id_remessas { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador_venda { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador_retorno { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador_devolucao { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data { get; private set; }

        [Column(TypeName = "bigint")]
        public string? id_vendas_pos { get; private set; }

        [Column(TypeName = "bit")]
        public string? excluido { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
