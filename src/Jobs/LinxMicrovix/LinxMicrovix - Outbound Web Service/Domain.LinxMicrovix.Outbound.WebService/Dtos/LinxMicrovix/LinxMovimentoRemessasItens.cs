namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoRemessasItens
    {
        public string? id_remessas_itens { get; private set; }
        public string? empresa { get; private set; }
        public string? portal { get; private set; }
        public string? id_remessas { get; private set; }
        public string? transacao { get; private set; }
        public string? qtde_total { get; private set; }
        public string? qtde_venda { get; private set; }
        public string? qtde_devolvido { get; private set; }
        public string? qtde_pendente { get; private set; }
        public string? qtde_pendente_pagamento { get; private set; }
        public string? timestamp { get; private set; }

        public LinxMovimentoRemessasItens() { }

        public LinxMovimentoRemessasItens(
            string? id_remessas_itens,
            string? empresa,
            string? portal,
            string? id_remessas,
            string? transacao,
            string? qtde_total,
            string? qtde_venda,
            string? qtde_devolvido,
            string? qtde_pendente,
            string? qtde_pendente_pagamento,
            string? timestamp
        )
        {
            this.id_remessas_itens = id_remessas_itens;
            this.empresa = empresa;
            this.portal = portal;
            this.id_remessas = id_remessas;
            this.transacao = transacao;
            this.qtde_total = qtde_total;
            this.qtde_venda = qtde_venda;
            this.qtde_devolvido = qtde_devolvido;
            this.qtde_pendente = qtde_pendente;
            this.qtde_pendente_pagamento = qtde_pendente_pagamento;
            this.timestamp = timestamp;
        }
    }
}