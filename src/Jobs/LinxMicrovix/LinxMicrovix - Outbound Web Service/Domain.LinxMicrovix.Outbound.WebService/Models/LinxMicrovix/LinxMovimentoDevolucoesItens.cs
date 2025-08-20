
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoDevolucoesItens
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_movimento_devolucoes_itens { get; private set; }
        public Int32? portal { get; private set; }
        public Guid? identificador_venda { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Guid? identificador_devolucao { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public Int32? transacao_origem { get; private set; }
        public Int32? transacao_devolucao { get; private set; }
        public decimal? qtde_devolvida { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoDevolucoesItens() { }

        public LinxMovimentoDevolucoesItens(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoDevolucoesItens record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_movimento_devolucoes_itens = CustomConvertersExtensions.ConvertToInt32Validation(record.id_movimento_devolucoes_itens);
            this.transacao_origem = CustomConvertersExtensions.ConvertToInt32Validation(record.transacao_origem);
            this.transacao_devolucao = CustomConvertersExtensions.ConvertToInt32Validation(record.transacao_devolucao);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.identificador_venda = Guid.Parse(record.identificador_venda);
            this.identificador_devolucao = Guid.Parse(record.identificador_devolucao);
            this.qtde_devolvida = CustomConvertersExtensions.ConvertToDecimalValidation(record.qtde_devolvida);
            this.cnpj_emp = record.cnpj_emp;
        }
    }
}
