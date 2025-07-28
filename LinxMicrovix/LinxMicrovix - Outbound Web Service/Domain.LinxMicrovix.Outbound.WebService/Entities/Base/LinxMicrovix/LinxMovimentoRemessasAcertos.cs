namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMovimentoRemessasAcertos
    {
        public string? id_remessas_acertos { get; set; }
        public string? portal { get; set; }
        public string? empresa { get; set; }
        public string? id_remessas { get; set; }
        public string? identificador_venda { get; set; }
        public string? identificador_retorno { get; set; }
        public string? identificador_devolucao { get; set; }
        public string? data { get; set; }
        public string? id_vendas_pos { get; set; }
        public string? excluido { get; set; }
        public string? timestamp { get; set; }
    }
}
