using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxPedidosVenda", Schema = "linx_microvix_erp")]
    public class LinxPedidosVenda
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? cod_pedido { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_lancamento { get; private set; }

        [Column(TypeName = "char(5)")]
        public string? hora_lancamento { get; private set; }

        [Column(TypeName = "int")]
        public string? transacao { get; private set; }

        [Column(TypeName = "int")]
        public string? usuario { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? codigo_cliente { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? cod_produto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? quantidade { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_unitario { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_vendedor { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_frete { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_total { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? desconto_item { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_plano_pagamento { get; private set; }

        [Column(TypeName = "varchar(35)")]
        public string? plano_pagamento { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? obs { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? aprovado { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? cancelado { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_aprovacao { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_alteracao { get; private set; }

        [Column(TypeName = "int")]
        public string? tipo_frete { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? natureza_operacao { get; private set; }

        [Column(TypeName = "int")]
        public string? tabela_preco { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_tabela_preco { get; private set; }

        [Column(TypeName = "datetime")]
        public string? previsao_entrega { get; private set; }

        [Column(TypeName = "int")]
        public string? realizado_por { get; private set; }

        [Column(TypeName = "int")]
        public string? pontuacao_ser { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? venda_externa { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? nf_gerada { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? status { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? numero_projeto_officina { get; private set; }

        [Column(TypeName = "char(10)")]
        public string? cod_natureza_operacao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? margem_contribuicao { get; private set; }

        [Column(TypeName = "int")]
        public string? doc_origem { get; private set; }

        [Column(TypeName = "int")]
        public string? posicao_item { get; private set; }

        [Column(TypeName = "int")]
        public string? orcamento_origem { get; private set; }

        [Column(TypeName = "int")]
        public string? transacao_origem { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? desconto { get; private set; }

        [Column(TypeName = "int")]
        public string? transacao_ws { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "bigint")]
        public string? transportador { get; private set; }

        [Column(TypeName = "int")]
        public string? deposito { get; private set; }
    }
}
