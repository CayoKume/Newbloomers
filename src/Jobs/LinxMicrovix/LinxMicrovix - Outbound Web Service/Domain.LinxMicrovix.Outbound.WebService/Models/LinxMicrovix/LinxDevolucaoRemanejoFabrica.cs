
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabrica
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_devolucao_remanejo_fabrica { get; private set; }
        public Int32? id_devolucao_remanejo_fabrica_tipo { get; private set; }
        public Int32? id_motivo_devolucao_fabrica { get; private set; }
        public Int32? id_deposito { get; private set; }
        public Int32? id_devolucao_remanejo_fabrica_status { get; private set; }
        public Int32? empresa { get; private set; }
        public Int32? fornecedor { get; private set; }
        public string? cfop { get; private set; }
        public string? serie { get; private set; }
        public string? codigo_solicitacao { get; private set; }
        public Int32? portal { get; private set; }
        public DateTime? data_solicitacao { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxDevolucaoRemanejoFabrica() { }

        public LinxDevolucaoRemanejoFabrica(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxDevolucaoRemanejoFabrica record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_devolucao_remanejo_fabrica = CustomConvertersExtensions.ConvertToInt32Validation(record.id_devolucao_remanejo_fabrica);
            this.id_devolucao_remanejo_fabrica_tipo = CustomConvertersExtensions.ConvertToInt32Validation(record.id_devolucao_remanejo_fabrica_tipo);
            this.id_motivo_devolucao_fabrica = CustomConvertersExtensions.ConvertToInt32Validation(record.id_motivo_devolucao_fabrica);
            this.id_deposito = CustomConvertersExtensions.ConvertToInt32Validation(record.id_deposito);
            this.id_devolucao_remanejo_fabrica_status = CustomConvertersExtensions.ConvertToInt32Validation(record.id_devolucao_remanejo_fabrica_status);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.fornecedor = CustomConvertersExtensions.ConvertToInt32Validation(record.fornecedor);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.data_solicitacao =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_solicitacao);
            this.cfop = record.cfop;
            this.serie = record.serie;
            this.codigo_solicitacao = record.codigo_solicitacao;
        }
    }
}
