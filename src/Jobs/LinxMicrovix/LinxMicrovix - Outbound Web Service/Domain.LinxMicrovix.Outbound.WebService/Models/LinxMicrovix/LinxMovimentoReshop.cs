
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoReshop
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_movimento_campanha_reshop { get; private set; }
        public Int32? id_campanha { get; private set; }
        public Guid? identificador { get; private set; }
        public string? nome { get; private set; }
        public string? descricao { get; private set; }
        public bool? aplicar_desconto_venda { get; private set; }
        public decimal? valor_desconto_subtotal { get; private set; }
        public decimal? valor_desconto_completo { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoReshop() { }

        public LinxMovimentoReshop(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoReshop record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_movimento_campanha_reshop = CustomConvertersExtensions.ConvertToInt32Validation(record.id_movimento_campanha_reshop);
            this.id_campanha = CustomConvertersExtensions.ConvertToInt32Validation(record.id_campanha);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.valor_desconto_subtotal = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_desconto_subtotal);
            this.valor_desconto_completo = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_desconto_completo);
            this.aplicar_desconto_venda = CustomConvertersExtensions.ConvertToBooleanValidation(record.aplicar_desconto_venda);
            this.identificador = Guid.Parse(record.identificador);
            this.descricao = record.descricao;
            this.nome = record.nome;
            this.recordXml = recordXml;
            this.recordKey = $"[{record.identificador}]|[{record.id_movimento_campanha_reshop}]|[{record.id_campanha}]|[{record.timestamp}]";
        }
    }
}
