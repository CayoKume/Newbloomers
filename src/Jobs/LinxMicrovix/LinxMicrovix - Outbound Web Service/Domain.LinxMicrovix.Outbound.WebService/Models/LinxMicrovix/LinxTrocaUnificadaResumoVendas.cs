
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxTrocaUnificadaResumoVendas
    {
        public DateTime? lastupdateon { get; private set; }
        public Int64? id_troca_unificada_resumo_vendas { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? empresa { get; private set; }
        public string? token { get; private set; }
        public Guid? identificador { get; private set; }
        public Int32? documento { get; private set; }
        public string? serie { get; private set; }
        public DateTime? data_venda { get; private set; }
        public string? documento_cliente { get; private set; }
        public bool? venda_cancelada { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxTrocaUnificadaResumoVendas() { }

        public LinxTrocaUnificadaResumoVendas(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxTrocaUnificadaResumoVendas record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.documento = CustomConvertersExtensions.ConvertToInt32Validation(record.documento);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.id_troca_unificada_resumo_vendas = CustomConvertersExtensions.ConvertToInt64Validation(record.id_troca_unificada_resumo_vendas);
            this.venda_cancelada = CustomConvertersExtensions.ConvertToBooleanValidation(record.venda_cancelada);
            this.data_venda =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_venda);
            this.identificador = Guid.Parse(record.identificador);
            this.serie = record.serie;
            this.token = record.token;
            this.documento_cliente = record.documento_cliente;
        }
    }
}
