namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxValeOrdemServicoExterna
    {
        public string? id_vale_ordem_servico_externa { get; set; }
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? numero_controle { get; set; }
        public string? timestamp { get; set; }
    }
}
