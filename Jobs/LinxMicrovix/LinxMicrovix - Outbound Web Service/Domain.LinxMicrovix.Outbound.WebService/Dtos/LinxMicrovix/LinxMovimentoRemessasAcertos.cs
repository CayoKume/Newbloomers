namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoRemessasAcertos
    {
        public string? id_remessas_acertos { get; private set; }
        public string? portal { get; private set; }
        public string? empresa { get; private set; }
        public string? id_remessas { get; private set; }
        public string? identificador_venda { get; private set; }
        public string? identificador_retorno { get; private set; }
        public string? identificador_devolucao { get; private set; }
        public string? data { get; private set; }
        public string? id_vendas_pos { get; private set; }
        public string? excluido { get; private set; }
        public string? timestamp { get; private set; }

        public LinxMovimentoRemessasAcertos() { }

        public LinxMovimentoRemessasAcertos(
            string? id_remessas_acertos,
            string? portal,
            string? empresa,
            string? id_remessas,
            string? identificador_venda,
            string? identificador_retorno,
            string? identificador_devolucao,
            string? data,
            string? id_vendas_pos,
            string? excluido,
            string? timestamp
        )
        {
            this.id_remessas_acertos = id_remessas_acertos;
            this.portal = portal;
            this.empresa = empresa;
            this.id_remessas = id_remessas;
            this.identificador_venda = identificador_venda;
            this.identificador_retorno = identificador_retorno;
            this.identificador_devolucao = identificador_devolucao;
            this.data = data;
            this.id_vendas_pos = id_vendas_pos;
            this.excluido = excluido;
            this.timestamp = timestamp;
        }
    }
}