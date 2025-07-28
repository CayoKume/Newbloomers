namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMovimentoGiftCard
    {
        public string? empresa { get; set; }
        public string? data_transacao { get; set; }
        public string? operacao { get; set; }
        public string? nsu_cliente { get; set; }
        public string? nsu_host { get; set; }
        public string? valor { get; set; }
        public string? json_envio { get; set; }
        public string? json_retorno { get; set; }
        public string? qtde_tentativa { get; set; }
        public string? aprovado_barramento { get; set; }
        public string? estornada { get; set; }
        public string? codigo_loja { get; set; }
        public string? identificador_movimento { get; set; }
        public string? numero_cartao { get; set; }
        public string? plano { get; set; }
        public string? ambiente_producao { get; set; }
        public string? timestamp { get; set; }
    }
}
