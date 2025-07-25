namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxConfiguracoesTributariasEmpresas
    {
        public string? id_configuracao_tributaria_empresa { get; set; }
        public string? id_configuracao_tributaria { get; set; }
        public string? empresa { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxConfiguracoesTributariasEmpresas() { }

        public LinxConfiguracoesTributariasEmpresas(string? id_configuracao_tributaria_empresa, string? id_configuracao_tributaria, string? empresa, string? timestamp, string? portal)
        {
            this.id_configuracao_tributaria_empresa = id_configuracao_tributaria_empresa;
            this.id_configuracao_tributaria = id_configuracao_tributaria;
            this.empresa = empresa;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}