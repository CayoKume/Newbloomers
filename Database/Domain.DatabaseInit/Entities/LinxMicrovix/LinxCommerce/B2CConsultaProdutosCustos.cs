using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxCommerce
{
    [Table("B2CConsultaProdutosCustos", Schema = "untreated")]
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
            List<ValidationResult> listValidations,
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
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.id_produtos_custos =
                ConvertToInt32Validation.IsValid(id_produtos_custos, "id_produtos_custos", listValidations) ?
                Convert.ToInt32(id_produtos_custos) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.custoicms1 =
                ConvertToDecimalValidation.IsValid(custoicms1, "custoicms1", listValidations) ?
                Convert.ToDecimal(custoicms1) :
                0;

            this.ipi1 =
                ConvertToDecimalValidation.IsValid(ipi1, "ipi1", listValidations) ?
                Convert.ToDecimal(ipi1) :
                0;

            this.markup =
                ConvertToDecimalValidation.IsValid(markup, "markup", listValidations) ?
                Convert.ToDecimal(markup) :
                0;

            this.customedio =
                ConvertToDecimalValidation.IsValid(customedio, "customedio", listValidations) ?
                Convert.ToDecimal(customedio) :
                0;

            this.frete1 =
                ConvertToDecimalValidation.IsValid(frete1, "frete1", listValidations) ?
                Convert.ToDecimal(frete1) :
                0;

            this.precisao =
                ConvertToInt32Validation.IsValid(precisao, "precisao", listValidations) ?
                Convert.ToInt32(precisao) :
                0;

            this.precominimo =
                ConvertToDecimalValidation.IsValid(precominimo, "precominimo", listValidations) ?
                Convert.ToDecimal(precominimo) :
                0;

            this.dt_update =
                ConvertToDateTimeValidation.IsValid(dt_update, "dt_update", listValidations) ?
                Convert.ToDateTime(dt_update) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.custoliquido =
                ConvertToDecimalValidation.IsValid(custoliquido, "custoliquido", listValidations) ?
                Convert.ToDecimal(custoliquido) :
                0;

            this.precovenda =
                ConvertToDecimalValidation.IsValid(precovenda, "precovenda", listValidations) ?
                Convert.ToDecimal(precovenda) :
                0;

            this.custototal =
                ConvertToDecimalValidation.IsValid(custototal, "custototal", listValidations) ?
                Convert.ToDecimal(custototal) :
                0;

            this.precocompra =
                ConvertToDecimalValidation.IsValid(precocompra, "precocompra", listValidations) ?
                Convert.ToDecimal(precocompra) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;
        }
    }
}
