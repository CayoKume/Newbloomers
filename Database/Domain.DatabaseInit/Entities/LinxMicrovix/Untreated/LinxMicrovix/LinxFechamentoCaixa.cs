using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxFechamentoCaixa", Schema = "untreated")]
    public class LinxFechamentoCaixa
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "bit")]
        public string? ativo { get; private set; }

        [Column(TypeName = "bit")]
        public string? conferencia_efetuada { get; private set; }

        [Column(TypeName = "int")]
        public string? data { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "text")]
        public string? obs { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? qtd_001 { get; private set; }

        [Column(TypeName = "int")]
        public string? qtd_005 { get; private set; }

        [Column(TypeName = "int")]
        public string? qtd_010 { get; private set; }

        [Column(TypeName = "int")]
        public string? qtd_025 { get; private set; }

        [Column(TypeName = "int")]
        public string? qtd_050 { get; private set; }

        [Column(TypeName = "int")]
        public string? qtd_1 { get; private set; }

        [Column(TypeName = "int")]
        public string? qtd_10 { get; private set; }

        [Column(TypeName = "int")]
        public string? qtd_100 { get; private set; }

        [Column(TypeName = "int")]
        public string? qtd_2 { get; private set; }

        [Column(TypeName = "int")]
        public string? qtd_20 { get; private set; }

        [Column(TypeName = "int")]
        public string? qtd_200 { get; private set; }

        [Column(TypeName = "int")]
        public string? qtd_5 { get; private set; }

        [Column(TypeName = "int")]
        public string? qtd_50 { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? sangria { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? suprimentos { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_c_prazo { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_c_vista { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_cartao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_cartao_credito { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_cartao_debito { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_convenio { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_crediario { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_geral { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_giftcard { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_link_pagamento { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_link_pagamento_credito { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_link_pagamento_debito { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_pix { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_qr_linx { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_vale_compra { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? usuario { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? vale_compras_dev { get; private set; }
    }
}
