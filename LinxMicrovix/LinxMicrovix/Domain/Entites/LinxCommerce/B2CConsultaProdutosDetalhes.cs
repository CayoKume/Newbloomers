using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaProdutosDetalhes
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_prod_det { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? saldo { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? controla_lote { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? nomeproduto_alternativo { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? referencia { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? localizacao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "smallint")]
        public Int32? tempo_preparacao_estoque { get; private set; }

        public B2CConsultaProdutosDetalhes() { }

        public B2CConsultaProdutosDetalhes(
            string? id_prod_det,
            string? codigoproduto,
            string? empresa,
            string? saldo,
            string? controla_lote,
            string? nomeproduto_alternativo,
            string? timestamp,
            string? referencia,
            string? localizacao,
            string? portal,
            string? tempo_preparacao_estoque
        )
        {
            lastupdateon = DateTime.Now;

            this.id_prod_det =
                String.IsNullOrEmpty(id_prod_det) ? 0
                : Convert.ToInt32(id_prod_det);

            this.codigoproduto =
                String.IsNullOrEmpty(codigoproduto) ? 0
                : Convert.ToInt64(codigoproduto);

            this.empresa =
                String.IsNullOrEmpty(empresa) ? 0
                : Convert.ToInt32(empresa);

            this.saldo =
                String.IsNullOrEmpty(saldo) ? 0
                : Convert.ToDecimal(saldo);

            this.controla_lote =
                String.IsNullOrEmpty(controla_lote) ? 0
                : Convert.ToInt32(controla_lote);

            this.nomeproduto_alternativo =
                String.IsNullOrEmpty(nomeproduto_alternativo) ? ""
                : nomeproduto_alternativo.Substring(
                    0,
                    nomeproduto_alternativo.Length > 250 ? 250
                    : nomeproduto_alternativo.Length
                );

            this.referencia =
                String.IsNullOrEmpty(referencia) ? ""
                : referencia.Substring(
                    0,
                    referencia.Length > 20 ? 20
                    : referencia.Length
                );

            this.localizacao =
                String.IsNullOrEmpty(localizacao) ? ""
                : localizacao.Substring(
                    0,
                    localizacao.Length > 50 ? 50
                    : localizacao.Length
                );

            this.tempo_preparacao_estoque =
                String.IsNullOrEmpty(tempo_preparacao_estoque) ? 0
                : Convert.ToInt32(tempo_preparacao_estoque);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
