namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoGiftCard
    {
        public string? empresa { get; private set; }
        public string? data_transacao { get; private set; }
        public string? operacao { get; private set; }
        public string? nsu_cliente { get; private set; }
        public string? nsu_host { get; private set; }
        public string? valor { get; private set; }
        public string? json_envio { get; private set; }
        public string? json_retorno { get; private set; }
        public string? qtde_tentativa { get; private set; }
        public string? aprovado_barramento { get; private set; }
        public string? estornada { get; private set; }
        public string? codigo_loja { get; private set; }
        public string? identificador_movimento { get; private set; }
        public string? numero_cartao { get; private set; }
        public string? plano { get; private set; }
        public string? ambiente_producao { get; private set; }
        public string? timestamp { get; private set; }

        public LinxMovimentoGiftCard() { }

        public LinxMovimentoGiftCard(
            string? empresa,
            string? data_transacao,
            string? operacao,
            string? nsu_cliente,
            string? nsu_host,
            string? valor,
            string? json_envio,
            string? json_retorno,
            string? qtde_tentativa,
            string? aprovado_barramento,
            string? estornada,
            string? codigo_loja,
            string? identificador_movimento,
            string? numero_cartao,
            string? plano,
            string? ambiente_producao,
            string? timestamp
        )
        {
            this.empresa = empresa;
            this.data_transacao = data_transacao;
            this.operacao = operacao;
            this.nsu_cliente = nsu_cliente;
            this.nsu_host = nsu_host;
            this.valor = valor;
            this.json_envio = json_envio;
            this.json_retorno = json_retorno;
            this.qtde_tentativa = qtde_tentativa;
            this.aprovado_barramento = aprovado_barramento;
            this.estornada = estornada;
            this.codigo_loja = codigo_loja;
            this.identificador_movimento = identificador_movimento;
            this.numero_cartao = numero_cartao;
            this.plano = plano;
            this.ambiente_producao = ambiente_producao;
            this.timestamp = timestamp;
        }
    }
}