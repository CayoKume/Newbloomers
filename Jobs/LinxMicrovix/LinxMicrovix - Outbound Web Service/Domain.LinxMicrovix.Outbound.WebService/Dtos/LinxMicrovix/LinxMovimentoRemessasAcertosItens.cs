namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoRemessasAcertosItens
    {
        public string? id_remessas_acertos { get; private set; }
        public string? portal { get; private set; }
        public string? empresa { get; private set; }
        public string? transacao { get; private set; }
        public string? qtde_total { get; private set; }
        public string? id_remessa_operacoes { get; private set; }
        public string? id_remessas_itens { get; private set; }
        public string? timestamp { get; private set; }

        public LinxMovimentoRemessasAcertosItens() { }

        public LinxMovimentoRemessasAcertosItens(
            string? id_remessas_acertos,
            string? portal,
            string? empresa,
            string? transacao,
            string? qtde_total,
            string? id_remessa_operacoes,
            string? id_remessas_itens,
            string? timestamp
        )
        {
            this.id_remessas_acertos = id_remessas_acertos;
            this.empresa = empresa;
            this.transacao = transacao;
            this.qtde_total = qtde_total;
            this.id_remessa_operacoes = id_remessa_operacoes;
            this.id_remessas_itens = id_remessas_itens;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}