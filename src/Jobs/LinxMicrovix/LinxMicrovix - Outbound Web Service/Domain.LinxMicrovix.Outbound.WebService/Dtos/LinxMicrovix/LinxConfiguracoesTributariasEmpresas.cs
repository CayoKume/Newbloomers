namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxConfiguracoesTributariasEmpresas
    {
        public string? portal { get; set; }
        public string? id_config_tributaria { get; set; }
        public string? empresa { get; set; }
        public string? timestamp { get; set; }

        public LinxConfiguracoesTributariasEmpresas()
        {
        }

        public LinxConfiguracoesTributariasEmpresas(string? portal, string? id_config_tributaria, string? empresa, string? timestamp)
        {
            this.portal = portal;
            this.id_config_tributaria = id_config_tributaria;
            this.empresa = empresa;
            this.timestamp = timestamp;
        }
    }
}
