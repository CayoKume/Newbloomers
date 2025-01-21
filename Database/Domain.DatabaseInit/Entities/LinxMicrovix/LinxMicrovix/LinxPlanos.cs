using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxPlanos", Schema = "untreated")]
    public class LinxPlanos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? plano { get; private set; }

        [Column(TypeName = "varchar(35)")]
        [LengthValidation(length: 35, propertyName: "desc_plano")]
        public string? desc_plano { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtde_parcelas { get; private set; }

        [Column(TypeName = "int")]
        public Int32? prazo_entre_parcelas { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "tipo_plano")]
        public string? tipo_plano { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? indice_plano { get; private set; }

        [Column(TypeName = "int")]
        public Int32? cod_forma_pgto { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "forma_pgto")]
        public string? forma_pgto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? conta_central { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "tipo_transacao")]
        public string? tipo_transacao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? taxa_financeira { get; private set; }

        [Column(TypeName = "int")]
        public DateTime? dt_upd { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "desativado")]
        public string? desativado { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "usa_tef")]
        public string? usa_tef { get; private set; }

        [Column(TypeName = "int")]
        public Int64? timestamp { get; private set; }

        public LinxPlanos() { }

        public LinxPlanos(
            List<ValidationResult> listValidations,
            string? portal,
            string? plano,
            string? desc_plano,
            string? qtde_parcelas,
            string? prazo_entre_parcelas,
            string? tipo_plano,
            string? indice_plano,
            string? cod_forma_pgto,
            string? forma_pgto,
            string? conta_central,
            string? tipo_transacao,
            string? taxa_financeira,
            string? dt_upd,
            string? desativado,
            string? usa_tef,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.plano =
                ConvertToInt32Validation.IsValid(plano, "plano", listValidations) ?
                Convert.ToInt32(plano) :
                0;

            this.qtde_parcelas =
                ConvertToInt32Validation.IsValid(qtde_parcelas, "qtde_parcelas", listValidations) ?
                Convert.ToInt32(qtde_parcelas) :
                0;

            this.prazo_entre_parcelas =
                ConvertToInt32Validation.IsValid(prazo_entre_parcelas, "prazo_entre_parcelas", listValidations) ?
                Convert.ToInt32(prazo_entre_parcelas) :
                0;

            this.cod_forma_pgto =
                ConvertToInt32Validation.IsValid(cod_forma_pgto, "cod_forma_pgto", listValidations) ?
                Convert.ToInt32(cod_forma_pgto) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.dt_upd =
               ConvertToDateTimeValidation.IsValid(dt_upd, "dt_upd", listValidations) ?
               Convert.ToDateTime(dt_upd) :
               new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.indice_plano =
                ConvertToDecimalValidation.IsValid(indice_plano, "indice_plano", listValidations) ?
                Convert.ToDecimal(indice_plano) :
                0;

            this.taxa_financeira =
                ConvertToDecimalValidation.IsValid(taxa_financeira, "taxa_financeira", listValidations) ?
                Convert.ToDecimal(taxa_financeira) :
                0;

            this.desc_plano = desc_plano;
            this.tipo_plano = tipo_plano;
            this.forma_pgto = forma_pgto;
            this.tipo_transacao = tipo_transacao;
            this.desativado = desativado;
            this.usa_tef = usa_tef;
        }
    }
}
