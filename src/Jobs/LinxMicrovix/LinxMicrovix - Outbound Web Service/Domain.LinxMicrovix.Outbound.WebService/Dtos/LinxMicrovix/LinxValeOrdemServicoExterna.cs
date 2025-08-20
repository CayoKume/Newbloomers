namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxValeOrdemServicoExterna
    {
        public string? id_vale_ordem_servico_externa { get; set; }
        public string? cnpj_emp { get; private set; }
        public string? numero_controle { get; private set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxValeOrdemServicoExterna()
        {
        }

        public LinxValeOrdemServicoExterna(
            string? id_vale_ordem_servico_externa,
            string? cnpj_emp,
            string? numero_controle,
            string? timestamp,
            string? portal
        )
        {
            this.id_vale_ordem_servico_externa = id_vale_ordem_servico_externa;
            this.cnpj_emp = cnpj_emp;
            this.numero_controle = numero_controle;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}