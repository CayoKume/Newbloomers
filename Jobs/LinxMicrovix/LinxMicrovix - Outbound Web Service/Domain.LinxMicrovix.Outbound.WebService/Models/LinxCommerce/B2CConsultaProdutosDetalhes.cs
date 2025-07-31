using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosDetalhes
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_prod_det { get; private set; }

        public Int64? codigoproduto { get; private set; }

        public Int32? empresa { get; private set; }

        public decimal? saldo { get; private set; }

        public Int32? controla_lote { get; private set; }

        [LengthValidation(length: 250, propertyName: "nomeproduto_alternativo")]
        public string? nomeproduto_alternativo { get; private set; }

        public Int64? timestamp { get; private set; }

        [LengthValidation(length: 20, propertyName: "referencia")]
        public string? referencia { get; private set; }

        [LengthValidation(length: 50, propertyName: "localizacao")]
        public string? localizacao { get; private set; }

        public Int32? portal { get; private set; }

        public Int32? tempo_preparacao_estoque { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosDetalhes() { }

        public B2CConsultaProdutosDetalhes(
            List<ValidationResult> listValidations,
            string? id_prod_det,
            string? codigoproduto,
            string? empresa,
            string? saldo,
            string? controla_lote,
            string? nomeproduto_alternativo,
            string? timestamp,
            string? referencia,
            string? localizacao,
            string? portal,
            string? tempo_preparacao_estoque,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_prod_det =
                ConvertToInt32Validation.IsValid(id_prod_det, "id_prod_det", listValidations) ?
                Convert.ToInt32(id_prod_det) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.saldo =
                ConvertToDecimalValidation.IsValid(saldo, "saldo", listValidations) ?
                Convert.ToDecimal(saldo, new CultureInfo("en-US")) :
                0;

            this.controla_lote =
                ConvertToInt32Validation.IsValid(controla_lote, "controla_lote", listValidations) ?
                Convert.ToInt32(controla_lote) :
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

            this.nomeproduto_alternativo = nomeproduto_alternativo;
            this.referencia = referencia;
            this.localizacao = localizacao;
            this.recordXml = recordXml;
        }
    }
}
