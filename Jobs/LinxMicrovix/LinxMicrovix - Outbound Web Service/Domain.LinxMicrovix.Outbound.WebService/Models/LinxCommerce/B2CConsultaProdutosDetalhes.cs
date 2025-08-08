using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosDetalhes
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_prod_det { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public Int32? empresa { get; private set; }
        public decimal? saldo { get; private set; }
        public Int32? controla_lote { get; private set; }
        public string? nomeproduto_alternativo { get; private set; }
        public Int64? timestamp { get; private set; }
        public string? referencia { get; private set; }
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
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutosDetalhes record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_prod_det = CustomConvertersExtensions.ConvertToInt32Validation(record.id_prod_det);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.saldo = CustomConvertersExtensions.ConvertToDecimalValidation(record.saldo);
            this.controla_lote = CustomConvertersExtensions.ConvertToInt32Validation(record.controla_lote);
            this.tempo_preparacao_estoque = CustomConvertersExtensions.ConvertToInt32Validation(record.tempo_preparacao_estoque);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.nomeproduto_alternativo = record.nomeproduto_alternativo;
            this.referencia = record.referencia;
            this.localizacao = record.localizacao;
            this.recordXml = recordXml;
        }
    }
}
