
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoPrincipal
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_movimento_principal { get; private set; }
        public Guid? identificador { get; private set; }
        public Int64? codigoproduto_manutencao { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? id_pergunta_venda { get; private set; }
        public Int32? id_resposta_venda { get; private set; }
        public decimal? total_fidelidade_cashback { get; private set; }
        public Int32? plano_fidelidade_cashback { get; private set; }
        public string? remessa_pedido_compra { get; private set; }
        public Int32? id_motivo_desconto { get; private set; }
        public decimal? valor_nota { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoPrincipal() { }

        public LinxMovimentoPrincipal(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoPrincipal record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.identificador = Guid.Parse(record.identificador);
            this.total_fidelidade_cashback = CustomConvertersExtensions.ConvertToDecimalValidation(record.total_fidelidade_cashback);
            this.valor_nota = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_nota);
            this.id_movimento_principal = CustomConvertersExtensions.ConvertToInt32Validation(record.id_movimento_principal);
            this.id_pergunta_venda = CustomConvertersExtensions.ConvertToInt32Validation(record.id_pergunta_venda);
            this.id_resposta_venda = CustomConvertersExtensions.ConvertToInt32Validation(record.id_resposta_venda);
            this.plano_fidelidade_cashback = CustomConvertersExtensions.ConvertToInt32Validation(record.plano_fidelidade_cashback);
            this.id_motivo_desconto = CustomConvertersExtensions.ConvertToInt32Validation(record.id_motivo_desconto);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.codigoproduto_manutencao = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto_manutencao);
            this.remessa_pedido_compra = record.remessa_pedido_compra;
        }
    }
}
