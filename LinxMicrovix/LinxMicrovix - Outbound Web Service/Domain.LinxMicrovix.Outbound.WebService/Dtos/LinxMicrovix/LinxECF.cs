namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxECF
    {
        public string? id_ecf { get; set; }
        public string? empresa { get; set; }
        public string? numero_serie { get; set; }
        public string? marca { get; set; }
        public string? modelo { get; set; }
        public string? tipo { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxECF() { }

        public LinxECF(string? id_ecf, string? empresa, string? numero_serie, string? marca, string? modelo, string? tipo, string? timestamp, string? portal)
        {
            this.id_ecf = id_ecf;
            this.empresa = empresa;
            this.numero_serie = numero_serie;
            this.marca = marca;
            this.modelo = modelo;
            this.tipo = tipo;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}