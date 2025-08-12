
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxRemessasIdentificadores
    {
        public DateTime? lastupdateon { get; private set; }
        public Guid? identificador_venda { get; private set; }
        public Guid? identificador_remessa { get; private set; }
        public Int32? id_remessas { get; private set; }
        public Int32? id_remessas_acertos { get; private set; }
        public Int32? transacao_acerto { get; private set; }
        public decimal? qtde_total_acerto { get; private set; }
        public Guid? identificador_devolucao { get; private set; }
        public Int32? transacao_remessa { get; private set; }
        public Int32? id_remessa_operacoes { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxRemessasIdentificadores() { }

        public LinxRemessasIdentificadores(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxRemessasIdentificadores record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_remessas = CustomConvertersExtensions.ConvertToInt32Validation(record.id_remessas);
            this.id_remessas_acertos = CustomConvertersExtensions.ConvertToInt32Validation(record.id_remessas_acertos);
            this.transacao_acerto = CustomConvertersExtensions.ConvertToInt32Validation(record.transacao_acerto);
            this.transacao_remessa = CustomConvertersExtensions.ConvertToInt32Validation(record.transacao_remessa);
            this.id_remessa_operacoes = CustomConvertersExtensions.ConvertToInt32Validation(record.id_remessa_operacoes);
            this.identificador_venda = Guid.Parse(record.identificador_venda);
            this.identificador_remessa = Guid.Parse(record.identificador_remessa);
            this.identificador_devolucao = Guid.Parse(record.identificador_devolucao);
            this.qtde_total_acerto = CustomConvertersExtensions.ConvertToDecimalValidation(record.qtde_total_acerto);
            
        }
    }
}
