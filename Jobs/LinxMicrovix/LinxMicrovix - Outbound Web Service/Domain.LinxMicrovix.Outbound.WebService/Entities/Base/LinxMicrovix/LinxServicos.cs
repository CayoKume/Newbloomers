namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxServicos
    {
        public string? id_setor { get; set; }
        public string? cod_servico { get; set; }
        public string? nome { get; set; }
        public string? desc_setor { get; set; }
        public string? id_linha { get; set; }
        public string? desc_linha { get; set; }
        public string? id_marca { get; set; }
        public string? desc_marca { get; set; }
        public string? dt_update { get; set; }
        public string? operacao_servico { get; set; }
        public string? servico_km { get; set; }
        public string? desativado { get; set; }
        public string? cod_lc11603 { get; set; }
        public string? codigo_nbs { get; set; }
        public string? dt_inclusao { get; set; }
        public string? timestamp { get; set; }
        public string? codigo_ws { get; set; }
        public string? portal { get; set; }
    }
}
