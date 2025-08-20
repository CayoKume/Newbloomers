

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxOrdensServico
    {
        public string? numero_os { get; private set; }
        public string? empresa { get; private set; }
        public string? data_os { get; private set; }
        public string? data_envio_laboratorio { get; private set; }
        public string? cancelado { get; private set; }
        public string? id_laboratorio { get; private set; }
        public string? id_posicao_os_ramo_optico { get; private set; }
        public string? compartilhar_hub_laboratorios { get; private set; }
        public string? cod_cliente_os { get; private set; }
        public string? cod_vendedor { get; private set; }
        public string? numero_sequencial_antecipacao_financeira { get; private set; }
        public string? chave_nfe_laboratorio { get; private set; }
        public string? timestamp { get; private set; }

        public LinxOrdensServico() { }

        public LinxOrdensServico(
            string? numero_os,
            string? empresa,
            string? data_os,
            string? data_envio_laboratorio,
            string? cancelado,
            string? id_laboratorio,
            string? id_posicao_os_ramo_optico,
            string? compartilhar_hub_laboratorios,
            string? cod_cliente_os,
            string? cod_vendedor,
            string? numero_sequencial_antecipacao_financeira,
            string? chave_nfe_laboratorio,
            string? timestamp
        )
        {
            this.numero_os = numero_os;
            this.empresa = empresa;
            this.data_os = data_os;
            this.data_envio_laboratorio = data_envio_laboratorio;
            this.cancelado = cancelado;
            this.id_laboratorio = id_laboratorio;
            this.id_posicao_os_ramo_optico = id_posicao_os_ramo_optico;
            this.compartilhar_hub_laboratorios = compartilhar_hub_laboratorios;
            this.cod_cliente_os = cod_cliente_os;
            this.cod_vendedor = cod_vendedor;
            this.numero_sequencial_antecipacao_financeira = numero_sequencial_antecipacao_financeira;
            this.chave_nfe_laboratorio = chave_nfe_laboratorio;
            this.timestamp = timestamp;
        }
    }
}