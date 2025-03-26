using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxPedidosCompra", Schema = "untreated")]
    public class LinxPedidosCompra
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
        public string? data_pedido { get; private set; }

        [Column(TypeName = "int")]
        public string? transacao { get; private set; }

        [Column(TypeName = "int")]
        public string? usuario { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? codigo_fornecedor { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? cod_produto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? quantidade { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_unitario { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_comprador { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_frete { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_total { get; private set; }

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

        [Column(TypeName = "char(1)")]
        public string? encerrado { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_aprovacao { get; private set; }

        [Column(TypeName = "varchar(15)")]
        public string? numero_ped_fornec { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo_frete { get; private set; }

        [Column(TypeName = "varchar(73)")]
        public string? natureza_operacao { get; private set; }

        [Column(TypeName = "datetime")]
        public string? previsao_entrega { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? numero_projeto_officina { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? status_pedido { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? qtde_entregue { get; private set; }

        [Column(TypeName = "varchar(40)")]
        public string? descricao_frete { get; private set; }

        [Column(TypeName = "bit")]
        public string? integrado_linx { get; private set; }

        [Column(TypeName = "int")]
        public string? nf_gerada { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? nf_origem_ws { get; private set; }
    }
}
