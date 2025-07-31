namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxECF
    {
        public string? id_ecf { get; set; }
        public string? empresa { get; set; }
        public string? ecf { get; set; }
        public string? numeroserie { get; set; }
        public string? indice_sangria { get; set; }
        public string? modelo { get; set; }
        public string? nome { get; set; }
        public string? indice_suprimento { get; set; }
        public string? ativo { get; set; }
        public string? indice_sinal { get; set; }
        public string? indice_antecipacao { get; set; }
        public string? indice_cartao_credito { get; set; }
        public string? empresa_ecf { get; set; }
        public string? timestamp { get; set; }
    }
}
