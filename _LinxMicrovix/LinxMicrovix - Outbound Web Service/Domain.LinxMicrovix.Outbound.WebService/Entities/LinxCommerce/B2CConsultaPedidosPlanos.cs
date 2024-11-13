using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxCommerce
{
    public class B2CConsultaPedidosPlanos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? id_pedido_planos { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_pedido { get; private set; }

        [Column(TypeName = "int")]
        public Int32? plano_pagamento { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_plano { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? nsu_sitef { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? cod_autorizacao { get; private set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? texto_comprovante { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? cod_loja_sitef { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaPedidosPlanos() { }

        public B2CConsultaPedidosPlanos(
            string? id_pedido_planos,
            string? id_pedido,
            string? plano_pagamento,
            string? valor_plano,
            string? nsu_sitef,
            string? cod_autorizacao,
            string? texto_comprovante,
            string? cod_loja_sitef,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_pedido_planos =
                String.IsNullOrEmpty(id_pedido_planos) ? 0
                : Convert.ToInt32(id_pedido_planos);

            this.id_pedido =
                String.IsNullOrEmpty(id_pedido) ? 0
                : Convert.ToInt32(id_pedido);

            this.plano_pagamento =
                String.IsNullOrEmpty(plano_pagamento) ? 0
                : Convert.ToInt32(plano_pagamento);

            this.valor_plano =
                String.IsNullOrEmpty(valor_plano) ? 0
                : Convert.ToDecimal(valor_plano);

            this.nsu_sitef =
                String.IsNullOrEmpty(nsu_sitef) ? ""
                : nsu_sitef.Substring(
                    0,
                    nsu_sitef.Length > 20 ? 20
                    : nsu_sitef.Length
                );

            this.cod_autorizacao =
                String.IsNullOrEmpty(cod_autorizacao) ? ""
                : cod_autorizacao.Substring(
                    0,
                    cod_autorizacao.Length > 50 ? 50
                    : cod_autorizacao.Length
                );

            this.texto_comprovante =
                String.IsNullOrEmpty(texto_comprovante) ? ""
                : texto_comprovante;

            this.cod_loja_sitef =
                String.IsNullOrEmpty(cod_loja_sitef) ? ""
                : cod_loja_sitef.Substring(
                    0,
                    cod_loja_sitef.Length > 10 ? 10
                    : cod_loja_sitef.Length
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
