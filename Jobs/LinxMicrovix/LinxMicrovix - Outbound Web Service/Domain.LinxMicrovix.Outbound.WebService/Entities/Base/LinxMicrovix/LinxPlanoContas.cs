namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxPlanoContas
    {
        public string? portal { get; set; }
        public string? empresa { get; set; }
        public string? cnpj { get; set; }
        public string? id_conta { get; set; }
        public string? nome_conta { get; set; }
        public string? sintetica { get; set; }
        public string? indice { get; set; }
        public string? ativa { get; set; }
        public string? fluxo_caixa { get; set; }
        public string? conta_contabil { get; set; }
        public string? id_natureza_conta { get; set; }
        public string? conta_bancaria { get; set; }
        public string? timestamp { get; set; }
    }
}
