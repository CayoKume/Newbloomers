
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxXMLDocumentos
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int32? documento { get; private set; }
        public string? serie { get; private set; }
        public DateTime? data_emissao { get; private set; }
        public string? chave_nfe { get; private set; }
        public Int32? situacao { get; private set; }
        public string? xml { get; private set; }
        public bool? excluido { get; private set; }
        public Guid? identificador_microvix { get; private set; }
        public DateTime? dt_insert { get; private set; }
        public Int64? timestamp { get; private set; }
        public string? nProtCanc { get; private set; }
        public string? nProtInut { get; private set; }
        public string? xmlDistribuicao { get; private set; }
        public string? nProtDeneg { get; private set; }
        public string? cStat { get; private set; }
        public Int32? id_nfe { get; private set; }
        public Int32? cod_cliente { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxXMLDocumentos() { }

        public LinxXMLDocumentos(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxXMLDocumentos record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.documento = CustomConvertersExtensions.ConvertToInt32Validation(record.documento);
            this.situacao = CustomConvertersExtensions.ConvertToInt32Validation(record.situacao);
            this.id_nfe = CustomConvertersExtensions.ConvertToInt32Validation(record.id_nfe);
            this.cod_cliente = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_cliente);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.identificador_microvix = Guid.Parse(record.identificador_microvix);
            this.excluido = CustomConvertersExtensions.ConvertToBooleanValidation(record.excluido);
            this.data_emissao =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_emissao);
            this.dt_insert = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.dt_insert);
            this.cStat = record.cStat;
            this.nProtInut = record.nProtInut;
            this.nProtDeneg = record.nProtDeneg;
            this.xmlDistribuicao = record.xmlDistribuicao;
            this.xml = record.xml;
            this.nProtCanc = record.nProtCanc;
            this.chave_nfe = record.chave_nfe;
            this.serie = record.serie;
            this.cnpj_emp = record.cnpj_emp;
            this.recordKey = $"[{record.cnpj_emp}]|[{record.documento}]|[{record.chave_nfe}]|[{record.timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
