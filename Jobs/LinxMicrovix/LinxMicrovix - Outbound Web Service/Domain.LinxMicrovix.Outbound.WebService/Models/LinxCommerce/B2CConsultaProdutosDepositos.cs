using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosDepositos
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_deposito { get; private set; }
        public string? nome_deposito { get; private set; }
        public string? disponivel { get; private set; }
        public Int32? disponivel_transferencia { get; private set; }
        public Int32? disponivel_franquias { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosDepositos() { }

        public B2CConsultaProdutosDepositos(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutosDepositos record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_deposito = CustomConvertersExtensions.ConvertToInt32Validation(record.id_deposito);
            this.disponivel_transferencia = CustomConvertersExtensions.ConvertToInt32Validation(record.disponivel_transferencia);
            this.disponivel_franquias = CustomConvertersExtensions.ConvertToInt32Validation(record.disponivel_franquias);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
               
            this.nome_deposito = record.nome_deposito;
            this.disponivel = record.disponivel;
            this.recordXml = recordXml;
        }
    }
}
