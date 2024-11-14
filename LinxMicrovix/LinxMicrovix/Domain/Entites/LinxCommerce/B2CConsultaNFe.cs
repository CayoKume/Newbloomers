using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaNFe
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_nfe { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_pedido { get; private set; }

        [Column(TypeName = "int")]
        public Int32? documento { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? data_emissao { get; private set; }

        [Key]
        [Column(TypeName = "char(44)")]
        public string? chave_nfe { get; private set; }

        [Column(TypeName = "tinyint")]
        public Int32? situacao { get; private set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? xml { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? excluido { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador_microvix { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_insert { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_nota { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? serie { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? frete { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }
        
        [Column(TypeName = "varchar(15)")]
        public string? nProt { get; private set; }

        [Column(TypeName = "varchar(3)")]
        public string? codigo_modelo_nf { get; private set; }

        [Column(TypeName = "varchar(255)")]
        public string? justificativa { get; private set; }

        [Column(TypeName = "int")]
        public Int32? tpAmb { get; private set; }

        public B2CConsultaNFe() { }

        public B2CConsultaNFe(
            string? id_nfe,
            string? id_pedido,
            string? documento,
            string? data_emissao,
            string? chave_nfe,
            string? situacao,
            string? xml,
            string? excluido,
            string? identificador_microvix,
            string? dt_insert,
            string? valor_nota,
            string? serie,
            string? frete,
            string? timestamp,
            string? portal,
            string? nProt,
            string? codigo_modelo_nf,
            string? justificativa,
            string? tpAmb
        )
        {
            lastupdateon = DateTime.Now;

            this.id_nfe =
                String.IsNullOrEmpty(id_nfe) ? 0
                : Convert.ToInt32(id_nfe);

            this.id_pedido =
                String.IsNullOrEmpty(id_pedido) ? 0
                : Convert.ToInt32(id_pedido);

            this.documento =
                String.IsNullOrEmpty(documento) ? 0
                : Convert.ToInt32(documento);

            this.data_emissao =
                String.IsNullOrEmpty(data_emissao) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(data_emissao);

            this.chave_nfe =
                String.IsNullOrEmpty(chave_nfe) ? ""
                : chave_nfe.Substring(
                    0,
                    chave_nfe.Length > 44 ? 44
                    : chave_nfe.Length
                );

            this.situacao =
                String.IsNullOrEmpty(situacao) ? 0
                : Convert.ToInt32(situacao);

            this.xml =
                String.IsNullOrEmpty(xml) ? ""
                : xml;

            this.excluido =
                String.IsNullOrEmpty(excluido) ? 0
                : Convert.ToInt32(excluido);

            this.identificador_microvix =
                String.IsNullOrEmpty(identificador_microvix) ? null
                : Guid.Parse(identificador_microvix);

            this.dt_insert =
                String.IsNullOrEmpty(dt_insert) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_insert);

            this.valor_nota =
                String.IsNullOrEmpty(valor_nota) ? 0
                : Convert.ToDecimal(valor_nota);

            this.serie =
                String.IsNullOrEmpty(serie) ? ""
                : serie.Substring(
                    0,
                    serie.Length > 10 ? 10
                    : serie.Length
                );

            this.frete =
                String.IsNullOrEmpty(frete) ? 0
                : Convert.ToDecimal(frete);

            this.nProt =
                String.IsNullOrEmpty(nProt) ? ""
                : nProt.Substring(
                    0,
                    nProt.Length > 15 ? 15
                    : nProt.Length
                );

            this.codigo_modelo_nf =
                String.IsNullOrEmpty(codigo_modelo_nf) ? ""
                : codigo_modelo_nf.Substring(
                    0,
                    codigo_modelo_nf.Length > 3 ? 3
                    : codigo_modelo_nf.Length
                );

            this.justificativa =
                String.IsNullOrEmpty(justificativa) ? ""
                : justificativa.Substring(
                    0,
                    justificativa.Length > 255 ? 255
                    : justificativa.Length
                );

            this.tpAmb =
                String.IsNullOrEmpty(tpAmb) ? 0
                : Convert.ToInt32(tpAmb);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
