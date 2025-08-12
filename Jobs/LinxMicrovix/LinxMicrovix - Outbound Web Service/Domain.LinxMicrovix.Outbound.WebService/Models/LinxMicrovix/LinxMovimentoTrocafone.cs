
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoTrocafone
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Guid? identificador { get; private set; }
        public Int64? num_vale { get; private set; }
        public string? voucher { get; private set; }
        public decimal? valor_vale { get; private set; }
        public string? nome_produto { get; private set; }
        public string? condicao { get; private set; }
        public Int32? id_tradein_parceiro { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoTrocafone() { }

        public LinxMovimentoTrocafone(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoTrocafone record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.id_tradein_parceiro = CustomConvertersExtensions.ConvertToInt32Validation(record.id_tradein_parceiro);
            this.num_vale = CustomConvertersExtensions.ConvertToInt64Validation(record.num_vale);
            this.valor_vale = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_vale);
            this.identificador = Guid.Parse(record.identificador);
            this.cnpj_emp = record.cnpj_emp;
            this.voucher = record.voucher;
            this.nome_produto = record.nome_produto;
            this.condicao = record.condicao;
        }
    }
}
