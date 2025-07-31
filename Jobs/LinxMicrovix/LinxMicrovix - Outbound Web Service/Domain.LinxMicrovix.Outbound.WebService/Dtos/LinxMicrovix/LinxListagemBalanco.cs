namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxListagemBalanco
    {
        public string? id_balanco { get; set; }
        public string? data { get; set; }
        public string? nome_arquivo { get; set; }
        public string? processado { get; set; }
        public string? data_ultimo_processamento { get; set; }
        public string? qtde_produtos { get; set; }
        public string? qtde_itens { get; set; }
        public string? timestamp { get; set; }

        public LinxListagemBalanco()
        {
        }

        public LinxListagemBalanco(string? id_balanco, string? data, string? nome_arquivo, string? processado, string? data_ultimo_processamento, string? qtde_produtos, string? qtde_itens, string? timestamp)
        {
            this.id_balanco = id_balanco;
            this.data = data;
            this.nome_arquivo = nome_arquivo;
            this.processado = processado;
            this.data_ultimo_processamento = data_ultimo_processamento;
            this.qtde_produtos = qtde_produtos;
            this.qtde_itens = qtde_itens;
            this.timestamp = timestamp;
        }
    }
}
