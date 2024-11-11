using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxMicrovix
{
    public class LinxB2CPedidos
    {
        [Column(TypeName = "datetime")]
        public DateTime lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32 id_pedido { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime dt_pedido { get; private set; }

        [Column(TypeName = "int")]
        public Int32 cod_cliente_erp { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32 cod_cliente_b2c { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal vl_frete { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32 forma_pgto { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32 plano_pagamento { get; private set; }
        
        [Column(TypeName = "varchar(400)")]
        public string anotacao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal taxa_impressao { get; private set; }

        [Column(TypeName = "bit")]
        public bool finalizado { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal valor_frete_gratis { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32 tipo_frete { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32 id_status { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32 cod_transportador { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32 tipo_cobranca_frete { get; private set; }

        [Column(TypeName = "bit")]
        public bool ativo { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32 empresa { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32 id_tabela_preco { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal valor_credito { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32 cod_vendedor { get; private set; }
        
        [Column(TypeName = "bigint")]
        public Int64 timestamp { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime dt_insert { get; private set; }
        
        [Column(TypeName = "datetime")]
        public DateTime dt_disponivel_faturamento { get; private set; }
        
        [Column(TypeName = "varchar(max)")]
        public string mensagem_falha_faturamento { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32 portal { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32 id_tipo_b2c { get; private set; }

        [Column(TypeName = "varchar(200)")]
        public string ecommerce_origem { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string marketplace_loja { get; private set; }

        public LinxB2CPedidos() { }

        public LinxB2CPedidos(
            string? id_pedido,
            string? dt_pedido,
            string? cod_cliente_erp,
            string? cod_cliente_b2c,
            string? vl_frete,
            string? forma_pgto,
            string? plano_pagamento,
            string? anotacao,
            string? taxa_impressao,
            string? finalizado,
            string? valor_frete_gratis,
            string? tipo_frete,
            string? id_status,
            string? cod_transportador,
            string? tipo_cobranca_frete,
            string? ativo,
            string? empresa,
            string? id_tabela_preco,
            string? valor_credito,
            string? cod_vendedor,
            string? timestamp,
            string? dt_insert,
            string? dt_disponivel_faturamento,
            string? mensagem_falha_faturamento,
            string? portal,
            string? id_tipo_b2c,
            string? ecommerce_origem,
            string? marketplace_loja
        )
        {
            this.lastupdateon = DateTime.Now;

            this.vl_frete =
                vl_frete == String.Empty ? 0
                : Convert.ToDecimal(vl_frete);

            this.ecommerce_origem =
                ecommerce_origem == String.Empty ? ""
                : ecommerce_origem.Substring(
                    0,
                    ecommerce_origem.Length > 200 ? 200
                    : ecommerce_origem.Length
                );

            this.marketplace_loja =
                marketplace_loja == String.Empty ? ""
                : marketplace_loja.Substring(
                    0,
                    marketplace_loja.Length > 60 ? 60
                    : marketplace_loja.Length
                );

            this.taxa_impressao =
                taxa_impressao == String.Empty ? 0
                : Convert.ToDecimal(taxa_impressao);

            this.valor_frete_gratis =
                valor_frete_gratis == String.Empty ? 0
                : Convert.ToDecimal(valor_frete_gratis);

            this.id_tipo_b2c =
                id_tipo_b2c == String.Empty ? 0
                : Convert.ToInt32(id_tipo_b2c);

            this.id_tabela_preco =
                id_tabela_preco == String.Empty ? 0
                : Convert.ToInt32(id_tabela_preco);

            this.mensagem_falha_faturamento =
                mensagem_falha_faturamento == String.Empty ? ""
                : mensagem_falha_faturamento;

            this.id_pedido =
                id_pedido == String.Empty ? 0
                : Convert.ToInt32(id_pedido);

            this.dt_pedido =
                String.IsNullOrEmpty(dt_pedido) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_pedido);

            this.dt_insert =
                String.IsNullOrEmpty(dt_insert) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_insert);

            this.dt_disponivel_faturamento =
                String.IsNullOrEmpty(dt_disponivel_faturamento) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_disponivel_faturamento);

            this.cod_cliente_erp =
                cod_cliente_erp == String.Empty ? 0
                : Convert.ToInt32(cod_cliente_erp);

            this.cod_cliente_b2c =
                cod_cliente_b2c == String.Empty ? 0
                : Convert.ToInt32(cod_cliente_b2c);

            this.forma_pgto =
                forma_pgto == String.Empty ? 0
                : Convert.ToInt32(forma_pgto);

            this.plano_pagamento =
                plano_pagamento == String.Empty ? 0
                : Convert.ToInt32(plano_pagamento);

            this.tipo_frete =
                tipo_frete == String.Empty ? 0
                : Convert.ToInt32(tipo_frete);

            this.id_status =
                id_status == String.Empty ? 0
                : Convert.ToInt32(id_status);

            this.cod_transportador =
                cod_transportador == String.Empty ? 0
                : Convert.ToInt32(cod_transportador);

            this.tipo_cobranca_frete =
                tipo_cobranca_frete == String.Empty ? 0
                : Convert.ToInt32(tipo_cobranca_frete);

            this.empresa =
                empresa == String.Empty ? 0
                : Convert.ToInt32(empresa);

            this.id_tabela_preco =
                id_tabela_preco == String.Empty ? 0
                : Convert.ToInt32(id_tabela_preco);

            this.cod_vendedor =
                cod_vendedor == String.Empty ? 0
                : Convert.ToInt32(cod_vendedor);

            this.timestamp =
                timestamp == String.Empty ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                portal == String.Empty ? 0
                : Convert.ToInt32(portal);
        }
    }
}
