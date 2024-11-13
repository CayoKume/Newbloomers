using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaProdutosCustos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_produtos_custos { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? custoicms1 { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? ipi1 { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? markup { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? customedio { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? frete1 { get; private set; }

        [Column(TypeName = "int")]
        public Int32? precisao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? precominimo { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_update { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? custoliquido { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? precovenda { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? custototal { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? precocompra { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaProdutosCustos() { }

        public B2CConsultaProdutosCustos(
            string? id_produtos_custos,
            string? codigoproduto,
            string? empresa,
            string? custoicms1,
            string? ipi1,
            string? markup,
            string? customedio,
            string? frete1,
            string? precisao,
            string? precominimo,
            string? dt_update,
            string? custoliquido,
            string? precovenda,
            string? custototal,
            string? precocompra,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.codigoproduto =
                String.IsNullOrEmpty(codigoproduto) ? 0
                : Convert.ToInt64(codigoproduto);

            this.id_produtos_custos =
                String.IsNullOrEmpty(id_produtos_custos) ? 0
                : Convert.ToInt32(id_produtos_custos);

            this.empresa =
                String.IsNullOrEmpty(empresa) ? 0
                : Convert.ToInt32(empresa);

            this.custoicms1 =
                String.IsNullOrEmpty(custoicms1) ? 0
                : Convert.ToDecimal(custoicms1);

            this.ipi1 =
                String.IsNullOrEmpty(ipi1) ? 0
                : Convert.ToDecimal(ipi1);

            this.markup =
                String.IsNullOrEmpty(markup) ? 0
                : Convert.ToDecimal(markup);

            this.customedio =
                String.IsNullOrEmpty(customedio) ? 0
                : Convert.ToDecimal(customedio);

            this.frete1 =
                String.IsNullOrEmpty(frete1) ? 0
                : Convert.ToDecimal(frete1);

            this.precisao =
                String.IsNullOrEmpty(precisao) ? 0
                : Convert.ToInt32(precisao);

            this.precominimo =
                String.IsNullOrEmpty(precominimo) ? 0
                : Convert.ToDecimal(precominimo);

            this.dt_update =
                String.IsNullOrEmpty(dt_update) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_update);

            this.custoliquido =
                String.IsNullOrEmpty(custoliquido) ? 0
                : Convert.ToDecimal(custoliquido);

            this.precovenda =
                String.IsNullOrEmpty(precovenda) ? 0
                : Convert.ToDecimal(precovenda);

            this.custototal =
                String.IsNullOrEmpty(custototal) ? 0
                : Convert.ToDecimal(custototal);

            this.precocompra =
                String.IsNullOrEmpty(precocompra) ? 0
                : Convert.ToDecimal(precocompra);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
