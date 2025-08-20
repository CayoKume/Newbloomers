namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxCommerce
{
    public abstract class B2CConsultaMarcas
    {
        public string? codigo_marca { get; set; }
        public string? nome_marca { get; set; }
        public string? timestamp { get; set; }
        public string? linhas { get; set; }
        public string? portal { get; set; }
    }
}
