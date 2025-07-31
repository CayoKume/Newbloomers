namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMovimentoRemessasItens
    {
        public string? id_remessas_itens { get; set; }
        public string? empresa { get; set; }
        public string? portal { get; set; }
        public string? id_remessas { get; set; }
        public string? transacao { get; set; }
        public string? qtde_total { get; set; }
        public string? qtde_venda { get; set; }
        public string? qtde_devolvido { get; set; }
        public string? qtde_pendente { get; set; }
        public string? qtde_pendente_pagamento { get; set; }
        public string? timestamp { get; set; }
    }
}
