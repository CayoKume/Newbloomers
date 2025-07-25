namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaLegendasCadastrosAuxiliares
    {
        public string? empresa { get; private set; }
        public string? legenda_setor { get; private set; }
        public string? legenda_linha { get; private set; }
        public string? legenda_marca { get; private set; }
        public string? legenda_colecao { get; private set; }
        public string? legenda_grade1 { get; private set; }
        public string? legenda_grade2 { get; private set; }
        public string? legenda_espessura { get; private set; }
        public string? legenda_classificacao { get; private set; }
        public string? timestamp { get; private set; }

        public B2CConsultaLegendasCadastrosAuxiliares() { }

        public B2CConsultaLegendasCadastrosAuxiliares(
            string? empresa,
            string? legenda_setor,
            string? legenda_linha,
            string? legenda_marca,
            string? legenda_colecao,
            string? legenda_grade1,
            string? legenda_grade2,
            string? legenda_espessura,
            string? legenda_classificacao,
            string? timestamp
        )
        {
            this.empresa = empresa;
            this.legenda_setor = legenda_setor;
            this.legenda_linha = legenda_linha;
            this.legenda_marca = legenda_marca;
            this.legenda_colecao = legenda_colecao;
            this.legenda_grade1 = legenda_grade1;
            this.legenda_grade2 = legenda_grade2;
            this.legenda_espessura = legenda_espessura;
            this.legenda_classificacao = legenda_classificacao;
            this.timestamp = timestamp;
        }
    }
}