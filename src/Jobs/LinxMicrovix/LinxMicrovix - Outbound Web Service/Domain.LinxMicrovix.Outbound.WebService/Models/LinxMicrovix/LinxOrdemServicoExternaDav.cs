
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxOrdemServicoExternaDav
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_vendas_pos_tmp_ordem_servico_externa { get; private set; }
        public Int32? id_vendas_pos { get; private set; }
        public string? codigo_ordem_servico_externa { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxOrdemServicoExternaDav() { }

        public LinxOrdemServicoExternaDav(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxOrdemServicoExternaDav record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_vendas_pos_tmp_ordem_servico_externa = CustomConvertersExtensions.ConvertToInt32Validation(record.id_vendas_pos_tmp_ordem_servico_externa);
            this.id_vendas_pos = CustomConvertersExtensions.ConvertToInt32Validation(record.id_vendas_pos);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.codigo_ordem_servico_externa = record.codigo_ordem_servico_externa;
        }
    }
}
