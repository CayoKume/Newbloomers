using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxMovimentoGiftCard", Schema = "linx_microvix_erp")]
    public class LinxMovimentoGiftCard
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_transacao { get; private set; }

        [Column(TypeName = "int")]
        public string? operacao { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? nsu_cliente { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? nsu_host { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? json_envio { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string json_retorno { get; private set; }

        [Column(TypeName = "int")]
        public string? qtde_tentativa { get; private set; }

        [Column(TypeName = "varchar(4)")]
        public string? aprovado_barramento { get; private set; }

        [Column(TypeName = "bit")]
        public string? estornada { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? codigo_loja { get; private set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public string? identificador_movimento { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? numero_cartao { get; private set; }

        [Column(TypeName = "int")]
        public string? plano { get; private set; }

        [Column(TypeName = "bit")]
        public string? ambiente_producao { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
