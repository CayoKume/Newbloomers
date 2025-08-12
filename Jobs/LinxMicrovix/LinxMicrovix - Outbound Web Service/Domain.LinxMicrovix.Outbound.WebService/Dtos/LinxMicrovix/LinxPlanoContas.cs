

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxPlanoContas
    {
        public string? portal { get; private set; }
        public string? empresa { get; private set; }
        public string? cnpj { get; private set; }
        public string? id_conta { get; private set; }
        public string? nome_conta { get; private set; }
        public string? sintetica { get; private set; }
        public string? indice { get; private set; }
        public string? ativa { get; private set; }
        public string? fluxo_caixa { get; private set; }
        public string? conta_contabil { get; private set; }
        public string? id_natureza_conta { get; private set; }
        public string? conta_bancaria { get; private set; }
        public string? timestamp { get; private set; }

        public LinxPlanoContas() { }

        public LinxPlanoContas(
            string? portal,
            string? empresa,
            string? cnpj,
            string? id_conta,
            string? nome_conta,
            string? sintetica,
            string? indice,
            string? ativa,
            string? fluxo_caixa,
            string? conta_contabil,
            string? id_natureza_conta,
            string? conta_bancaria,
            string? timestamp
        )
        {
            this.portal = portal;
            this.empresa = empresa;
            this.cnpj = cnpj;
            this.id_conta = id_conta;
            this.nome_conta = nome_conta;
            this.sintetica = sintetica;
            this.indice = indice;
            this.ativa = ativa;
            this.fluxo_caixa = fluxo_caixa;
            this.conta_contabil = conta_contabil;
            this.id_natureza_conta = id_natureza_conta;
            this.conta_bancaria = conta_bancaria;
            this.timestamp = timestamp;
        }
    }
}