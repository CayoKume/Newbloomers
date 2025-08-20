
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaItem
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_devolucao_remanejo_fabrica_item { get; private set; }
        public Int32? id_devolucao_remanejo_fabrica { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public string? codigo_produto_franqueadora { get; private set; }
        public Int32? quantidade { get; private set; }
        public string? codebar { get; private set; }
        public string? serial { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxDevolucaoRemanejoFabricaItem() { }

        public LinxDevolucaoRemanejoFabricaItem(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxDevolucaoRemanejoFabricaItem record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_devolucao_remanejo_fabrica_item = CustomConvertersExtensions.ConvertToInt32Validation(record.id_devolucao_remanejo_fabrica_item);
            this.id_devolucao_remanejo_fabrica = CustomConvertersExtensions.ConvertToInt32Validation(record.id_devolucao_remanejo_fabrica);
            this.quantidade = CustomConvertersExtensions.ConvertToInt32Validation(record.quantidade);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.codigo_produto_franqueadora = record.codigo_produto_franqueadora;
            this.codebar = record.codebar;
            this.serial = record.serial;
        }
    }
}
