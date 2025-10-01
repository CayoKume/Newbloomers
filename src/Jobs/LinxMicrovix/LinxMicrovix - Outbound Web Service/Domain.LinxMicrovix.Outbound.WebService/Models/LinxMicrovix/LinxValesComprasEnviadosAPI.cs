
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxValesComprasEnviadosAPI
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? numero_controle { get; private set; }
        public decimal? valor_vale { get; private set; }
        public string? doc_cliente { get; private set; }
        public Int32? status_vale { get; private set; }
        public Int32? codigo_portal_resgate { get; private set; }
        public Int32? codigo_empresa_resgate { get; private set; }
        public Int32? codigo_usuario_resgate { get; private set; }
        public Int32? codigo_vale_empresa_resgate { get; private set; }
        public DateTime? data_criacao { get; private set; }
        public Int64? timestamp { get; private set; }
        public string? cnpj_empresa_resgate { get; private set; }
        public DateTime? data_resgate { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxValesComprasEnviadosAPI() { }

        public LinxValesComprasEnviadosAPI(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxValesComprasEnviadosAPI record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.numero_controle = CustomConvertersExtensions.ConvertToInt32Validation(record.numero_controle);
            this.status_vale = CustomConvertersExtensions.ConvertToInt32Validation(record.status_vale);
            this.codigo_portal_resgate = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_portal_resgate);
            this.codigo_empresa_resgate = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_empresa_resgate);
            this.codigo_usuario_resgate = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_usuario_resgate);
            this.codigo_vale_empresa_resgate = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_vale_empresa_resgate);
            this.data_criacao =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_criacao);
            this.data_resgate =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_resgate);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.valor_vale = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_vale);
            this.doc_cliente = record.doc_cliente;
            this.cnpj_empresa_resgate = record.cnpj_empresa_resgate;
        }
    }
}
