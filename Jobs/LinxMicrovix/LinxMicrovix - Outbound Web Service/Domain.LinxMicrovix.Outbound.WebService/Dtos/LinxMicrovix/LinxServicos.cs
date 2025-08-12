

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxServicos
    {
        public string? id_setor { get; private set; }
        public string? cod_servico { get; private set; }
        public string? nome { get; private set; }
        public string? desc_setor { get; private set; }
        public string? id_linha { get; private set; }
        public string? desc_linha { get; private set; }
        public string? id_marca { get; private set; }
        public string? desc_marca { get; private set; }
        public string? dt_update { get; private set; }
        public string? operacao_servico { get; private set; }
        public string? servico_km { get; private set; }
        public string? desativado { get; private set; }
        public string? cod_lc11603 { get; private set; }
        public string? codigo_nbs { get; private set; }
        public string? dt_inclusao { get; private set; }
        public string? timestamp { get; private set; }
        public string? codigo_ws { get; private set; }
        public string? portal { get; private set; }

        public LinxServicos() { }

        public LinxServicos(
            string? id_setor,
            string? cod_servico,
            string? nome,
            string? desc_setor,
            string? id_linha,
            string? desc_linha,
            string? id_marca,
            string? desc_marca,
            string? dt_update,
            string? operacao_servico,
            string? servico_km,
            string? desativado,
            string? cod_lc11603,
            string? codigo_nbs,
            string? dt_inclusao,
            string? timestamp,
            string? codigo_ws,
            string? portal
        )
        {
            this.id_setor = id_setor;
            this.cod_servico = cod_servico;
            this.nome = nome;
            this.desc_setor = desc_setor;
            this.id_linha = id_linha;
            this.desc_linha = desc_linha;
            this.id_marca = id_marca;
            this.desc_marca = desc_marca;
            this.dt_update = dt_update;
            this.operacao_servico = operacao_servico;
            this.servico_km = servico_km;
            this.desativado = desativado;
            this.cod_lc11603 = cod_lc11603;
            this.codigo_nbs = codigo_nbs;
            this.dt_inclusao = dt_inclusao;
            this.timestamp = timestamp;
            this.codigo_ws = codigo_ws;
            this.portal = portal;
        }
    }
}