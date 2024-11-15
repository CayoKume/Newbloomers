using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaProdutosPromocao
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigo_promocao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? preco { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? data_inicio { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? data_termino { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_cadastro { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? ativa { get; private set; }

        [Column(TypeName = "int")]
        public Int32? codigo_campanha { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? promocao_opcional { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? referencia { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaProdutosPromocao() { }

        public B2CConsultaProdutosPromocao(
            string? codigo_promocao,
            string? empresa,
            string? codigoproduto,
            string? preco,
            string? data_inicio,
            string? data_termino,
            string? data_cadastro,
            string? ativa,
            string? codigo_campanha,
            string? promocao_opcional,
            string? timestamp,
            string? referencia,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.codigo_promocao =
                String.IsNullOrEmpty(codigo_promocao) ? 0
                : Convert.ToInt32(codigo_promocao);

            this.empresa =
                String.IsNullOrEmpty(empresa) ? 0
                : Convert.ToInt32(empresa);

            this.codigoproduto =
                String.IsNullOrEmpty(codigoproduto) ? 0
                : Convert.ToInt64(codigoproduto);

            this.preco =
                String.IsNullOrEmpty(preco) ? 0
                : Convert.ToDecimal(preco);

            this.data_inicio =
                String.IsNullOrEmpty(data_inicio) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(data_inicio);

            this.data_termino =
                String.IsNullOrEmpty(data_termino) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(data_termino);

            this.data_cadastro =
                String.IsNullOrEmpty(data_cadastro) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(data_cadastro);

            this.ativa =
                String.IsNullOrEmpty(ativa) ? ""
                : ativa.Substring(
                    0,
                    ativa.Length > 1 ? 1
                    : ativa.Length
                );

            this.codigo_campanha =
                String.IsNullOrEmpty(codigo_campanha) ? 0
                : Convert.ToInt32(codigo_campanha);

            this.promocao_opcional =
                String.IsNullOrEmpty(promocao_opcional) ? 0
                : Convert.ToInt32(promocao_opcional);

            this.referencia =
                String.IsNullOrEmpty(referencia) ? ""
                : referencia.Substring(
                    0,
                    referencia.Length > 20 ? 20
                    : referencia.Length
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
