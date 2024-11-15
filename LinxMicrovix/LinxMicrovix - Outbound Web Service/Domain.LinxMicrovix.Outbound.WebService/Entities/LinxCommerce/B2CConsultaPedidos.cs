using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
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

        [Column(TypeName = "decimal(10,2)")]
        public decimal? vl_frete { get; private set; }

        [Column(TypeName = "int")]
        public Int32? forma_pgto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? plano_pagamento { get; private set; }

        [Column(TypeName = "varchar(400)")]
        public string? anotacao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? taxa_impressao { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? finalizado { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
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

        [Column(TypeName = "decimal(10,2)")]
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
                String.IsNullOrEmpty(id_pedido) ? 0
                : Convert.ToInt32(id_pedido);

            this.dt_pedido =
                String.IsNullOrEmpty(dt_pedido) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_pedido);

            this.cod_cliente_erp =
                String.IsNullOrEmpty(cod_cliente_erp) ? 0
                : Convert.ToInt32(cod_cliente_erp);

            this.cod_cliente_b2c =
                String.IsNullOrEmpty(cod_cliente_b2c) ? 0
                : Convert.ToInt32(cod_cliente_b2c);

            this.vl_frete =
                String.IsNullOrEmpty(vl_frete) ? 0
                : Convert.ToDecimal(vl_frete);

            this.forma_pgto =
                String.IsNullOrEmpty(forma_pgto) ? 0
                : Convert.ToInt32(forma_pgto);

            this.plano_pagamento =
               String.IsNullOrEmpty(plano_pagamento) ? 0
               : Convert.ToInt32(plano_pagamento);

            this.anotacao =
                String.IsNullOrEmpty(anotacao) ? ""
                : anotacao.Substring(
                    0,
                    anotacao.Length > 400 ? 400
                    : anotacao.Length
                );

            this.taxa_impressao =
                String.IsNullOrEmpty(taxa_impressao) ? 0
                : Convert.ToDecimal(taxa_impressao);

            this.finalizado =
                String.IsNullOrEmpty(finalizado) ? 0
                : Convert.ToInt32(finalizado);

            this.valor_frete_gratis =
                String.IsNullOrEmpty(valor_frete_gratis) ? 0
                : Convert.ToDecimal(valor_frete_gratis);

            this.tipo_frete =
                String.IsNullOrEmpty(tipo_frete) ? 0
                : Convert.ToInt32(tipo_frete);

            this.id_status =
                String.IsNullOrEmpty(id_status) ? 0
                : Convert.ToInt32(id_status);

            this.cod_transportador =
                String.IsNullOrEmpty(cod_transportador) ? 0
                : Convert.ToInt32(cod_transportador);

            this.tipo_cobranca_frete =
                String.IsNullOrEmpty(tipo_cobranca_frete) ? 0
                : Convert.ToInt32(tipo_cobranca_frete);

            this.ativo =
                String.IsNullOrEmpty(ativo) ? 0
                : Convert.ToInt32(ativo);

            this.empresa =
                String.IsNullOrEmpty(empresa) ? 0
                : Convert.ToInt32(empresa);

            this.id_tabela_preco =
                String.IsNullOrEmpty(id_tabela_preco) ? 0
                : Convert.ToInt32(id_tabela_preco);

            this.valor_credito =
                String.IsNullOrEmpty(valor_credito) ? 0
                : Convert.ToDecimal(valor_credito);

            this.cod_vendedor =
                String.IsNullOrEmpty(cod_vendedor) ? 0
                : Convert.ToInt32(cod_vendedor);

            this.dt_insert =
                String.IsNullOrEmpty(dt_insert) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_insert);

            this.dt_disponivel_faturamento =
                String.IsNullOrEmpty(dt_disponivel_faturamento) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_disponivel_faturamento);

            this.mensagem_falha_faturamento =
                String.IsNullOrEmpty(mensagem_falha_faturamento) ? ""
                : mensagem_falha_faturamento;

            this.id_tipo_b2c =
                String.IsNullOrEmpty(id_tipo_b2c) ? 0
                : Convert.ToInt32(id_tipo_b2c);

            this.ecommerce_origem =
                String.IsNullOrEmpty(ecommerce_origem) ? ""
                : ecommerce_origem.Substring(
                    0,
                    ecommerce_origem.Length > 200 ? 200
                    : ecommerce_origem.Length
                );

            this.order_id =
                String.IsNullOrEmpty(order_id) ? ""
                : order_id.Substring(
                    0,
                    order_id.Length > 40 ? 40
                    : order_id.Length
                );

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
