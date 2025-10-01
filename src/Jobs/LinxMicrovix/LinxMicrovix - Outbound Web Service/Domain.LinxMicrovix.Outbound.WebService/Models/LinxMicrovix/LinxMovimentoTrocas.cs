
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoTrocas
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Guid? identificador { get; private set; }
        public Int64? num_vale { get; private set; }
        public decimal? valor_vale { get; private set; }
        public string? motivo { get; private set; }
        public Int32? doc_origem { get; private set; }
        public string? serie_origem { get; private set; }
        public Int32? doc_venda { get; private set; }
        public string? serie_venda { get; private set; }
        public bool? excluido { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? desfazimento { get; private set; }
        public Int32? empresa { get; private set; }
        public Int32? vale_cod_cliente { get; private set; }
        public Int64? vale_codigoproduto { get; private set; }
        public Int32? id_vale_ordem_servico_externa { get; private set; }
        public Int32? doc_venda_origem { get; private set; }
        public string? serie_venda_origem { get; private set; }
        public Int32? cod_cliente { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoTrocas() { }

        public LinxMovimentoTrocas(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoTrocas record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.doc_origem = CustomConvertersExtensions.ConvertToInt32Validation(record.doc_origem);
            this.doc_venda = CustomConvertersExtensions.ConvertToInt32Validation(record.doc_venda);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.vale_cod_cliente = CustomConvertersExtensions.ConvertToInt32Validation(record.vale_cod_cliente);
            this.id_vale_ordem_servico_externa = CustomConvertersExtensions.ConvertToInt32Validation(record.id_vale_ordem_servico_externa);
            this.doc_venda_origem = CustomConvertersExtensions.ConvertToInt32Validation(record.doc_venda_origem);
            this.cod_cliente = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_cliente);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.num_vale = CustomConvertersExtensions.ConvertToInt64Validation(record.num_vale);
            this.vale_codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.vale_codigoproduto);
            this.valor_vale = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_vale);
            this.excluido = CustomConvertersExtensions.ConvertToBooleanValidation(record.excluido);
            this.desfazimento = CustomConvertersExtensions.ConvertToInt32Validation(record.desfazimento);
            this.identificador = Guid.Parse(record.identificador);
            this.cnpj_emp = record.cnpj_emp;
            this.motivo = record.motivo;
            this.serie_origem = record.serie_origem;
            this.serie_venda = record.serie_venda;
            this.serie_venda_origem = record.serie_venda_origem;
            this.recordKey = $"[{record.cnpj_emp}]|[{record.num_vale}]|[{record.doc_origem}]|[{record.doc_venda}]|[{record.doc_venda_origem}]|[{record.cod_cliente}]|[{record.timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
