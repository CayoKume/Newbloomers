using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaNFe
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_nfe { get; private set; }
        public Int32? id_pedido { get; private set; }
        public Int32? documento { get; private set; }
        public DateTime? data_emissao { get; private set; }
        public string? chave_nfe { get; private set; }
        public Int32? situacao { get; private set; }
        public string? xml { get; private set; }
        public bool? excluido { get; private set; }
        public Guid? identificador_microvix { get; private set; }
        public DateTime? dt_insert { get; private set; }
        public decimal? valor_nota { get; private set; }
        public string? serie { get; private set; }
        public decimal? frete { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }
        public string? nProt { get; private set; }
        public string? codigo_modelo_nf { get; private set; }
        public string? justificativa { get; private set; }
        public Int32? tpAmb { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaNFe() { }

        public B2CConsultaNFe(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaNFe record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_nfe = CustomConvertersExtensions.ConvertToInt32Validation(record.id_nfe);
            this.id_pedido = CustomConvertersExtensions.ConvertToInt32Validation(record.id_pedido);
            this.documento = CustomConvertersExtensions.ConvertToInt32Validation(record.documento);
            this.data_emissao = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_emissao);
            this.situacao = CustomConvertersExtensions.ConvertToInt32Validation(record.situacao);
            this.excluido = CustomConvertersExtensions.ConvertToBooleanValidation(record.excluido);
            this.identificador_microvix = String.IsNullOrEmpty(record.identificador_microvix) ? null : Guid.Parse(record.identificador_microvix);
            this.dt_insert = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.dt_insert);
            this.valor_nota = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_nota);
            this.frete = CustomConvertersExtensions.ConvertToDecimalValidation(record.frete);
            this.tpAmb = CustomConvertersExtensions.ConvertToInt32Validation(record.tpAmb);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.chave_nfe = record.chave_nfe;
            this.xml = record.xml;
            this.nProt = record.nProt;
            this.codigo_modelo_nf = record.codigo_modelo_nf;
            this.justificativa = record.justificativa;
            this.serie = record.serie;
            this.recordKey = $"[{record.id_nfe}]|[{record.id_pedido}]|[{record.chave_nfe}]|[{record.timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
