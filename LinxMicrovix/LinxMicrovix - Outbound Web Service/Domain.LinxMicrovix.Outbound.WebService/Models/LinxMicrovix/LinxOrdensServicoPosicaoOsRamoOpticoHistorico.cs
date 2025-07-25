using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxOrdensServicoPosicaoOsRamoOpticoHistorico
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_ordens_servico_posicao_os_ramo_optico_historico { get; private set; }

        public Int32? numero_os { get; private set; }

        public Int32? usuario { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? id_posicao_os_ramo_optico { get; private set; }

        public DateTime? data { get; private set; }

        [LengthValidation(length: 200, propertyName: "observacao")]
        public string? observacao { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxOrdensServicoPosicaoOsRamoOpticoHistorico() { }

        public LinxOrdensServicoPosicaoOsRamoOpticoHistorico(
            List<ValidationResult> listValidations,
            string? id_ordens_servico_posicao_os_ramo_optico_historico,
            string? numero_os,
            string? usuario,
            string? timestamp,
            string? id_posicao_os_ramo_optico,
            string? data,
            string? observacao,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_ordens_servico_posicao_os_ramo_optico_historico =
                ConvertToInt32Validation.IsValid(id_ordens_servico_posicao_os_ramo_optico_historico, "id_ordens_servico_posicao_os_ramo_optico_historico", listValidations) ?
                Convert.ToInt32(id_ordens_servico_posicao_os_ramo_optico_historico) :
                0;

            this.numero_os =
                ConvertToInt32Validation.IsValid(numero_os, "numero_os", listValidations) ?
                Convert.ToInt32(numero_os) :
                0;

            this.usuario =
                ConvertToInt32Validation.IsValid(usuario, "usuario", listValidations) ?
                Convert.ToInt32(usuario) :
                0;

            this.id_posicao_os_ramo_optico =
                ConvertToInt32Validation.IsValid(id_posicao_os_ramo_optico, "id_posicao_os_ramo_optico", listValidations) ?
                Convert.ToInt32(id_posicao_os_ramo_optico) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.data =
                ConvertToDateTimeValidation.IsValid(data, "data", listValidations) ?
                Convert.ToDateTime(data) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.observacao = observacao;
        }
    }
}
