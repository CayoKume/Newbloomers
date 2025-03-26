using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxMovimentoRemessasItens", Schema = "linx_microvix_erp")]
    public class LinxMovimentoRemessasItens
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_remessas_itens { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "int")]
        public string? id_remessas { get; private set; }

        [Column(TypeName = "int")]
        public string? transacao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? qtde_total { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? qtde_venda { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? qtde_devolvido { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? qtde_pendente { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? qtde_pendente_pagamento { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
