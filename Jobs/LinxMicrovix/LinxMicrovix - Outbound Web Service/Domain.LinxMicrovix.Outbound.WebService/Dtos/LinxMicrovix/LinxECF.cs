namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxECF
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

        public LinxECF()
        {
        }

        public LinxECF(string? id_ecf, string? empresa, string? ecf, string? numeroserie, string? indice_sangria, string? modelo, string? nome, string? indice_suprimento, string? ativo, string? indice_sinal, string? indice_antecipacao, string? indice_cartao_credito, string? empresa_ecf, string? timestamp)
        {
            this.id_ecf = id_ecf;
            this.empresa = empresa;
            this.ecf = ecf;
            this.numeroserie = numeroserie;
            this.indice_sangria = indice_sangria;
            this.modelo = modelo;
            this.nome = nome;
            this.indice_suprimento = indice_suprimento;
            this.ativo = ativo;
            this.indice_sinal = indice_sinal;
            this.indice_antecipacao = indice_antecipacao;
            this.indice_cartao_credito = indice_cartao_credito;
            this.empresa_ecf = empresa_ecf;
            this.timestamp = timestamp;
        }
    }
}
