
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxPlanosPedidoVenda
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int32? cod_pedido { get; private set; }
        public Int32? plano { get; private set; }
        public string? desc_plano { get; private set; }
        public decimal? total { get; private set; }
        public Int32? qtde_parcelas { get; private set; }
        public decimal? indice_plano { get; private set; }
        public decimal? valor_desc_acresc_plano { get; private set; }
        public Int32? cod_forma_pgto { get; private set; }
        public string? forma_pgto { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxPlanosPedidoVenda() { }

        public LinxPlanosPedidoVenda(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxPlanosPedidoVenda record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.plano = CustomConvertersExtensions.ConvertToInt32Validation(record.plano);
            this.cod_pedido = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_pedido);
            this.qtde_parcelas = CustomConvertersExtensions.ConvertToInt32Validation(record.qtde_parcelas);
            this.cod_forma_pgto = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_forma_pgto);
            this.valor_desc_acresc_plano = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_desc_acresc_plano);
            this.indice_plano = CustomConvertersExtensions.ConvertToDecimalValidation(record.indice_plano);
            this.total = CustomConvertersExtensions.ConvertToDecimalValidation(record.total);
            this.forma_pgto = record.forma_pgto;
            this.desc_plano = record.desc_plano;
            this.cnpj_emp = record.cnpj_emp;
        }
    }
}
