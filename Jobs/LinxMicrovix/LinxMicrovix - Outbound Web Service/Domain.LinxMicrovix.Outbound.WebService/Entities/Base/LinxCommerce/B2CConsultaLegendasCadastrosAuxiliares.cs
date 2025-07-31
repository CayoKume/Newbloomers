namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxCommerce
{
    public abstract class B2CConsultaLegendasCadastrosAuxiliares
    {
        public string? empresa { get; set; }
        public string? legenda_setor { get; set; }
        public string? legenda_linha { get; set; }
        public string? legenda_marca { get; set; }
        public string? legenda_colecao { get; set; }
        public string? legenda_grade1 { get; set; }
        public string? legenda_grade2 { get; set; }
        public string? legenda_espessura { get; set; }
        public string? legenda_classificacao { get; set; }
        public string? timestamp { get; set; }
    }
}
