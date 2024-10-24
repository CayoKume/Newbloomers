using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaPlanos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? plano { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? nome_plano { get; private set; }

        [Column(TypeName = "int")]
        public Int32? forma_pagamento { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtde_parcelas { get; private set; }

        [Column(TypeName = "money")]
        public decimal? valor_minimo_parcela { get; private set; }

        [Column(TypeName = "money")]
        public decimal? indice { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? desativado { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo_plano { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaPlanos() { }

        public B2CConsultaPlanos(
            string? plano,
            string? nome_plano,
            string? forma_pagamento,
            string? qtde_parcelas,
            string? valor_minimo_parcela,
            string? indice,
            string? timestamp,
            string? desativado,
            string? tipo_plano,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.plano =
                plano == String.Empty ? 0
                : Convert.ToInt32(plano);

            this.nome_plano =
                nome_plano == String.Empty ? ""
                : nome_plano.Substring(
                    0,
                    nome_plano.Length > 30 ? 30
                    : nome_plano.Length
                );

            this.forma_pagamento =
                forma_pagamento == String.Empty ? 0
                : Convert.ToInt32(forma_pagamento);

            this.qtde_parcelas =
                qtde_parcelas == String.Empty ? 0
                : Convert.ToInt32(qtde_parcelas);

            this.valor_minimo_parcela =
                valor_minimo_parcela == String.Empty ? 0
                : Convert.ToDecimal(valor_minimo_parcela);

            this.indice =
                indice == String.Empty ? 0
                : Convert.ToDecimal(indice);

            this.desativado =
                desativado == String.Empty ? ""
                : desativado.Substring(
                    0,
                    desativado.Length > 1 ? 1
                    : desativado.Length
                );

            this.tipo_plano =
                tipo_plano == String.Empty ? ""
                : tipo_plano.Substring(
                    0,
                    tipo_plano.Length > 1 ? 1
                    : tipo_plano.Length
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
