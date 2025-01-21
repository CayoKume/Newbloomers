using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    [Table("B2CConsultaColecoes", Schema = "linx_microvix_commerce")]
    public class B2CConsultaColecoes
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? codigo_colecao { get; private set; }

        [Column(TypeName = "varchar(100)")]
        [LengthValidation(length: 100, propertyName: "nome_colecao")]
        public string? nome_colecao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "varchar(250)")]
        [LengthValidation(length: 250, propertyName: "marcas")]
        public string? marcas { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaColecoes() { }

        public B2CConsultaColecoes(
            List<ValidationResult> listValidations,
            string? codigo_colecao,
            string? nome_colecao,
            string? timestamp,
            string? marcas,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.codigo_colecao =
                ConvertToInt32Validation.IsValid(codigo_colecao, "codigo_colecao", listValidations) ?
                Convert.ToInt32(codigo_colecao) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_colecao = nome_colecao;
            this.marcas = marcas;
        }
    }
}
