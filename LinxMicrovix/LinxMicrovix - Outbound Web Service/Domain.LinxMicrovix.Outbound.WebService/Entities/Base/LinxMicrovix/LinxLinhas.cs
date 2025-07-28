namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxLinhas
    {
        public string? id_linha { get; set; }
        public string? desc_linha { get; set; }
        public string? timestamp { get; set; }
        public string? codigo_integracao_ws { get; set; }
        public string? portal { get; set; }
        public string? coeficiente_comissao { get; set; }
    }
}
