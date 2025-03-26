using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxAntecipacoesFinanceirasPlanos", Schema = "untreated")]
    public class LinxAntecipacoesFinanceirasPlanos
    {
        [Column(TypeName = "datetime")]
        public string lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "int")]
        public string? id_antecipacoes_financeiras { get; private set; }

        [Column(TypeName = "int")]
        public string? numero_antecipacao { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? forma_pgto { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? plano { get; private set; }

        [Column(TypeName = "varchar(35)")]
        public string? nome_plano { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? id_ordservprod { get; private set; }

        [Column(TypeName = "int")]
        public string? id_vendas_pos_produtos_tmp { get; private set; }

        [Column(TypeName = "int")]
        public string? id_vendas_pos { get; private set; }

        [Column(TypeName = "bit")]
        public string? cancelado { get; private set; }

        [Column(TypeName = "datetime")]
        public string? previsao_entrega { get; private set; }

        [Column(TypeName = "bigint")]
        public string? numero_ficha { get; private set; }

        [Column(TypeName = "int")]
        public string? id_vendas_pos_produtos_campos_adicionais_tmp { get; private set; }

        [Column(TypeName = "int")]
        public string? id_link_pagamento_linx_pay_hub { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? codigo_gerencial { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }
    }
}
