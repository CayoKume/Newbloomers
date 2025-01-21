using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    [Table("B2CConsultaNFe", Schema = "linx_microvix_commerce")]
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
        [LengthValidation(length: 44, propertyName: "chave_nfe")]
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
        [LengthValidation(length: 10, propertyName: "serie")]
        public string? serie { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? frete { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "varchar(15)")]
        [LengthValidation(length: 15, propertyName: "nProt")]
        public string? nProt { get; private set; }

        [Column(TypeName = "varchar(3)")]
        [LengthValidation(length: 3, propertyName: "codigo_modelo_nf")]
        public string? codigo_modelo_nf { get; private set; }

        [Column(TypeName = "varchar(255)")]
        [LengthValidation(length: 255, propertyName: "justificativa")]
        public string? justificativa { get; private set; }

        [Column(TypeName = "int")]
        public Int32? tpAmb { get; private set; }

        public B2CConsultaNFe() { }

        public B2CConsultaNFe(
            List<ValidationResult> listValidations,
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
                ConvertToInt32Validation.IsValid(id_nfe, "id_nfe", listValidations) ?
                Convert.ToInt32(id_nfe) :
                0;

            this.id_pedido =
                ConvertToInt32Validation.IsValid(id_pedido, "id_pedido", listValidations) ?
                Convert.ToInt32(id_pedido) :
                0;

            this.documento =
                ConvertToInt32Validation.IsValid(documento, "documento", listValidations) ?
                Convert.ToInt32(documento) :
                0;

            this.data_emissao =
                ConvertToDateTimeValidation.IsValid(data_emissao, "data_emissao", listValidations) ?
                Convert.ToDateTime(data_emissao) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.situacao =
                ConvertToInt32Validation.IsValid(situacao, "situacao", listValidations) ?
                Convert.ToInt32(situacao) :
                0;

            this.excluido =
                ConvertToInt32Validation.IsValid(excluido, "excluido", listValidations) ?
                Convert.ToInt32(excluido) :
                0;

            this.identificador_microvix =
                String.IsNullOrEmpty(identificador_microvix) ? null
                : Guid.Parse(identificador_microvix);

            this.dt_insert =
               ConvertToDateTimeValidation.IsValid(dt_insert, "dt_insert", listValidations) ?
               Convert.ToDateTime(dt_insert) :
               new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.valor_nota =
                ConvertToDecimalValidation.IsValid(valor_nota, "valor_nota", listValidations) ?
                Convert.ToDecimal(valor_nota) :
                0;

            this.frete =
                ConvertToDecimalValidation.IsValid(frete, "frete", listValidations) ?
                Convert.ToDecimal(frete) :
                0;

            this.tpAmb =
                ConvertToInt32Validation.IsValid(tpAmb, "tpAmb", listValidations) ?
                Convert.ToInt32(tpAmb) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.chave_nfe = chave_nfe;
            this.xml = xml;
            this.nProt = nProt;
            this.codigo_modelo_nf = codigo_modelo_nf;
            this.justificativa = justificativa;
            this.serie = serie;
        }
    }
}
