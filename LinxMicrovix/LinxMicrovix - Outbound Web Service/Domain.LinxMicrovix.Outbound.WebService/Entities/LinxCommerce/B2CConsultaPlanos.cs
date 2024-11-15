using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
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

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_minimo_parcela { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
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
                String.IsNullOrEmpty(plano) ? 0
                : Convert.ToInt32(plano);

            this.nome_plano =
                String.IsNullOrEmpty(nome_plano) ? ""
                : nome_plano.Substring(
                    0,
                    nome_plano.Length > 30 ? 30
                    : nome_plano.Length
                );

            this.forma_pagamento =
                String.IsNullOrEmpty(forma_pagamento) ? 0
                : Convert.ToInt32(forma_pagamento);

            this.qtde_parcelas =
                String.IsNullOrEmpty(qtde_parcelas) ? 0
                : Convert.ToInt32(qtde_parcelas);

            this.valor_minimo_parcela =
                String.IsNullOrEmpty(valor_minimo_parcela) ? 0
                : Convert.ToDecimal(valor_minimo_parcela);

            this.indice =
                String.IsNullOrEmpty(indice) ? 0
                : Convert.ToDecimal(indice);

            this.desativado =
                String.IsNullOrEmpty(desativado) ? ""
                : desativado.Substring(
                    0,
                    desativado.Length > 1 ? 1
                    : desativado.Length
                );

            this.tipo_plano =
                String.IsNullOrEmpty(tipo_plano) ? ""
                : tipo_plano.Substring(
                    0,
                    tipo_plano.Length > 1 ? 1
                    : tipo_plano.Length
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
