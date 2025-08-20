namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxGrupoLojas
    {
        public string? cnpj { get; set; }
        public string? nome_empresa { get; set; }
        public string? id_empresas_rede { get; set; }
        public string? rede { get; set; }
        public string? portal { get; set; }
        public string? nome_portal { get; set; }
        public string? empresa { get; set; }
        public string? classificacao_portal { get; set; }
    }
}
