
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosFlags
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? id_b2c_flags_produtos { get; private set; }
        public Int32? id_b2c_flags { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public Int64? timestamp { get; private set; }
        public string? descricao_b2c_flags { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosFlags() { }

        public B2CConsultaProdutosFlags(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutosFlags record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_b2c_flags_produtos = CustomConvertersExtensions.ConvertToInt32Validation(record.id_b2c_flags_produtos);
            this.id_b2c_flags = CustomConvertersExtensions.ConvertToInt32Validation(record.id_b2c_flags);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.descricao_b2c_flags = record.descricao_b2c_flags;
            this.recordXml = recordXml;
        }
    }
}
