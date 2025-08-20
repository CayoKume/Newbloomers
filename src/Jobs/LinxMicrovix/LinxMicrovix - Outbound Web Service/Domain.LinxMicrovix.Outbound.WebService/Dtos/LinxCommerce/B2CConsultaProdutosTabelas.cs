namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosTabelas
    {
        public string? id_tabela { get; private set; }
        public string? nome_tabela { get; private set; }
        public string? ativa { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaProdutosTabelas() { }

        public B2CConsultaProdutosTabelas(string? id_tabela, string? nome_tabela, string? ativa, string? timestamp, string? portal)
        {
            this.id_tabela = id_tabela;
            this.nome_tabela = nome_tabela;
            this.ativa = ativa;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}