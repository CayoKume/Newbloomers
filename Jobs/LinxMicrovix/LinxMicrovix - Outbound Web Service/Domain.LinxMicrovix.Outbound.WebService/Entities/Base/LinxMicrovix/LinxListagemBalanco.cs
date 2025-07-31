namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxListagemBalanco
    {
        public string? id_balanco { get; set; }
        public string? data { get; set; }
        public string? nome_arquivo { get; set; }
        public string? processado { get; set; }
        public string? data_ultimo_processamento { get; set; }
        public string? qtde_produtos { get; set; }
        public string? qtde_itens { get; set; }
        public string? timestamp { get; set; }
    }
}
