
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoRemessasAcertos
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_remessas_acertos { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? empresa { get; private set; }
        public Int32? id_remessas { get; private set; }
        public Guid? identificador_venda { get; private set; }
        public Guid? identificador_retorno { get; private set; }
        public Guid? identificador_devolucao { get; private set; }
        public DateTime? data { get; private set; }
        public Int64? id_vendas_pos { get; private set; }
        public bool? excluido { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoRemessasAcertos() { }

        public LinxMovimentoRemessasAcertos(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoRemessasAcertos record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.id_remessas_acertos = CustomConvertersExtensions.ConvertToInt32Validation(record.id_remessas_acertos);
            this.id_remessas = CustomConvertersExtensions.ConvertToInt32Validation(record.id_remessas);
            this.identificador_venda = Guid.Parse(record.identificador_venda);
            this.identificador_retorno = Guid.Parse(record.identificador_retorno);
            this.identificador_devolucao = Guid.Parse(record.identificador_devolucao);
            this.data = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data);
            this.excluido = CustomConvertersExtensions.ConvertToBooleanValidation(record.excluido);
            this.id_vendas_pos = CustomConvertersExtensions.ConvertToInt64Validation(record.id_vendas_pos);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            
        }
    }
}
