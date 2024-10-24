using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaPedidos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_pedido { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_pedido { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_cliente_erp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_cliente_b2c { get; private set; }

        [Column(TypeName = "float")]
        public decimal? vl_frete { get; private set; }

        [Column(TypeName = "int")]
        public Int32? forma_pgto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? plano_pagamento { get; private set; }

        [Column(TypeName = "varchar(400)")]
        public string? anotacao { get; private set; }

        [Column(TypeName = "float")]
        public decimal? taxa_impressao { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? finalizado { get; private set; }

        [Column(TypeName = "float")]
        public decimal? valor_frete_gratis { get; private set; }

        [Column(TypeName = "int")]
        public Int32? tipo_frete { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_status { get; private set; }

        [Column(TypeName = "int")]
        public Int32? cod_transportador { get; private set; }

        [Column(TypeName = "int")]
        public Int32? tipo_cobranca_frete { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? ativo { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_tabela_preco { get; private set; }

        [Column(TypeName = "money")]
        public decimal? valor_credito { get; private set; }

        [Column(TypeName = "int")]
        public Int32? cod_vendedor { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_insert { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_disponivel_faturamento { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? mensagem_falha_faturamento { get; private set; }

        [Column(TypeName = "tinyint")]
        public Int32? id_tipo_b2c { get; private set; }

        [Column(TypeName = "varchar(200)")]
        public string? ecommerce_origem { get; private set; }

        [Key]
        [Column(TypeName = "varchar(40)")]
        public string? order_id { get; private set; }

        public B2CConsultaPedidos() { }

        public B2CConsultaPedidos(
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
            string? portal,
            string? mensagem_falha_faturamento,
            string? id_tipo_b2c,
            string? ecommerce_origem,
            string? order_id
        )
        {
            lastupdateon = DateTime.Now;

            this.id_pedido =
                id_pedido == String.Empty ? 0
                : Convert.ToInt32(id_pedido);

            this.dt_pedido =
                dt_pedido == String.Empty ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_pedido);

            this.cod_cliente_erp =
                cod_cliente_erp == String.Empty ? 0
                : Convert.ToInt32(cod_cliente_erp);

            this.cod_cliente_b2c =
                cod_cliente_b2c == String.Empty ? 0
                : Convert.ToInt32(cod_cliente_b2c);

            this.vl_frete =
                vl_frete == String.Empty ? 0
                : Convert.ToDecimal(vl_frete);

            this.forma_pgto =
                forma_pgto == String.Empty ? 0
                : Convert.ToInt32(forma_pgto);

            this.plano_pagamento =
               plano_pagamento == String.Empty ? 0
               : Convert.ToInt32(plano_pagamento);

            this.anotacao =
                anotacao == String.Empty ? ""
                : anotacao.Substring(
                    0,
                    anotacao.Length > 400 ? 400
                    : anotacao.Length
                );

            this.taxa_impressao =
                taxa_impressao == String.Empty ? 0
                : Convert.ToDecimal(taxa_impressao);

            this.finalizado =
                finalizado == String.Empty ? 0
                : Convert.ToInt32(finalizado);

            this.valor_frete_gratis =
                valor_frete_gratis == String.Empty ? 0
                : Convert.ToDecimal(valor_frete_gratis);

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

            this.ativo =
                ativo == String.Empty ? 0
                : Convert.ToInt32(ativo);

            this.empresa =
                empresa == String.Empty ? 0
                : Convert.ToInt32(empresa);

            this.id_tabela_preco =
                id_tabela_preco == String.Empty ? 0
                : Convert.ToInt32(id_tabela_preco);

            this.valor_credito =
                valor_credito == String.Empty ? 0
                : Convert.ToDecimal(valor_credito);

            this.cod_vendedor =
                cod_vendedor == String.Empty ? 0
                : Convert.ToInt32(cod_vendedor);

            this.dt_insert =
                dt_insert == String.Empty ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_insert);

            this.dt_disponivel_faturamento =
                dt_disponivel_faturamento == String.Empty ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_disponivel_faturamento);

            this.mensagem_falha_faturamento =
                mensagem_falha_faturamento == String.Empty ? ""
                : mensagem_falha_faturamento;

            this.id_tipo_b2c =
                id_tipo_b2c == String.Empty ? 0
                : Convert.ToInt32(id_tipo_b2c);

            this.ecommerce_origem =
                ecommerce_origem == String.Empty ? ""
                : ecommerce_origem.Substring(
                    0,
                    ecommerce_origem.Length > 200 ? 200
                    : ecommerce_origem.Length
                );

            this.order_id =
                order_id == String.Empty ? ""
                : order_id.Substring(
                    0,
                    order_id.Length > 40 ? 40
                    : order_id.Length
                );

            this.timestamp =
                timestamp == String.Empty ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                portal == String.Empty ? 0
                : Convert.ToInt32(portal);
        }
    }
}
