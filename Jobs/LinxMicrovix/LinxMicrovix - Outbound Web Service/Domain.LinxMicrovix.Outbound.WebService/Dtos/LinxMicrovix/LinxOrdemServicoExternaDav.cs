using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxOrdemServicoExternaDav
    {
        public string? id_vendas_pos_tmp_ordem_servico_externa { get; private set; }
        public string? id_vendas_pos { get; private set; }
        public string? codigo_ordem_servico_externa { get; private set; }
        public string? timestamp { get; private set; }

        public LinxOrdemServicoExternaDav() { }

        public LinxOrdemServicoExternaDav(
            string? id_vendas_pos_tmp_ordem_servico_externa,
            string? id_vendas_pos,
            string? codigo_ordem_servico_externa,
            string? timestamp
        )
        {
            this.id_vendas_pos_tmp_ordem_servico_externa = id_vendas_pos_tmp_ordem_servico_externa;
            this.id_vendas_pos = id_vendas_pos;
            this.codigo_ordem_servico_externa = codigo_ordem_servico_externa;
            this.timestamp = timestamp;
        }
    }
}