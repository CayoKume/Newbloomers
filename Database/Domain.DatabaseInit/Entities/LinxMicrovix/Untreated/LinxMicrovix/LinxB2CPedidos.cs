using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxB2CPedidos", Schema = "untreated")]
    public class LinxB2CPedidos
    {
        [Column(TypeName = "datetime")]
        public string lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string id_pedido { get; private set; }

        [Column(TypeName = "datetime")]
        public string dt_pedido { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string cod_cliente_erp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string cod_cliente_b2c { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string vl_frete { get; private set; }

        [Column(TypeName = "int")]
        public string forma_pgto { get; private set; }

        [Column(TypeName = "int")]
        public string plano_pagamento { get; private set; }

        [Column(TypeName = "varchar(400)")]
        public string anotacao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string taxa_impressao { get; private set; }

        [Column(TypeName = "bit")]
        public string finalizado { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string valor_frete_gratis { get; private set; }

        [Column(TypeName = "int")]
        public string tipo_frete { get; private set; }

        [Column(TypeName = "int")]
        public string id_status { get; private set; }

        [Column(TypeName = "int")]
        public string cod_transportador { get; private set; }

        [Column(TypeName = "int")]
        public string tipo_cobranca_frete { get; private set; }

        [Column(TypeName = "bit")]
        public string ativo { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string empresa { get; private set; }

        [Column(TypeName = "int")]
        public string id_tabela_preco { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string valor_credito { get; private set; }

        [Column(TypeName = "int")]
        public string cod_vendedor { get; private set; }

        [Column(TypeName = "bigint")]
        public string timestamp { get; private set; }

        [Column(TypeName = "datetime")]
        public string dt_insert { get; private set; }

        [Column(TypeName = "datetime")]
        public string dt_disponivel_faturamento { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string mensagem_falha_faturamento { get; private set; }

        [Column(TypeName = "int")]
        public string portal { get; private set; }

        [Column(TypeName = "int")]
        public string id_tipo_b2c { get; private set; }

        [Column(TypeName = "varchar(200)")]
        public string ecommerce_origem { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string marketplace_loja { get; private set; }

        [Key]
        [Column(TypeName = "varchar(40)")]
        public string order_id { get; private set; }
    }
}
