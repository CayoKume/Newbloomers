namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxCommerce
{
    public abstract class B2CConsultaImagens
    {
        public string? id_imagem { get; set; }
        public string? md5 { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }
        public string? url_imagem_blob { get; set; }
    }
}
