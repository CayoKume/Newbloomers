using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxOrdensServicoPosicaoOsRamoOpticoHistorico
    {
        public string? id_ordens_servico_posicao_os_ramo_optico_historico { get; private set; }
        public string? numero_os { get; private set; }
        public string? usuario { get; private set; }
        public string? timestamp { get; private set; }
        public string? id_posicao_os_ramo_optico { get; private set; }
        public string? data { get; private set; }
        public string? observacao { get; private set; }
        public string? portal { get; private set; }

        public LinxOrdensServicoPosicaoOsRamoOpticoHistorico() { }

        public LinxOrdensServicoPosicaoOsRamoOpticoHistorico(
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
            this.id_ordens_servico_posicao_os_ramo_optico_historico = id_ordens_servico_posicao_os_ramo_optico_historico;
            this.numero_os = numero_os;
            this.usuario = usuario;
            this.timestamp = timestamp;
            this.id_posicao_os_ramo_optico = id_posicao_os_ramo_optico;
            this.data = data;
            this.observacao = observacao;
            this.portal = portal;
        }
    }
}