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

        [Column(TypeName = "money")]
        public decimal? valor_nota { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? serie { get; private set; }

        [Column(TypeName = "money")]
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
                id_nfe == String.Empty ? 0
                : Convert.ToInt32(id_nfe);

            this.id_pedido =
                id_pedido == String.Empty ? 0
                : Convert.ToInt32(id_pedido);

            this.documento =
                documento == String.Empty ? 0
                : Convert.ToInt32(documento);

            this.data_emissao =
                data_emissao == String.Empty ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(data_emissao);

            this.chave_nfe =
                chave_nfe == String.Empty ? ""
                : chave_nfe.Substring(
                    0,
                    chave_nfe.Length > 44 ? 44
                    : chave_nfe.Length
                );

            this.situacao =
                situacao == String.Empty ? 0
                : Convert.ToInt32(situacao);

            this.xml =
                xml == String.Empty ? ""
                : xml;

            this.excluido =
                excluido == String.Empty ? 0
                : Convert.ToInt32(excluido);

            this.identificador_microvix =
                identificador_microvix == String.Empty ? null
                : Guid.Parse(identificador_microvix);

            this.dt_insert =
                dt_insert == String.Empty ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_insert);

            this.valor_nota =
                valor_nota == String.Empty ? 0
                : Convert.ToDecimal(valor_nota);

            this.serie =
                serie == String.Empty ? ""
                : serie.Substring(
                    0,
                    serie.Length > 10 ? 10
                    : serie.Length
                );

            this.frete =
                frete == String.Empty ? 0
                : Convert.ToDecimal(frete);

            this.nProt =
                nProt == String.Empty ? ""
                : nProt.Substring(
                    0,
                    nProt.Length > 15 ? 15
                    : nProt.Length
                );

            this.codigo_modelo_nf =
                codigo_modelo_nf == String.Empty ? ""
                : codigo_modelo_nf.Substring(
                    0,
                    codigo_modelo_nf.Length > 3 ? 3
                    : codigo_modelo_nf.Length
                );

            this.justificativa =
                justificativa == String.Empty ? ""
                : justificativa.Substring(
                    0,
                    justificativa.Length > 255 ? 255
                    : justificativa.Length
                );

            this.tpAmb =
                tpAmb == String.Empty ? 0
                : Convert.ToInt32(tpAmb);

            this.timestamp =
                timestamp == String.Empty ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                portal == String.Empty ? 0
                : Convert.ToInt32(portal);
        }
    }
}
