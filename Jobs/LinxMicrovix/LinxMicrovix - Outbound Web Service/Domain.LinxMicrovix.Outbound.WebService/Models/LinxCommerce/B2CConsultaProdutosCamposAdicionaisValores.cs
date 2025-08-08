using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisValores
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_campo_valor { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public Int32? id_campo_detalhe { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosCamposAdicionaisValores() { }

        public B2CConsultaProdutosCamposAdicionaisValores(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutosCamposAdicionaisValores record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_campo_valor = CustomConvertersExtensions.ConvertToInt32Validation(record.id_campo_valor);
            this.id_campo_detalhe = CustomConvertersExtensions.ConvertToInt32Validation(record.id_campo_detalhe);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
               
            this.recordXml = recordXml;
        }
    }
}
