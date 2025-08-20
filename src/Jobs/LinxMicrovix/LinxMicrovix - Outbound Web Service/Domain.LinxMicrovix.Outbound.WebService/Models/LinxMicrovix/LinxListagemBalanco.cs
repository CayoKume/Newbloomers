
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxListagemBalanco
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_balanco { get; private set; }
        public DateTime? data { get; private set; }
        public string? nome_arquivo { get; private set; }
        public string? processado { get; private set; }
        public DateTime? data_ultimo_processamento { get; private set; }
        public Int32 qtde_produtos { get; private set; }
        public Int32? qtde_itens { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxListagemBalanco() { }

        public LinxListagemBalanco(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxListagemBalanco record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_balanco = CustomConvertersExtensions.ConvertToInt32Validation(record.id_balanco);
            this.qtde_produtos = CustomConvertersExtensions.ConvertToInt32Validation(record.qtde_produtos);
            this.qtde_itens = CustomConvertersExtensions.ConvertToInt32Validation(record.qtde_itens);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.data =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data);
            this.data_ultimo_processamento =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_ultimo_processamento);
            this.nome_arquivo = record.nome_arquivo;
            this.processado = record.processado;
        }
    }
}
