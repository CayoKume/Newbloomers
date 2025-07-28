namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxOrdemServicoExternaDav
    {
        public string? id_vendas_pos_tmp_ordem_servico_externa { get; set; }
        public string? id_vendas_pos { get; set; }
        public string? codigo_ordem_servico_externa { get; set; }
        public string? timestamp { get; set; }
    }
}
