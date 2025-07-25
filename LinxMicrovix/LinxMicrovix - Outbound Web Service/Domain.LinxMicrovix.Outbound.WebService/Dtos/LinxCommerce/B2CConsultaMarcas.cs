namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaMarcas
    {
        public string? codigo_marca { get; private set; }
        public string? nome_marca { get; private set; }
        public string? timestamp { get; private set; }
        public string? linhas { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaMarcas() { }

        public B2CConsultaMarcas(
            string? codigo_marca,
            string? nome_marca,
            string? timestamp,
            string? linhas,
            string? portal
        )
        {
            this.codigo_marca = codigo_marca;
            this.nome_marca = nome_marca;
            this.timestamp = timestamp;
            this.linhas = linhas;
            this.portal = portal;
        }
    }
}