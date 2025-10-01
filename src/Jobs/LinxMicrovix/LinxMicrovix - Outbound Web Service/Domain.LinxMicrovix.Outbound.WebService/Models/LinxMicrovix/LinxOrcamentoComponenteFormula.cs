
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxOrcamentoComponenteFormula
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_orcamento_componente_formula { get; private set; }
        public Int32? documento { get; private set; }
        public Int64? codigo_produto { get; private set; }
        public string? codigo_componente { get; private set; }
        public string? descricao_componente { get; private set; }
        public string? unidade { get; private set; }
        public decimal? quantidade { get; private set; }
        public decimal? valor_componente { get; private set; }
        public string? lote_componente { get; private set; }
        public DateTime? data_validade_lote { get; private set; }
        public string? codigo_ws { get; private set; }
        public Int32? portal { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxOrcamentoComponenteFormula() { }

        public LinxOrcamentoComponenteFormula(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxOrcamentoComponenteFormula record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_orcamento_componente_formula = CustomConvertersExtensions.ConvertToInt32Validation(record.id_orcamento_componente_formula);
            this.documento = CustomConvertersExtensions.ConvertToInt32Validation(record.documento);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.data_validade_lote = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_validade_lote);
            this.quantidade = CustomConvertersExtensions.ConvertToDecimalValidation(record.quantidade);
            this.valor_componente = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_componente);
            this.codigo_produto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigo_produto);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.codigo_componente = record.codigo_componente;
            this.descricao_componente = record.descricao_componente;
            this.unidade = record.unidade;
            this.lote_componente = record.lote_componente;
            this.codigo_ws = record.codigo_ws;
        }
    }
}
