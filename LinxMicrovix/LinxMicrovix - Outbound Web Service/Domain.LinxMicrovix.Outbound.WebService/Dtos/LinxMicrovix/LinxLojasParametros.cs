namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxLojasParametros
    {
        public string? id_loja_parametro { get; set; }
        public string? empresa { get; set; }
        public string? parametro { get; set; }
        public string? valor { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxLojasParametros() { }

        public LinxLojasParametros(string? id_loja_parametro, string? empresa, string? parametro,
                                   string? valor, string? timestamp, string? portal)
        {
            this.id_loja_parametro = id_loja_parametro;
            this.empresa = empresa;
            this.parametro = parametro;
            this.valor = valor;
            this.timestamp = timestamp;
            this.portal = portal;
        }

    }
}