using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxPagamentoParcialDav", Schema = "untreated")]
    public class LinxPagamentoParcialDav
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_pagamento_parcial_tmp { get; private set; }

        [Column(TypeName = "int")]
        public string? id_vendas_pos { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? ajuste_valor_desc_acresc_plano { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? plano { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? forma_pgto { get; private set; }

        [Column(TypeName = "int")]
        public string? id_bandeira { get; private set; }

        [Column(TypeName = "int")]
        public string? qtde_parcelas { get; private set; }

        [Column(TypeName = "varchar(1)")]
        public string? credito_debito { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
