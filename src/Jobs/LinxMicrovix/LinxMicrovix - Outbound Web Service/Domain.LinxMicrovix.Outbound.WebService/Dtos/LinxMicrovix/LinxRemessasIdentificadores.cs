namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxRemessasIdentificadores
    {
        public string? identificador_venda { get; private set; }
        public string? identificador_remessa { get; private set; }
        public string? id_remessas { get; private set; }
        public string? id_remessas_acertos { get; private set; }
        public string? transacao_acerto { get; private set; }
        public string? qtde_total_acerto { get; private set; }
        public string? identificador_devolucao { get; private set; }
        public string? transacao_remessa { get; private set; }
        public string? id_remessa_operacoes { get; private set; }

        public LinxRemessasIdentificadores() { }

        public LinxRemessasIdentificadores(
            string? identificador_venda,
            string? identificador_remessa,
            string? id_remessas,
            string? id_remessas_acertos,
            string? transacao_acerto,
            string? qtde_total_acerto,
            string? identificador_devolucao,
            string? transacao_remessa,
            string? id_remessa_operacoes
        )
        {
            this.identificador_venda = identificador_venda;
            this.identificador_remessa = identificador_remessa;
            this.id_remessas = id_remessas;
            this.id_remessas_acertos = id_remessas_acertos;
            this.transacao_acerto = transacao_acerto;
            this.qtde_total_acerto = qtde_total_acerto;
            this.identificador_devolucao = identificador_devolucao;
            this.transacao_remessa = transacao_remessa;
            this.id_remessa_operacoes = id_remessa_operacoes;
        }
    }
}