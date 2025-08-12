
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxCupomDescontoVendas
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? empresa { get; private set; }
        public Int32? id_cupom_desconto_vendas { get; private set; }
        public Int32? id_cupom_desconto { get; private set; }
        public Guid? identificador { get; private set; }
        public decimal? valor { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? id_vendas_pos { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxCupomDescontoVendas() { }

        public LinxCupomDescontoVendas(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxCupomDescontoVendas record, string recordXml) {
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.id_cupom_desconto_vendas = CustomConvertersExtensions.ConvertToInt32Validation(record.id_cupom_desconto_vendas);
            this.id_cupom_desconto = CustomConvertersExtensions.ConvertToInt32Validation(record.id_cupom_desconto);
            this.id_vendas_pos = CustomConvertersExtensions.ConvertToInt32Validation(record.id_vendas_pos);
            this.valor = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor);
            this.identificador = Guid.Parse(record.identificador);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            
        }
    }
}
