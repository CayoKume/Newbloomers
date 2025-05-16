using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaProdutosDetalhesDepositos
    {
        [NotMapped]
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int64? codigoproduto { get; private set; }

        public Int32? empresa { get; private set; }

        public Int32? id_deposito { get; private set; }

        public decimal? saldo { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        public Int32? deposito { get; private set; }

        public Int32? tempo_preparacao_estoque { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosDetalhesDepositos() { }

        public B2CConsultaProdutosDetalhesDepositos(
            List<ValidationResult> listValidations,
            string? codigoproduto,
            string? empresa,
            string? id_deposito,
            string? saldo,
            string? timestamp,
            string? portal,
            string? deposito,
            string? tempo_preparacao_estoque,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.id_deposito =
                ConvertToInt32Validation.IsValid(id_deposito, "id_deposito", listValidations) ?
                Convert.ToInt32(id_deposito) :
                0;

            this.saldo =
                ConvertToDecimalValidation.IsValid(saldo, "saldo", listValidations) ?
                Convert.ToDecimal(saldo, new CultureInfo("en-US")) :
                0;

            this.deposito =
                ConvertToInt32Validation.IsValid(deposito, "deposito", listValidations) ?
                Convert.ToInt32(deposito) :
                0;

            this.tempo_preparacao_estoque =
                ConvertToInt32Validation.IsValid(tempo_preparacao_estoque, "tempo_preparacao_estoque", listValidations) ?
                Convert.ToInt32(tempo_preparacao_estoque) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.recordXml = recordXml;
        }
    }
}
