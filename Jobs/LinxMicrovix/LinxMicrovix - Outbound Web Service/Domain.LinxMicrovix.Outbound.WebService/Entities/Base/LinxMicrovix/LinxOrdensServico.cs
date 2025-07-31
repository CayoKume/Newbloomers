namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxOrdensServico
    {
        public string? numero_os { get; set; }
        public string? empresa { get; set; }
        public string? data_os { get; set; }
        public string? data_envio_laboratorio { get; set; }
        public string? cancelado { get; set; }
        public string? id_laboratorio { get; set; }
        public string? id_posicao_os_ramo_optico { get; set; }
        public string? compartilhar_hub_laboratorios { get; set; }
        public string? cod_cliente_os { get; set; }
        public string? cod_vendedor { get; set; }
        public string? numero_sequencial_antecipacao_financeira { get; set; }
        public string? chave_nfe_laboratorio { get; set; }
        public string? timestamp { get; set; }
    }
}
