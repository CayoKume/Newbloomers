namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxPosicaoOsRamoOptico
    {
        public string? id_posicao_os_ramo_optico { get; private set; }
        public string? descricao { get; private set; }
        public string? codigo_status_padrao { get; private set; }
        public string? ativo { get; private set; }
        public string? timestamp { get; private set; }

        public LinxPosicaoOsRamoOptico() { }

        public LinxPosicaoOsRamoOptico(
            string? id_posicao_os_ramo_optico,
            string? descricao,
            string? codigo_status_padrao,
            string? ativo,
            string? timestamp
        )
        {
            this.id_posicao_os_ramo_optico = id_posicao_os_ramo_optico;
            this.descricao = descricao;
            this.timestamp = timestamp;
            this.codigo_status_padrao = codigo_status_padrao;
            this.ativo = ativo;
        }
    }
}