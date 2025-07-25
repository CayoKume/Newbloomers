using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoRemessasItens
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_remessas_itens { get; private set; }

        public Int32? empresa { get; private set; }

        public Int32? portal { get; private set; }

        public Int32? id_remessas { get; private set; }

        public Int32? transacao { get; private set; }

        public decimal? qtde_total { get; private set; }

        public decimal? qtde_venda { get; private set; }

        public decimal? qtde_devolvido { get; private set; }

        public decimal? qtde_pendente { get; private set; }

        public decimal? qtde_pendente_pagamento { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoRemessasItens() { }

        public LinxMovimentoRemessasItens(
            List<ValidationResult> listValidations,
            string? id_remessas_itens,
            string? empresa,
            string? portal,
            string? id_remessas,
            string? transacao,
            string? qtde_total,
            string? qtde_venda,
            string? qtde_devolvido,
            string? qtde_pendente,
            string? qtde_pendente_pagamento,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.id_remessas_itens =
                ConvertToInt32Validation.IsValid(id_remessas_itens, "id_remessas_itens", listValidations) ?
                Convert.ToInt32(id_remessas_itens) :
                0;

            this.id_remessas =
                ConvertToInt32Validation.IsValid(id_remessas, "id_remessas", listValidations) ?
                Convert.ToInt32(id_remessas) :
                0;

            this.transacao =
                ConvertToInt32Validation.IsValid(transacao, "transacao", listValidations) ?
                Convert.ToInt32(transacao) :
                0;

            this.qtde_total =
                ConvertToDecimalValidation.IsValid(qtde_total, "qtde_total", listValidations) ?
                Convert.ToDecimal(qtde_total, new CultureInfo("en-US")) :
                0;

            this.qtde_venda =
                ConvertToDecimalValidation.IsValid(qtde_venda, "qtde_venda", listValidations) ?
                Convert.ToDecimal(qtde_venda, new CultureInfo("en-US")) :
                0;

            this.qtde_devolvido =
                ConvertToDecimalValidation.IsValid(qtde_devolvido, "qtde_devolvido", listValidations) ?
                Convert.ToDecimal(qtde_devolvido, new CultureInfo("en-US")) :
                0;

            this.qtde_pendente =
                ConvertToDecimalValidation.IsValid(qtde_pendente, "qtde_pendente", listValidations) ?
                Convert.ToDecimal(qtde_pendente, new CultureInfo("en-US")) :
                0;

            this.qtde_pendente_pagamento =
                ConvertToDecimalValidation.IsValid(qtde_pendente_pagamento, "qtde_pendente_pagamento", listValidations) ?
                Convert.ToDecimal(qtde_pendente_pagamento, new CultureInfo("en-US")) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;
        }
    }
}
