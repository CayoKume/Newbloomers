
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxTrocaUnificadaResumoVendasItens
    {
        public DateTime? lastupdateon { get; private set; }
        public Int64? id_troca_unificada_resumo_vendas_itens { get; private set; }
        public Int64? id_troca_unificada_resumo_vendas { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public Int32? transacao { get; private set; }
        public string? serial { get; private set; }
        public decimal? valor_liquido { get; private set; }
        public DateTime? data_validade { get; private set; }
        public bool? venda_referenciada { get; private set; }
        public bool? token_utilizado { get; private set; }
        public decimal? quantidade { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxTrocaUnificadaResumoVendasItens() { }

        public LinxTrocaUnificadaResumoVendasItens(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxTrocaUnificadaResumoVendasItens record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.transacao = CustomConvertersExtensions.ConvertToInt32Validation(record.transacao);
            this.id_troca_unificada_resumo_vendas_itens = CustomConvertersExtensions.ConvertToInt64Validation(record.id_troca_unificada_resumo_vendas_itens);
            this.id_troca_unificada_resumo_vendas = CustomConvertersExtensions.ConvertToInt64Validation(record.id_troca_unificada_resumo_vendas);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.valor_liquido = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_liquido);
            this.quantidade = CustomConvertersExtensions.ConvertToDecimalValidation(record.quantidade);
            this.venda_referenciada = CustomConvertersExtensions.ConvertToBooleanValidation(record.venda_referenciada);
            this.token_utilizado = CustomConvertersExtensions.ConvertToBooleanValidation(record.token_utilizado);
            this.data_validade = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_validade);
            this.serial = record.serial;
        }
    }
}
