using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosTags
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        public Int32? id_b2c_tags_produtos { get; private set; }

        public Int32? id_b2c_tags { get; private set; }

        public Int64? codigoproduto { get; private set; }

        public Int64? timestamp { get; private set; }

        [LengthValidation(length: 300, propertyName: "descricao_b2c_tags")]
        public string? descricao_b2c_tags { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosTags() { }

        public B2CConsultaProdutosTags(
            List<ValidationResult> listValidations,
            string? portal,
            string? id_b2c_tags_produtos,
            string? id_b2c_tags,
            string? codigoproduto,
            string? timestamp,
            string? descricao_b2c_tags,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_b2c_tags_produtos =
                ConvertToInt32Validation.IsValid(id_b2c_tags_produtos, "id_b2c_tags_produtos", listValidations) ?
                Convert.ToInt32(id_b2c_tags_produtos) :
                0;

            this.id_b2c_tags =
                ConvertToInt32Validation.IsValid(id_b2c_tags, "id_b2c_tags", listValidations) ?
                Convert.ToInt32(id_b2c_tags) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao_b2c_tags = descricao_b2c_tags;
            this.recordXml = recordXml;
        }
    }
}
