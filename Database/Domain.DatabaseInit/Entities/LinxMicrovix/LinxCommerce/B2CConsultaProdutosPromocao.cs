using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxCommerce
{
    [Table("B2CConsultaProdutosPromocao", Schema = "untreated")]
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
        [LengthValidation(length: 1, propertyName: "ativa")]
        public string? ativa { get; private set; }

        [Column(TypeName = "int")]
        public Int32? codigo_campanha { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? promocao_opcional { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "referencia")]
        public string? referencia { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaProdutosPromocao() { }

        public B2CConsultaProdutosPromocao(
            List<ValidationResult> listValidations,
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
                ConvertToInt32Validation.IsValid(codigo_promocao, "codigo_promocao", listValidations) ?
                Convert.ToInt32(codigo_promocao) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.preco =
                ConvertToDecimalValidation.IsValid(preco, "preco", listValidations) ?
                Convert.ToDecimal(preco) :
                0;

            this.data_inicio =
                ConvertToDateTimeValidation.IsValid(data_inicio, "data_inicio", listValidations) ?
                Convert.ToDateTime(data_inicio) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_termino =
                ConvertToDateTimeValidation.IsValid(data_termino, "data_termino", listValidations) ?
                Convert.ToDateTime(data_termino) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_cadastro =
                ConvertToDateTimeValidation.IsValid(data_cadastro, "data_cadastro", listValidations) ?
                Convert.ToDateTime(data_cadastro) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.codigo_campanha =
                ConvertToInt32Validation.IsValid(codigo_campanha, "codigo_campanha", listValidations) ?
                Convert.ToInt32(codigo_campanha) :
                0;

            this.promocao_opcional =
                ConvertToInt32Validation.IsValid(promocao_opcional, "promocao_opcional", listValidations) ?
                Convert.ToInt32(promocao_opcional) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.ativa = ativa;
            this.referencia = referencia;
        }
    }
}
