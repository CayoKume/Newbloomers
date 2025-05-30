using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix
{
    public class LinxOrdensServicoProdutos
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_ordservprod { get; private set; }

        public Int64? cod_produto_serv { get; private set; }

        public Int32? numero_os { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxOrdensServicoProdutos() { }

        public LinxOrdensServicoProdutos(
            List<ValidationResult> listValidations,
            string? id_ordservprod,
            string? cod_produto_serv,
            string? numero_os,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_ordservprod =
                ConvertToInt32Validation.IsValid(id_ordservprod, "id_ordservprod", listValidations) ?
                Convert.ToInt32(id_ordservprod) :
                0;

            this.cod_produto_serv =
                ConvertToInt64Validation.IsValid(cod_produto_serv, "cod_produto_serv", listValidations) ?
                Convert.ToInt64(cod_produto_serv) :
                0;

            this.numero_os =
                ConvertToInt32Validation.IsValid(numero_os, "numero_os", listValidations) ?
                Convert.ToInt32(numero_os) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;
        }
    }
}
